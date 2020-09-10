using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace XUnitOOPPractice
{

    /*
     * Create a public class called Order with the following properties / methods:
        -Items (private polymorphic list)
       - ItemCount (int), a function of the count of the items.
        -AddItem()
            Accepts polymorphic argument and adds it to the list
            If an item is added, and because of that addition there is an instance of each food item (Fries, Chicken Strips and Drink),
            then add all three to a new ComboItem. Remove the items from the Items list, and add the Combo to the Items list.
        -RemoveItem()
            Removes the most recent addition to the Items list, if it’s a combo, remove the whole combo.
        -Total (double), a function of the sum of all of the prices in Items.

     */
    public class Order
    {
        private List<Order> Items { get; set; }
        private List<FoodItem> ComboItems { get; set; }
        public int ItemCount => Items.Count;
        public double Price { get; set; }
        public void AddItem(FoodItem item)
        {

            if (item.GetType() == Type.GetType("FrenchFries") && item.GetType() == Type.GetType("ChickenStrips") && item.GetType() == Type.GetType("Drink"))
            {

                ComboItems.Add(item);
            }          
           
            

        }

        public void RemoveItem(Order Items)
        {
            if (Items.GetType() == typeof(Combo))
            {
                Items.RemoveItem(Items);
            }
        }

        public double Total()
        {
            return Items.Select(x => x.Price).Sum();
        }
    }
}
