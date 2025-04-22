using System;

namespace mis_221_pa_5_ewhardage
{
    public class CustomerSystem
    {
        public void CustomerMenu(Pizza[] pizzas, Order[] orders, Froyo[] froyos, FroyoOrder[] froyoOrders)
        {
            PizzaFile pizzaFile = new PizzaFile(pizzas);
            PizzaReport pizzaReport = new PizzaReport(pizzas);
            PizzaUtility pizzaUtility = new PizzaUtility(pizzas, orders);

            string menuChoice = "";
            while (menuChoice != "4")
            {
                Console.WriteLine("Customer Menu:");
                System.Console.WriteLine("1. View Available Pizzas");
                System.Console.WriteLine("2. Order a Pizza");
                System.Console.WriteLine("3. Order a Froyo");
                System.Console.WriteLine("4. View Order History");
                System.Console.WriteLine("5. View Froyo Order History");
                System.Console.WriteLine("6. Return to Main Menu");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        pizzaFile.GetAllPizzas();
                        pizzaUtility.ViewAvailablePizzas(pizzas);
                        System.Console.WriteLine("Press Enter to return to the main menu...");
                        Console.ReadLine();
                        break;
                    case "2":
                        pizzaFile.GetAllPizzas();
                        pizzaUtility.ViewAvailablePizzas(pizzas);
                        OrderPizza(pizzas, orders);
                        break;
                    case "3":
                        OrderFroyo(froyos, froyoOrders);
                        break;
                    case "4":
                        ViewPizzaOrderHistory(orders);
                        break;
                    case "5":
                        ViewFroyoOrderHistory(froyoOrders);
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
        public static void OrderPizza(Pizza[] pizzas, Order[] orders)
        {

            Order newOrder = new Order();
            Order.SetCount(Order.GetCount());
            newOrder.SetOrderID((Order.GetCount()).ToString());
            System.Console.WriteLine("Enter your email:");
            string email = Console.ReadLine();
            newOrder.SetCustomerEmail(email);
            System.Console.WriteLine("Enter the pizza ID you want to order:");
            string pizzaID = Console.ReadLine();
            newOrder.SetCrustType(pizzas[int.Parse(pizzaID)].GetCrustType());
            newOrder.SetPizzaID(pizzaID);
            System.Console.WriteLine("Enter the size of the pizza you want to order in inches (8, 12, 16):"); //Fix the inches so you can get average
            int size = int.Parse(Console.ReadLine());
            newOrder.SetSize(size);
            newOrder.SetOrderDate(DateTime.Now.ToString("yyyy-MM-dd"));
            newOrder.SetOrderStatus(false);
            for (int i = 0; i < Pizza.GetCount(); i++)
            {
                {
                    string order = $"{size}' {pizzas[i].ToString()}";
                    System.Console.WriteLine("You have ordered: " + order);
                    orders[Order.GetCount()] = newOrder;
                    Order.IncCount();
                    StreamWriter outFile = new StreamWriter("orders.txt", true);
                    outFile.WriteLine(newOrder.ToFile());
                    outFile.Close();
                    break;
                }
            }

        }
        public static void ViewPizzaOrderHistory(Order[] orders)
        {
            Console.WriteLine("Enter your email:");
            string email = Console.ReadLine();
            bool foundOrders = false;
            StreamReader inFile = new StreamReader("orders.txt");
            string line = inFile.ReadLine();
            System.Console.WriteLine("Here is your order history:");
            for (int i = 0; i < Order.GetCount(); i++)
            {
                if (orders[i].GetCustomerEmail() == email)
                {
                    System.Console.WriteLine(orders[i].ToString());
                    foundOrders = true;

                }
            }
            // string[] temp = line.Split('#');
            // if (temp.Length > 1 && temp[1] == email)
            // {
            //     Console.WriteLine(line);

            // }
            line = inFile.ReadLine();

            if (!foundOrders)
            {
                Console.WriteLine("No orders found for this email.");
            }
            inFile.Close();
            Console.WriteLine("Press Enter to return to the menu...");
            Console.ReadLine();
        }
        public static void OrderFroyo(Froyo[] froyos, FroyoOrder[] froyoOrders)
        {
            FroyoOrder newOrder = new FroyoOrder();
            FroyoOrder.SetCount(FroyoOrder.GetCount());
            newOrder.SetOrderID((FroyoOrder.GetCount()).ToString());
            System.Console.WriteLine("Enter your email:");
            string email = Console.ReadLine();
            newOrder.SetCustomerEmail(email);
            System.Console.WriteLine("Enter the froyo flavor you want to order (1-6):");
            System.Console.WriteLine("1. Vanilla");
            System.Console.WriteLine("2. Chocolate");
            System.Console.WriteLine("3. Strawberry");
            System.Console.WriteLine("4. Mint");
            System.Console.WriteLine("5. Peach");
            System.Console.WriteLine("6. Mango");
            string flavor = Console.ReadLine();
            switch (flavor)
            {
                case "1":
                    newOrder.SetFroyoFlavor("Vanilla");
                    break;
                case "2":
                    newOrder.SetFroyoFlavor("Chocolate");
                    break;
                case "3":
                    newOrder.SetFroyoFlavor("Strawberry");
                    break;
                case "4":
                    newOrder.SetFroyoFlavor("Mint");
                    break;
                case "5":
                    newOrder.SetFroyoFlavor("Peach");
                    break;
                case "6":
                    newOrder.SetFroyoFlavor("Mango");
                    break;
                default:
                    System.Console.WriteLine("Invalid flavor. Please try again.");
                    break;
            }
            System.Console.WriteLine("Enter the size of the froyo you want to order (1-3):");
            System.Console.WriteLine("1. Small");
            System.Console.WriteLine("2. Medium");
            System.Console.WriteLine("3. Large");
            string size = Console.ReadLine();
            switch (size)
            {
                case "1":
                    newOrder.SetFroyoSize("Small");
                    break;
                case "2":
                    newOrder.SetFroyoSize("Medium");
                    break;
                case "3":
                    newOrder.SetFroyoSize("Large");
                    break;
                default:
                    System.Console.WriteLine("Invalid size. Please try again.");
                    break;
            }
            newOrder.SetOrderDate(DateTime.Now.ToString("yyyy-MM-dd"));
            System.Console.WriteLine("Enter the toppings you want on your froyo (max of 5):");
            int toppingsCount = 0;
            Toppings toppings = new Toppings();
            bool ordering = true;
            toppings.SetHasStrawberries(false);
            toppings.SetHasSprinkles(false);
            toppings.SetHasChocolate(false);
            toppings.SetHasCaramel(false);
            toppings.SetHasNuts(false);
            toppings.SetHasGummyBears(false);
            toppings.SetHasMAndMs(false);
            toppings.SetHasReeses(false);
            toppings.SetHasOreos(false);
            toppings.SetHasChocolateChips(false);
            toppings.SetHasWhippedCream(false);
            toppings.SetHasCherries(false);
            toppingsCount = 0;
            while (ordering && toppingsCount < 5)
            {
                System.Console.WriteLine("1. Strawberries");
                System.Console.WriteLine("2. Sprinkles");
                System.Console.WriteLine("3. Chocolate");
                System.Console.WriteLine("4. Caramel");
                System.Console.WriteLine("5. Nuts");
                System.Console.WriteLine("6. Gummy Bears");
                System.Console.WriteLine("7. M&Ms");
                System.Console.WriteLine("8. Reeses");
                System.Console.WriteLine("9. Oreos");
                System.Console.WriteLine("10. Chocolate Chips");
                System.Console.WriteLine("11. Whipped Cream");
                System.Console.WriteLine("12. Cherries");
                System.Console.WriteLine("None or no more toppings(Enter 0)");
                string topping = Console.ReadLine();

                switch (topping)
                {
                    case "1":
                        toppings.SetHasStrawberries(true);
                        break;
                    case "2":
                        toppings.SetHasSprinkles(true);
                        break;
                    case "3":
                        toppings.SetHasChocolate(true);
                        break;
                    case "4":
                        toppings.SetHasCaramel(true);
                        break;
                    case "5":
                        toppings.SetHasNuts(true);
                        break;
                    case "6":
                        toppings.SetHasGummyBears(true);
                        break;
                    case "7":
                        toppings.SetHasMAndMs(true);
                        break;
                    case "8":
                        toppings.SetHasReeses(true);
                        break;
                    case "9":
                        toppings.SetHasOreos(true);
                        break;
                    case "10":
                        toppings.SetHasChocolateChips(true);
                        break;
                    case "11":
                        toppings.SetHasWhippedCream(true);
                        break;
                    case "12":
                        toppings.SetHasCherries(true);
                        break;
                    case "0":
                        ordering = false;
                        break;
                    default:
                        System.Console.WriteLine("Invalid topping. Please try again.");
                        break;
                }
                toppingsCount++;
            }
            newOrder.SetToppings(toppings);
            newOrder.SetFroyoPrice(CalculatePrice(toppingsCount, size));
            newOrder.SetIsSoldOut(false);
            newOrder.SetIsOnMenu(true);
            froyoOrders[FroyoOrder.GetCount()] = newOrder;
            FroyoOrder.IncCount();
            StreamWriter outFile = new StreamWriter("froyo-orders.txt", true);
            outFile.WriteLine(newOrder.ToFile());
            outFile.Close();
            System.Console.WriteLine($"Your order of a {newOrder.GetFroyoSize()}, {newOrder.GetFroyoFlavor()} with {TypeToppings(toppings)} has been placed successfully!");
            System.Console.WriteLine($"Your order costs ${newOrder.GetFroyoPrice()}");
            System.Console.WriteLine("Press Enter to return to the menu...");
            Console.ReadLine();
        }
        public static double CalculatePrice(int toppingsCount, string size){
            double price = 0;
            switch(size){
                case "1":
                    price = 3.00;
                    break;
                case "2":   
                    price = 4.00;
                    break;
                case "3":
                    price = 5.00;
                    break;
            }
            return price + (toppingsCount * 0.50);
        }
        public static string TypeToppings(Toppings toppings){
            string toppingsString = "";
            if(toppings.GetHasStrawberries()){
                toppingsString += "Strawberries ";
            }
            if(toppings.GetHasSprinkles()){
                toppingsString += "Sprinkles ";
            }
            if(toppings.GetHasChocolate()){
                toppingsString += "Chocolate ";
            }
            if(toppings.GetHasCaramel()){
                toppingsString += "Caramel ";
            }
            if(toppings.GetHasNuts()){
                toppingsString += "Nuts ";
            }
            if(toppings.GetHasGummyBears()){
                toppingsString += "Gummy Bears ";
            }
            if(toppings.GetHasMAndMs()){
                toppingsString += "M&Ms ";
            }
            if(toppings.GetHasReeses()){
                toppingsString += "Reeses ";
            }
            if(toppings.GetHasOreos()){
                toppingsString += "Oreos ";
            }
            if(toppings.GetHasChocolateChips()){
                toppingsString += "Chocolate Chips ";
            }
            if(toppings.GetHasWhippedCream()){
                toppingsString += "Whipped Cream ";
            }
            if(toppings.GetHasCherries()){
                toppingsString += "Cherries ";
            }
            return toppingsString;
        }       
        public static void ViewFroyoOrderHistory(FroyoOrder[] froyoOrders){
            Console.WriteLine("Enter your email:");
            string email = Console.ReadLine();
            bool foundOrders = false;
            StreamReader inFile = new StreamReader("froyo-orders.txt");
            string line = inFile.ReadLine();
            for(int i = 0; i < FroyoOrder.GetCount(); i++){
                if(froyoOrders[i].GetCustomerEmail() == email){
                    System.Console.WriteLine(froyoOrders[i].ToString());
                    foundOrders = true;
                }
                line = inFile.ReadLine();
            }
            if(!foundOrders){
                Console.WriteLine("No orders found for this email.");
            }
            inFile.Close();
            Console.WriteLine("Press Enter to return to the menu...");
            Console.ReadLine();
        }
    }
}

