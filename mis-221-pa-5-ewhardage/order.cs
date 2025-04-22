using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_ewhardage
{
    public class Order
    {
        private string orderID;
        private string customerEmail;
        private string pizzaID;
        private string orderDate;
        private int size;
        private string crustType;
        private bool orderStatus;
        public Order(){}
        public Order(string orderID, string customerEmail, string pizzaID, string orderDate, int     size, string crustType, bool orderStatus){
            this.orderID = Order.GetCount().ToString();
            this.customerEmail = customerEmail;
            this.pizzaID = pizzaID;
            this.orderDate = orderDate;
            this.size = size;
            this.crustType = crustType;
            this.orderStatus = orderStatus;
        }
        public string GetOrderID(){
            return orderID;                 
        }
        public void SetOrderID(string orderID){
            this.orderID = orderID;
        }
        public string GetCustomerEmail(){
            return customerEmail;
        }
        public void SetCustomerEmail(string customerEmail){
            this.customerEmail = customerEmail;
        }
        public string GetPizzaID(){
            return pizzaID;
        }
        public void SetPizzaID(string pizzaID){
            this.pizzaID = pizzaID;
        }
        public string GetOrderDate(){
            return orderDate;
        }
        public void SetOrderDate(string orderDate){
            this.orderDate = orderDate;
        }   
        public int GetSize(){
            return size;
        }
        public void SetSize(int size){
            this.size = size;
        }
        public bool GetOrderStatus(){
            return orderStatus;
        }
        public void SetOrderStatus(bool orderStatus){
            this.orderStatus = orderStatus;
        }   
        public string GetCrustType(){
            return crustType;
        }
        public void SetCrustType(string crustType){
            this.crustType = crustType;
        }
        static private int count;
        public static int GetCount(){
            return count;
        }
        public static void SetCount(int count){
            Order.count = count;
        }
        public static void IncCount(){
            count++;
        }   

        public override string ToString(){
            return $"Order ID: {orderID}\tCustomer Email: {customerEmail}\tPizza ID: {pizzaID}\tOrder Date: {orderDate}\tSize: {size}\tCrust Type: {crustType}\tOrder Complete: {orderStatus}";
        }
        public string ToFile(){
            return $"{orderID}#{customerEmail}#{pizzaID}#{orderDate}#{size}#{crustType}#{orderStatus}";
        }
        
    }
    public class FroyoOrder{
        private string orderID;
        private string customerEmail;
        private string froyoFlavor;
        private string froyoSize;
        private string orderDate;
        private double froyoPrice;
        private Toppings toppings;
        private bool isSoldOut;
        private bool isOnMenu;
            public FroyoOrder(){}
        public FroyoOrder(string orderID, string customerEmail, string froyoFlavor, string froyoSize, string orderDate, double froyoPrice, bool isSoldOut, bool isOnMenu){
            this.orderID = orderID;
            this.customerEmail = customerEmail;
            this.froyoFlavor = froyoFlavor;
            this.froyoSize = froyoSize;
            this.orderDate = orderDate;
            this.froyoPrice = froyoPrice;
            this.isSoldOut = isSoldOut;
            this.isOnMenu = isOnMenu;   
        }
        public string GetOrderID(){
            return orderID;
        }
        public void SetOrderID(string orderID){ 
            this.orderID = orderID;
        }
        public string GetCustomerEmail(){
            return customerEmail;
        }
        public void SetCustomerEmail(string customerEmail){ 
            this.customerEmail = customerEmail;
        }
        public string GetFroyoFlavor(){
            return froyoFlavor;
        }
        public void SetFroyoFlavor(string froyoFlavor){     
            this.froyoFlavor = froyoFlavor;
        }
        public string GetFroyoSize(){
            return froyoSize;
        }
        public void SetFroyoSize(string froyoSize){ 
            this.froyoSize = froyoSize;
        }
        public double GetFroyoPrice(){
            return froyoPrice;
        }
        public void SetFroyoPrice(double froyoPrice){   
            this.froyoPrice = froyoPrice;
        }
        public bool GetIsSoldOut(){
            return isSoldOut;
        }
        public void SetIsSoldOut(bool isSoldOut){   
            this.isSoldOut = isSoldOut;
        }
        public bool GetIsOnMenu(){
            return isOnMenu;
        }
        public void SetIsOnMenu(bool isOnMenu){ 
            this.isOnMenu = isOnMenu;
        }
        public Toppings GetToppings(){
            return toppings;
        }
        public void SetToppings(Toppings toppings){ 
            this.toppings = toppings;
        }
        public string GetOrderDate(){
            return orderDate;
        }
        public void SetOrderDate(string orderDate){ 
            this.orderDate = orderDate;
        }
        static private int count;
        public static int GetCount(){
            return count;
        }
        public static void SetCount(int count){
            FroyoOrder.count = count;
        }
        public static void IncCount(){
            count++;
        }
        public override string ToString(){
            string toppingsString = "";
            if (toppings.GetHasStrawberries()) toppingsString += "Strawberries,";
            if (toppings.GetHasSprinkles()) toppingsString += "Sprinkles,";
            if (toppings.GetHasChocolate()) toppingsString += "Chocolate,";
            if (toppings.GetHasCaramel()) toppingsString += "Caramel,";
            if (toppings.GetHasNuts()) toppingsString += "Nuts,";
            if (toppings.GetHasGummyBears()) toppingsString += "GummyBears,";
            if (toppings.GetHasMAndMs()) toppingsString += "M&Ms,";
            if (toppings.GetHasReeses()) toppingsString += "Reeses,";
            if (toppings.GetHasOreos()) toppingsString += "Oreos,";
            if (toppings.GetHasChocolateChips()) toppingsString += "ChocolateChips,";
            if (toppings.GetHasWhippedCream()) toppingsString += "WhippedCream,";
            if (toppings.GetHasCherries()) toppingsString += "Cherries,";   
            return $"Order ID: {orderID}\tCustomer Email: {customerEmail}\tFroyo Flavor: {froyoFlavor}\tToppings: {toppingsString}\tFroyo Size: {froyoSize}\tOrder Date: {orderDate}\tFroyo Price: {froyoPrice}\tIs Sold Out: {isSoldOut}\tIs On Menu: {isOnMenu}";
        }
        public string ToFile(){
            string toppingsString = "";
            if (toppings.GetHasStrawberries()) toppingsString += "Strawberries,";
            if (toppings.GetHasSprinkles()) toppingsString += "Sprinkles,";
            if (toppings.GetHasChocolate()) toppingsString += "Chocolate,";
            if (toppings.GetHasCaramel()) toppingsString += "Caramel,";
            if (toppings.GetHasNuts()) toppingsString += "Nuts,";
            if (toppings.GetHasGummyBears()) toppingsString += "GummyBears,";
            if (toppings.GetHasMAndMs()) toppingsString += "M&Ms,";
            if (toppings.GetHasReeses()) toppingsString += "Reeses,";
            if (toppings.GetHasOreos()) toppingsString += "Oreos,";
            if (toppings.GetHasChocolateChips()) toppingsString += "ChocolateChips,";
            if (toppings.GetHasWhippedCream()) toppingsString += "WhippedCream,";
            if (toppings.GetHasCherries()) toppingsString += "Cherries,";            
            return $"{orderID}#{customerEmail}#{froyoFlavor}#{toppingsString}#{froyoSize}#{orderDate}#{froyoPrice}#{isSoldOut}#{isOnMenu}";
        }
    }
}