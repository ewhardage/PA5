using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_ewhardage
{
    public class PizzaUtility
    {
        private Pizza[] pizzas;
        private Order[] orders;

        public PizzaUtility(Pizza[] pizzas, Order[] orders)
        {
            this.pizzas = pizzas;
            this.orders = orders;
        }
        public void Sort(string sortBy = "name")
        {
            for (int i = 0; i < Pizza.GetCount() - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < Pizza.GetCount(); j++)
                {
                    if (pizzas[min].CompareTo(pizzas[j], sortBy) > 0)
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    Swap(min, i);
                }
            }
        }
        // public void Sort(){
        //     Sort("Name");
        // }
        public string GetMenuChoice()
        {
            Console.WriteLine("Welcome to the Pappa's Pizzeria!");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Customer Menu");
            Console.WriteLine("2. Manager Menu");
            Console.WriteLine("3. Exit");
            return Console.ReadLine();
        }
        private void Swap(int x, int y)
        {
            Pizza temp = pizzas[x];
            pizzas[x] = pizzas[y];
            pizzas[y] = temp;
        }
        public int FindPizza(string pizzaID)
        { // sequential search
            for (int i = 0; i < Pizza.GetCount(); i++)
            {
                if (pizzas[i].GetPizzaID() == pizzaID)
                {
                    return i;
                }
            }
            return -1;
        }
        public int FindOrder(string orderID){
            for (int i = 0; i < Order.GetCount(); i++){
                if (orders[i].GetOrderID() == orderID){
                    return i;
                }
            }
            return -1;
        }
        // public int FastFindPizza(string pizzaID){
        //     int first = 0;
        // }
        public void UpdatePizza()
        {
            System.Console.WriteLine("Enter the pizza ID of the pizza you want to update: ");
            string pizzaID = Console.ReadLine();
            int index = FindPizza(pizzaID);
            System.Console.WriteLine(index);
            if (index >= 0)
            {
                UpdatePizzaToppings(pizzas[index]);
            }
        }
        public void ViewAllPizzas()
        {
            for (int i = 0; i < Pizza.GetCount(); i++)
            {
                Console.WriteLine(pizzas[i].ToString());
            }
        }

        private void UpdatePizzaToppings(Pizza pizza)
        {
            System.Console.WriteLine("Enter the new toppings for the pizza: ");
            pizza.SetCountOfToppings(Console.ReadLine());
            
        }
        public void PrintAllOrders()
        {
            for (int i = 0; i < Order.GetCount(); i++)
            {
                Console.WriteLine(orders[i].ToString());
            }
        }
         public void ViewAvailablePizzas(Pizza[] pizzas)
        {
            Console.WriteLine("Available Pizzas:");
            for (int i = 0; i < Pizza.GetCount(); i++)
            {
                if (pizzas[i].GetIsOnMenu() == true)
                {
                    Console.WriteLine(pizzas[i].ToString());
                }


            }
        }
    }
}