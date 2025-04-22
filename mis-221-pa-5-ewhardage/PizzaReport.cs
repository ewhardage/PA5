using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_ewhardage
{
    public class PizzaReport
    {
        private Pizza[] pizzas;

        public PizzaReport(Pizza[] pizzas)
        {
            this.pizzas = pizzas;
        }
        public void PrintAllPizzas()
        {
            for (int i = 0; i < Pizza.GetCount(); i++)
            {
                Console.WriteLine(pizzas[i].ToString());
            }
        }
        public void AveragePriceByPizzaName()
        {
            string curr = pizzas[0].GetPizzaName();
            double total = pizzas[0].GetPrice();
            int nameCount = 1;
            for (int i = 1; i < Pizza.GetCount(); i++)
            {
                if (curr == pizzas[i].GetPizzaName())
                {
                    total += pizzas[i].GetPrice();
                    nameCount++;
                }
                else
                {
                    ProcessBreak(ref curr, ref total, ref nameCount, i);
                }
            }
            ProcessBreak(curr, total, nameCount);

        }
        private void ProcessBreak(ref string curr, ref double total, ref int nameCount, int i)
        {
            System.Console.WriteLine($"{curr}\t{total / nameCount}");
            //
            curr = pizzas[i].GetPizzaName();
            total = pizzas[i].GetPrice();
            nameCount = 1;
        }
        private void ProcessBreak(string curr, double total, int nameCount)
        {
            System.Console.WriteLine($"{curr}\t{total / nameCount}");
        }
    }
    public class OrderReport{
        private Order[] orders;

        public OrderReport(Order[] orders){
            this.orders = orders;
        }
        public void PrintAllOrders(){
            for (int i = 0; i < Order.GetCount(); i++){
                Console.WriteLine(orders[i].ToString());
            }
        }
        public void PrintAllOrdersByEmail(){
            string curr = orders[0].GetCustomerEmail();
            for (int i = 0; i < Order.GetCount(); i++){
                if(curr == orders[i].GetCustomerEmail()){
                    Console.WriteLine(orders[i].ToString());
                }
            }
    }
}
}