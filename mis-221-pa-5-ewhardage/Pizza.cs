using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_ewhardage
{
    public class Pizza
    {
        private string pizzaID;
        private string pizzaName;
        private string countOfToppings;
        private string crustType;
        private double price;
        private bool isSoldOut;
        private bool isOnMenu;
        static private int count;
        public Pizza(){}
        public Pizza(string pizzaID, string pizzaName, string countOfToppings, string crustType, double price, bool isSoldOut, bool isOnMenu)
        {
            this.pizzaID = pizzaID;
            this.pizzaName = pizzaName;
            this.countOfToppings = countOfToppings;
            this.crustType = crustType;
            this.price = price;
            this.isSoldOut = isSoldOut;
            this.isOnMenu = isOnMenu;
        }

        public string GetPizzaID()
        {
            return pizzaID;
        }
        public void SetPizzaID(string pizzaID)
        {
            this.pizzaID = pizzaID;
        }
        public string GetPizzaName()
        {
            return pizzaName;
        }
        public void SetPizzaName(string pizzaName)
        {
            this.pizzaName = pizzaName;
        }
        public string GetCountOfToppings()
        {
            return countOfToppings;
        }
        public void SetCountOfToppings(string countOfToppings)
        {
            this.countOfToppings = countOfToppings;
        }
        public string GetCrustType()
        {
            return crustType;
        }
        public void SetCrustType(string crustType)
        {
            this.crustType = crustType;
        }
        public double GetPrice()
        {
            return price;
        }
        public void SetPrice(double price)
        {
            this.price = price;
        }
        public bool GetIsSoldOut()
        {
            return isSoldOut;
        }
        public void SetIsSoldOut(bool isSoldOut)
        {
            this.isSoldOut = isSoldOut;
        }
        public bool GetIsOnMenu()
        {
            return isOnMenu;
        }
        public void SetIsOnMenu(bool isOnMenu)
        {
            this.isOnMenu = isOnMenu;
        }
        static public void IncCount()
        {
            count++;
        }
        public override string ToString()
        {
            return $"Pizza ID: {pizzaID}\tName: {pizzaName}\tToppings: {countOfToppings}\tCrust: {crustType}\tPrice: {price}\tSold Out: {isSoldOut}\tOn Menu: {isOnMenu}";
        }
        public  int CompareTo(Pizza pizza, string sortBy)
        {
            if (sortBy.ToUpper() == "NAME")
            {
                return this.pizzaName.CompareTo(pizza.GetPizzaName());
            }
            return this.price.CompareTo(pizza.price);
        }
        static public int GetCount()
        {
            return count;
        }
        static public void SetCount(int count)
        {
            Pizza.count = count;
        }
        static public void IncPizzaCount()
        {
            count++;
        }
         public string ToFile()
        {
            return $"{pizzaID}#{pizzaName}#{countOfToppings}#{crustType}#{price}#{isSoldOut}#{isOnMenu}";
        }

    }

}