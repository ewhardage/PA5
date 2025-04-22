using System;
using mis_221_pa_5_ewhardage;

Pizza[] pizzas = new Pizza[100];
Order[] orders = new Order[100];
Froyo[] froyos = new Froyo[100];
FroyoOrder[] froyoOrders = new FroyoOrder[100];


PizzaFile pizzaFile = new PizzaFile(pizzas);
CustomerSystem customerSystem = new CustomerSystem();
ManagerSystem managerSystem = new ManagerSystem();
PizzaReport pizzaReport = new PizzaReport(pizzas);
PizzaUtility pizzaUtility = new PizzaUtility(pizzas, orders);
OrderFile orderFile = new OrderFile(orders);    
FroyoFile froyoFile = new FroyoFile(froyos);
froyoFile.ClearFroyoOrders();
//orderFile.ClearOrders();
//pizzaFile.ClearPizzas();

// System.Console.WriteLine(orders[0]);

pizzaFile.GetAllPizzas();
orderFile.GetAllOrders();
froyoFile.GetAllFroyoOrders();
// System.Console.WriteLine(orders[0].GetOrderStatus());
// System.Console.WriteLine(Order.GetCount());
string menuChoice = pizzaUtility.GetMenuChoice();
//Orders might need to be cleared
//Need to sort orders by date for one report and one by crust type
while (menuChoice != "3"){
switch (menuChoice)
{
    case "1":
        customerSystem.CustomerMenu(pizzas, orders, froyos, froyoOrders);
        menuChoice = pizzaUtility.GetMenuChoice();
        break;
    case "2":
        managerSystem.ManagerMenu(pizzas, orders, froyoOrders, froyos);
        menuChoice = pizzaUtility.GetMenuChoice();
        break;
    case "3":
        Console.WriteLine("Thank you for using Pappa's Pizzeria!");
        menuChoice = "3";
        break; 
    default:
        Console.WriteLine("Invalid option. Please try again.");
        break;
}
}
// Add your pizza system logic here         


// Pizza[] pizzas = new Pizza[100];
// PizzaFile pizzaFile = new PizzaFile(pizzas);
// pizzaFile.GetAllPizzas();

// PizzaReport report = new PizzaReport(pizzas);
// report.PrintAllPizzas();

// MenuSystem menu = new MenuSystem();
// menu.Run();

// Pizza[] pizzas = new Pizza[100];
// PizzaFile pizzaFile = new PizzaFile(pizzas);
// pizzaFile.GetAllPizzas();

// PizzaReport report = new PizzaReport(pizzas);
// report.PrintAllPizzas();

// PizzaUtility utility = new PizzaUtility(pizzas);
// utility.Sort();

// System.Console.WriteLine("\n\n");
// utility.Sort("name");
// pizzaFile.SaveAllPizzas();
// report.PrintAllPizzas();


// Pizza[] pizzas = new Pizza[100];
// PizzaFile pizzaFile = new PizzaFile(pizzas);
// pizzaFile.GetAllPizzas();

// PizzaReport report = new PizzaReport(pizzas);
// report.PrintAllPizzas();

// PizzaUtility utility = new PizzaUtility(pizzas);
// utility.Sort();

// System.Console.WriteLine("\n\n");
// // report.PrintAllPizzas();
// // System.Console.WriteLine("\n\n\n");
// // utility.Sort("pizzaid");
// // report.PrintAllPizzas();
// // System.Console.WriteLine("\n\n\n");
// // report.AveragePriceByPizzaName();
// utility.Sort("name");
// pizzaFile.SaveAllPizzas();
// report.PrintAllPizzas();
// utility.UpdatePizza();
// pizzaFile.SaveAllPizzas();
// System.Console.WriteLine("\n\n\n");
// report.PrintAllPizzas();



//////////////////////////  END MAIN  /////////////////////////////////

