using System;

namespace XUnitOOPPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Order myOrder = new Order();

            Console.WriteLine($"My order consists of {myOrder.ItemCount} items, totalling {myOrder.Total:C}.");
            myOrder.AddItem(new FoodItem() { Type = FoodItem.TypeValue.FrenchFries, Price = 1.50 });
            Console.WriteLine($"My order consists of {myOrder.ItemCount} items, totalling {myOrder.Total:C}.");
            myOrder.AddItem(new FoodItem() { Type = FoodItem.TypeValue.FrenchFries, Price = 1.50 });
            Console.WriteLine($"My order consists of {myOrder.ItemCount} items, totalling {myOrder.Total:C}.");
            myOrder.AddItem(new FoodItem() { Type = FoodItem.TypeValue.ChickenStrips, Price = 3.50 });
            Console.WriteLine($"My order consists of {myOrder.ItemCount} items, totalling {myOrder.Total:C}.");
            myOrder.AddItem(new FoodItem() { Type = FoodItem.TypeValue.Drink, Price = 1.00 });
            Console.WriteLine($"My order consists of {myOrder.ItemCount} items, totalling {myOrder.Total:C}.");
        }
    
    }
}

//@Link: https://github.com/TECHCareers-by-Manpower/4.1-CSharp-XUnit/tree/Sep09Practice/CSharpXUnit
