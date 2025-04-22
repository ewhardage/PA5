using System;
using System.Xml;

namespace mis_221_pa_5_ewhardage
{
    public class ManagerSystem
    {
        private static PizzaUtility pizzaUtility;
        private static OrderFile orderFile;
        private static PizzaFile pizzaFile;
        private static OrderReport orderReport;
        private static Order[] orders;
        private static FroyoOrder[] froyoOrders;
        public void ManagerMenu(Pizza[] pizzas, Order[] orders, FroyoOrder[] froyoOrders, Froyo[] froyos)
        {
            orderFile = new OrderFile(orders);
            pizzaFile = new PizzaFile(pizzas);
            pizzaUtility = new PizzaUtility(pizzas, orders);
            string menuChoice = "";
            while (menuChoice != "6")
            {
                Console.WriteLine("\nManager Menu:");
                Console.WriteLine("1. Add a new pizza recipe to the menu");
                Console.WriteLine("2. Remove a pizza from the menu");
                Console.WriteLine("3. Edit information about a pizza (name, ingredients, etc.)");
                Console.WriteLine("4. Mark a pizza order as complete");
                Console.WriteLine("5. Access the Report Menu");
                Console.WriteLine("6. Return to Main Menu");

                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        AddNewPizza(pizzas);
                        break;
                    case "2":
                        try
                        {
                            pizzaFile.GetAllPizzas();
                            pizzaUtility.ViewAvailablePizzas(pizzas);
                            RemovePizza(pizzas);
                            pizzaFile.SaveAllPizzas();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error accessing pizzas: " + ex.Message);
                        }
                        break;
                    case "3":
                        try
                        {
                            pizzaFile.GetAllPizzas();
                            pizzaUtility.ViewAvailablePizzas(pizzas);
                            EditPizza(pizzas);
                            pizzaFile.SaveAllPizzas();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error accessing pizzas: " + ex.Message);
                        }
                        break;
                    case "4":
                        try
                        {
                            orderFile.GetAllOrders();
                            ViewOrdersInProgress(orders);
                            MarkOrderComplete(orders);
                            orderFile.SaveAllOrders();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error accessing orders: " + ex.Message);
                        }
                        break;
                    case "5":
                        ShowReportMenu(pizzas, orders, froyoOrders);
                        break;
                    case "6":
                        Console.WriteLine("Returning to main menu...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        public static void AddNewPizza(Pizza[] pizzas)
        {
            Pizza newPizza = new Pizza();
            Pizza.SetCount(Pizza.GetCount());
            newPizza.SetPizzaID(Pizza.GetCount().ToString());
            Console.WriteLine("Enter the name of the new pizza:");
            string name = Console.ReadLine();
            newPizza.SetPizzaName(name);
            Console.WriteLine("Enter the amount of toppings on the new pizza:");
            string toppings = Console.ReadLine();
            newPizza.SetCountOfToppings(toppings);
            Console.WriteLine("Enter the crust type of the new pizza (thin, thick, or stuffed):");
            string crust = Console.ReadLine();
            newPizza.SetCrustType(crust);
            Console.WriteLine("Enter the price of the new pizza:");
            double price = double.Parse(Console.ReadLine());
            newPizza.SetPrice(price);
            newPizza.SetIsSoldOut(false);
            newPizza.SetIsOnMenu(true);
            pizzas[Pizza.GetCount()] = newPizza;
            Pizza.IncPizzaCount();
            StreamWriter pizzaFile = new StreamWriter("pizza-menu.txt", true);
            pizzaFile.WriteLine(newPizza.ToFile());
            pizzaFile.Close();
            Console.WriteLine("New pizza added successfully!");
            Console.WriteLine("Press Enter to return to the main menu...");
            Console.ReadLine();
        }
        public static void RemovePizza(Pizza[] pizzas)
        {
            Console.WriteLine("Enter the order ID of the pizza to remove:");
            string searchID = Console.ReadLine();
            bool found = false;
            for (int i = 0; i < Pizza.GetCount(); i++)
            {
                if (pizzas[i] != null && pizzas[i].GetPizzaID() == searchID)
                {
                    pizzas[i].SetIsOnMenu(false);
                    Console.WriteLine("Your pizza has been removed from the menu!");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("Pizza not found.");
            }

            Console.WriteLine("Press Enter to return to the menu...");
            Console.ReadLine();
        }
        public static void EditPizza(Pizza[] pizzas)
        {
            Console.WriteLine("Enter the pizza ID of the pizza to edit:");
            string pizzaID = Console.ReadLine();
            for (int i = 0; i < Pizza.GetCount(); i++)
            {
                if (pizzas[i].GetPizzaID() == pizzaID)
                {
                    Console.WriteLine("Enter the new name of the pizza:");
                    pizzas[i].SetPizzaName(Console.ReadLine());
                    Console.WriteLine("Enter the new amount of toppings on the pizza:");
                    pizzas[i].SetCountOfToppings(Console.ReadLine());
                    Console.WriteLine("Enter the new crust type of the pizza (thin, thick, or stuffed):");
                    pizzas[i].SetCrustType(Console.ReadLine());
                    Console.WriteLine("Enter the new price of the pizza:");
                    pizzas[i].SetPrice(double.Parse(Console.ReadLine()));
                    Console.WriteLine("Pizza updated successfully!");
                    Console.WriteLine("Press Enter to return to the main menu...");
                    Console.ReadLine();
                }

            }

        }
        public int FindOrder(string searchID, Order[] orders)
        {
            for (int i = 0; i < Order.GetCount(); i++)
            {
                if (orders[i] != null && orders[i].GetOrderID() == searchID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void MarkOrderComplete(Order[] orders)
        {
            Console.WriteLine("Enter the order ID of the order to mark as complete:");
            string searchID = Console.ReadLine();
            bool found = false;
            int left = 0;
            int right = Order.GetCount() - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (orders[mid] != null && orders[mid].GetOrderID() == searchID)
                {
                    orders[mid].SetOrderStatus(true);
                    Console.WriteLine("Order marked as complete!");
                    found = true;
                    break;
                }
                else if (orders[mid] != null && string.Compare(orders[mid].GetOrderID(), searchID) < 0)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            if (!found)
            {
                Console.WriteLine("Order not found.");
            }

            Console.WriteLine("Press Enter to return to the menu...");
            Console.ReadLine();
        }
        public static void ShowReportMenu(Pizza[] pizzas, Order[] orders, FroyoOrder[] froyoOrders)
        {
            string menuChoice = "";
            while (menuChoice != "3")
            {
                Console.WriteLine("Report Menu:");
                Console.WriteLine("1. View daily pizza orders report");
                Console.WriteLine("2. Orders currently in progress");
                System.Console.WriteLine("3. Average pizza size by crust");
                System.Console.WriteLine("4. Average price by Froyo flavor");
                System.Console.WriteLine("5. Top 5 most popular pizzas");
                Console.WriteLine("6. Return to main menu");

                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        SortByDate(orders);
                        ViewDailyPizzaOrdersReport(orders);
                        break;
                    case "2":
                        ViewOrdersInProgress(orders);
                        break;
                    case "3":
                        SortByCrustType(orders);
                        ViewAveragePizzaSizeByCrust(orders);
                        SortByDate(orders);
                        break;
                    case "4":
                        SortByFlavor(froyoOrders);
                        ViewAveragePriceByFlavor(froyoOrders);
                        SortByDate(froyoOrders);
                        break;
                    case "5":
                        SortByName(orders);
                        ViewTop5PopularPizzas(orders, pizzas);
                        break;
                    case "6":
                        Console.WriteLine("Returning to manager menu...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

            }
        }
        public static void ViewDailyPizzaOrdersReport(Order[] orders)
        {
            System.Console.WriteLine("What is the date of the pizza orders report? (yyyy-mm-dd)");
            string date = Console.ReadLine();
            Console.WriteLine("Daily Pizza Orders Report:");
            for (int i = 0; i < Order.GetCount(); i++)
            {
                if (orders[i].GetOrderDate() == date)
                {
                    Console.WriteLine(orders[i].ToString());
                }
            }
            Console.WriteLine("Press Enter to return to the report menu...");
            Console.ReadLine();
        }
        public static void ProcessBreak(Order[] orders, ref string currentDate, int i)
        {
            System.Console.WriteLine($"{currentDate}");
        }
        public static void ViewOrdersInProgress(Order[] orders)
        {
            Console.WriteLine("Orders currently in progress:");
            for (int i = 0; i < Order.GetCount(); i++)
            {
                if (orders[i].GetOrderStatus() == false)
                {
                    Console.WriteLine(orders[i].ToString());
                }
            }
        }
        public static void SortByCrustType(Order[] orders)
        {
            for (int i = 0; i < Order.GetCount() - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < Order.GetCount(); j++)
                {
                    if (orders[min].GetCrustType().CompareTo(orders[j].GetCrustType()) > 0)
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    Swap(min, i, orders);
                }
            }
        }

        public static void SortByDate(Order[] orders)
        {
            for (int i = 0; i < Order.GetCount() - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < Order.GetCount(); j++)
                {
                    if (orders[min].GetOrderDate().CompareTo(orders[j].GetOrderDate()) > 0)
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    Swap(min, i, orders);
                }
            }
        }
        public static void SortByName(Order[] orders)
        {
            for (int i = 0; i < Order.GetCount() - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < Order.GetCount(); j++)
                {
                    if (orders[min].GetPizzaID().CompareTo(orders[j].GetPizzaID()) > 0)
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    Swap(min, i, orders);
                }
            }
        }
        public static void Swap(int x, int y, Order[] orders)
        {
            Order temp = orders[x];
            orders[x] = orders[y];
            orders[y] = temp;
        }
        public static void ViewAveragePizzaSizeByCrust(Order[] orders)
        {
            string curr = orders[0].GetCrustType();
            double total = orders[0].GetSize();
            int nameCount = 1;
            for (int i = 1; i < Order.GetCount(); i++)
            {
                if (curr == orders[i].GetCrustType())
                {
                    total += orders[i].GetSize();
                    nameCount++;
                }
                else
                {
                    ProcessBreak(orders, ref curr, ref total, ref nameCount, i);
                }
            }
            ProcessBreak(curr, total, nameCount);

        }
        public static void ProcessBreak(Order[] orders, ref string curr, ref double total, ref int nameCount, int i)
        {
            System.Console.WriteLine($"{curr}\t{total / nameCount}");
            curr = orders[i].GetCrustType();
            total = orders[i].GetSize();
            nameCount = 1;
        }
        public static void ProcessBreak(string curr, double total, int nameCount)
        {
            System.Console.WriteLine($"{curr}\t{total / nameCount}");
        }
        public static void ViewTop5PopularPizzas(Order[] orders, Pizza[] pizzas)
        {
            // Count occurrences of each pizza
            string curr = orders[0].GetPizzaID();
            int count = 1;
            int[] topCounts = new int[Order.GetCount()];
            string[] topPizzaIDs = new string[Order.GetCount()];
            for (int i = 1; i < Order.GetCount(); i++)
            {
                if (curr == orders[i].GetPizzaID())
                {
                    count++;
                }
                else
                {
                    // Check if this count is in top 5
                    for (int j = 0; j < Order.GetCount(); j++)
                    {
                        if (count > topCounts[j])
                        {
                            // Shift everything down
                            for (int n = Order.GetCount() - 1; n > j; n--)
                            {
                                topCounts[n] = topCounts[n - 1];
                                topPizzaIDs[n] = topPizzaIDs[n - 1];
                            }
                            topCounts[j] = count;
                            topPizzaIDs[j] = curr;
                            break;
                        }
                    }
                    curr = orders[i].GetPizzaID();
                    count = 1;
                }
            }

            // Check last group
            for (int i = 0; i < Order.GetCount(); i++)
            {
                if (count > topCounts[i])
                {
                    for (int j = Order.GetCount() - 1; j > i; j--)
                    {
                        topCounts[j] = topCounts[j - 1];
                        topPizzaIDs[j] = topPizzaIDs[j - 1];
                    }
                    topCounts[i] = count;
                    topPizzaIDs[i] = curr;
                    break;
                }
            }

            System.Console.WriteLine("\nTop 5 Popular Pizzas:");
            for (int i = 0; i < 5; i++)
            {
                if (topCounts[i] > 0)
                {
                    string pizzaName = "";
                    for (int j = 0; j < Pizza.GetCount(); j++)
                    {
                        if (pizzas[j].GetPizzaID() == topPizzaIDs[i])
                        {
                            pizzaName = pizzas[j].GetPizzaName();
                            break;
                        }
                    }
                    System.Console.WriteLine($"{i + 1}. {pizzaName}\t{topCounts[i]} orders");
                }
            }
        }
        public static void SortByFlavor(FroyoOrder[] froyoOrders)
        {
            for (int i = 0; i < FroyoOrder.GetCount() - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < FroyoOrder.GetCount(); j++)
                {
                    if (froyoOrders[min].GetFroyoFlavor().CompareTo(froyoOrders[j].GetFroyoFlavor()) > 0)
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    Swap(min, i, froyoOrders);
                }
            }
        }
        public static void SortByDate(FroyoOrder[] froyoOrders)
        {
            for (int i = 0; i < FroyoOrder.GetCount() - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < FroyoOrder.GetCount(); j++)
                {
                    if (froyoOrders[min].GetOrderDate().CompareTo(froyoOrders[j].GetOrderDate()) > 0)
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    Swap(min, i, froyoOrders);
                }
            }
        }
        public static void Swap(int x, int y, FroyoOrder[] froyoOrders)
        {
            FroyoOrder temp = froyoOrders[x];
            froyoOrders[x] = froyoOrders[y];
            froyoOrders[y] = temp;
        }
        public static void ViewAveragePriceByFlavor(FroyoOrder[] froyoOrders)
        {
    

            string curr = froyoOrders[0].GetFroyoFlavor();
            double total = froyoOrders[0].GetFroyoPrice();
            int nameCount = 1;
            for (int i = 1; i < FroyoOrder.GetCount(); i++)
            {
                if (curr == froyoOrders[i].GetFroyoFlavor())
                {
                    total += froyoOrders[i].GetFroyoPrice();
                    nameCount++;
                }
                else
                {
                    ProcessBreak(froyoOrders, ref curr, ref total, ref nameCount, i);
                }
            }
            ProcessBreakFroyo(curr, total, nameCount);
        }
        public static void ProcessBreak(FroyoOrder[] froyoOrders, ref string curr, ref double total, ref int nameCount, int i)
        {
            System.Console.WriteLine($"{curr}\t{total / nameCount}");
            curr = froyoOrders[i].GetFroyoFlavor();
            total = froyoOrders[i].GetFroyoPrice();
            nameCount = 1;
        }
        public static void ProcessBreakFroyo(string curr, double total, int nameCount)
        {
            System.Console.WriteLine($"{curr}\t{total / nameCount}");
        }
    }
}
