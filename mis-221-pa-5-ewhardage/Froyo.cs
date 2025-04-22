using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_ewhardage
{
    public class Toppings
    {
        private bool hasStrawberries;
        private bool hasSprinkles;
        private bool hasChocolate;
        private bool hasCaramel;
        private bool hasNuts;
        private bool hasGummyBears;
        private bool hasMAndMs;
        private bool hasReeses;
        private bool hasOreos;
        private bool hasChocolateChips;
        private bool hasWhippedCream;
        private bool hasCherries;
        public Toppings(){}
        public Toppings(bool hasStrawberries, bool hasSprinkles, bool hasChocolate, bool hasCaramel, bool hasNuts, bool hasGummyBears, bool hasMAndMs, bool hasReeses, bool hasOreos, bool hasChocolateChips, bool hasWhippedCream, bool hasCherries)
        {
            this.hasStrawberries = hasStrawberries;
            this.hasSprinkles = hasSprinkles;
            this.hasChocolate = hasChocolate;
            this.hasCaramel = hasCaramel;
        }
        public bool GetHasStrawberries()
        {
            return hasStrawberries;
        }
        public bool SetHasStrawberries(bool hasStrawberries)
        {
            this.hasStrawberries = hasStrawberries;
            return true;
        }
        public bool GetHasSprinkles()
        {
            return hasSprinkles;
        }
        public bool SetHasSprinkles(bool hasSprinkles)
        {
            this.hasSprinkles = hasSprinkles;
            return true;
        }
        public bool GetHasChocolate()
        {
            return hasChocolate;
        }
        public bool SetHasChocolate(bool hasChocolate)
        {
            this.hasChocolate = hasChocolate;
            return true;
        }
        public bool GetHasCaramel()
        {
            return hasCaramel;  
        }
        public bool SetHasCaramel(bool hasCaramel)
        {
            this.hasCaramel = hasCaramel;
            return true;
        }
        public bool GetHasNuts()
        {
            return hasNuts;
        }
        public bool SetHasNuts(bool hasNuts)    
        {
            this.hasNuts = hasNuts;
            return true;
        }
        public bool GetHasGummyBears()          
        {
            return hasGummyBears;
        }
        public bool SetHasGummyBears(bool hasGummyBears)
        {
            this.hasGummyBears = hasGummyBears;
            return true;
        }
        public bool GetHasMAndMs()
        {
            return hasMAndMs;
        }
        public bool SetHasMAndMs(bool hasMAndMs)
        {
            this.hasMAndMs = hasMAndMs;
            return true;
        }
        public bool GetHasReeses()  
        {
            return hasReeses;
        }
        public bool SetHasReeses(bool hasReeses)
        {
            this.hasReeses = hasReeses;
            return true;
        }
        public bool GetHasOreos()
        {
            return hasOreos;
        }
        public bool SetHasOreos(bool hasOreos)
        {
            this.hasOreos = hasOreos;
            return true;
        }
        public bool GetHasChocolateChips()
        {
            return hasChocolateChips;
        }
        public bool SetHasChocolateChips(bool hasChocolateChips)
        {
            this.hasChocolateChips = hasChocolateChips;
            return true;
        }
        public bool GetHasWhippedCream()
        {
            return hasWhippedCream;
        }
        public bool SetHasWhippedCream(bool hasWhippedCream)
        {
            this.hasWhippedCream = hasWhippedCream;
            return true;
        }
        public bool GetHasCherries()
        {
            return hasCherries;
        }
        public bool SetHasCherries(bool hasCherries)
        {
            this.hasCherries = hasCherries;
            return true;
        }
    }
    public class Froyo
    {
       private string froyoFlavor;
       private string froyoSize;
       private Toppings Toppings;
       private double froyoPrice;
       private bool isSoldOut;
       private bool isOnMenu;
       static private int count;
       public Froyo(){}
       public Froyo(string froyoFlavor, string froyoSize, Toppings Toppings, double froyoPrice, bool isSoldOut, bool isOnMenu)
       {
        this.froyoFlavor = froyoFlavor;
        this.froyoSize = froyoSize;
        this.Toppings = Toppings;
        this.froyoPrice = CalculatePrice();
        this.isSoldOut = isSoldOut;
        this.isOnMenu = isOnMenu;
       }
       public string GetFroyoFlavor()
       {
        return froyoFlavor;
       }
       public void SetFroyoFlavor(string froyoFlavor)
       {
        this.froyoFlavor = froyoFlavor;
       }
       public string GetFroyoSize()
       {
        return froyoSize;
       }
       public void SetFroyoSize(string froyoSize)
       {
        this.froyoSize = froyoSize;
        this.froyoPrice = CalculatePrice(); // Recalculate price when size changes
       }
       public Toppings GetToppings()
       {
        return Toppings;
       }
       public void SetToppings(Toppings Toppings)
       {
        this.Toppings = Toppings;
        this.froyoPrice = CalculatePrice(); // Recalculate price when toppings change
       }
       public double GetFroyoPrice()
       {
        return froyoPrice;
       }
       public double CalculatePrice()
       {
            double basePrice = 0;
            switch(froyoSize.ToLower())
            {
                case "small":
                    basePrice = 6.00;
                    break;
                case "medium":
                    basePrice = 8.00;
                    break;
                case "large":
                    basePrice = 10.00;
                    break;
            }

            int toppingCount = 0;
            if(Toppings.GetHasStrawberries()) toppingCount++;
            if(Toppings.GetHasSprinkles()) toppingCount++;
            if(Toppings.GetHasChocolate()) toppingCount++;
            if(Toppings.GetHasCaramel()) toppingCount++;
            if(Toppings.GetHasNuts()) toppingCount++;
            if(Toppings.GetHasGummyBears()) toppingCount++;
            if(Toppings.GetHasMAndMs()) toppingCount++;
            if(Toppings.GetHasReeses()) toppingCount++;
            if(Toppings.GetHasOreos()) toppingCount++;
            if(Toppings.GetHasChocolateChips()) toppingCount++;
            if(Toppings.GetHasWhippedCream()) toppingCount++;
            return basePrice + (toppingCount * 0.50);
       }
       public void SetFroyoPrice(double froyoPrice)
       {
        this.froyoPrice = froyoPrice;
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
       static public int GetCount()
       {
        return count;
       }
       static public void SetCount(int count)
       {
        Froyo.count = count;
       }
       static public void IncFroyoCount()
       {
        Froyo.count++;
       }
       public string ToFile(){
        return $"{froyoFlavor}#{froyoSize}#{Toppings}#{froyoPrice}#{isSoldOut}#{isOnMenu}";
       }
       
    }
}