using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace mis_221_pa_5_ewhardage
{
    public class PizzaFile
    {

        private Pizza[] pizzas;


        public PizzaFile(Pizza[] pizzas)
        {
            this.pizzas = pizzas;
        }
        public void GetAllPizzas()
        {
            Pizza.SetCount(0);
            StreamReader inFile = new StreamReader("pizza-menu.txt");
            string line = inFile.ReadLine();
            while (line != null)
            {
                string[] temp = line.Split('#');
                pizzas[Pizza.GetCount()] = new Pizza(
                    temp[0],  // pizzaID
                    temp[1],  // pizzaName
                    temp[2],  // countOfToppings
                    temp[3],  // crustType
                    double.Parse(temp[4]),  // price
                    bool.Parse(temp[5]),  // isSoldOut
                    bool.Parse(temp[6])  // isOnMenu
                );
                Pizza.IncCount();
                line = inFile.ReadLine();
            }
            inFile.Close();
        }
        public void SaveAllPizzas()
        {
            StreamWriter outFile = new StreamWriter("pizza-menu.txt");
            for (int i = 0; i < Pizza.GetCount(); i++)
            {
                outFile.WriteLine(pizzas[i].ToFile());
            }
            outFile.Close();
        }
        public void ClearPizzas()
        {
            StreamWriter outFile = new StreamWriter("pizza-menu.txt");
            outFile.WriteLine("");
            outFile.Close();
            for (int i = 0; i < Pizza.GetCount(); i++)
            {
                pizzas[i] = null;
            }
            Pizza.SetCount(0);
        }
    }
    public class OrderFile
    {
        private Order[] orders;
        public OrderFile(Order[] orders)
        {
            this.orders = orders;
        }
        public void GetAllOrders()
        {
            Order.SetCount(0);
            StreamReader inFile = new StreamReader("orders.txt");
            string line = inFile.ReadLine();
            while (line != null)
            {
                string[] temp = line.Split('#');
                orders[Order.GetCount()] = new Order(
                    temp[0], temp[1], temp[2], temp[3], int.Parse(temp[4]), temp[5], bool.Parse(temp[6])
                    );
                Order.IncCount();
                line = inFile.ReadLine();
            }
            inFile.Close();
        }
        public void SaveAllOrders()
        {
            StreamWriter outFile = new StreamWriter("orders.txt");
            for (int i = 0; i < Order.GetCount(); i++)
            {
                outFile.WriteLine(orders[i].ToFile());
            }
            outFile.Close();

        }
        public void ClearOrders()
        {
            StreamWriter outFile = new StreamWriter("orders.txt");
            outFile.WriteLine("");
            outFile.Close();
            for (int i = 0; i < Order.GetCount(); i++)
            {
                orders[i] = null;
            }
            Order.SetCount(0);
        }

    }
    public class FroyoFile
    {
        private Froyo[] froyos;
        public FroyoFile(Froyo[] froyos)
        {
            this.froyos = froyos;
        }
        public void GetAllFroyoOrders()
        {
            FroyoOrder.SetCount(0);
            StreamReader inFile = new StreamReader("froyo-orders.txt");
            string line = inFile.ReadLine();



        }
        public void SaveAllFroyoOrders()
        {
            StreamWriter outFile = new StreamWriter("froyo-orders.txt");
            for (int i = 0; i < FroyoOrder.GetCount(); i++)
            {
                outFile.WriteLine(froyos[i].ToFile());
            }
            outFile.Close();
        }
        public void ClearFroyoOrders()
        {
            StreamWriter outFile = new StreamWriter("froyo-orders.txt");
            outFile.WriteLine("");
            outFile.Close();
            for (int i = 0; i < FroyoOrder.GetCount(); i++)
            {
                froyos[i] = null;
            }
            FroyoOrder.SetCount(0);
        }
        
    }
}