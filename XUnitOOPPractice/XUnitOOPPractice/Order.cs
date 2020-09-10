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
        private List<MenuItem> Items { get; set; }
        
        public int ItemCount => Items.Count;

        public double Total => Items.Select(x => x.Price).Sum();

        public void AddItem(MenuItem toAdd)
        {
            // Refactoring idea courtesy of Damir.
            Items.Add(toAdd);

            // If we have 3 distinct types of food...
            if (Items.Where(x => x.GetType() == typeof(FoodItem)).Select(x => ((FoodItem)x).Type).Distinct().Count() == 3)
            {
                // Select the first of each type of food.
                FoodItem chicken = (FoodItem)Items.Where(x => x.GetType() == typeof(FoodItem) && ((FoodItem)x).Type == FoodItem.TypeValue.ChickenStrips).First();
                FoodItem drink = (FoodItem)Items.Where(x => x.GetType() == typeof(FoodItem) && ((FoodItem)x).Type == FoodItem.TypeValue.Drink).First(); ;
                FoodItem fries = (FoodItem)Items.Where(x => x.GetType() == typeof(FoodItem) && ((FoodItem)x).Type == FoodItem.TypeValue.FrenchFries).First();

                /*
                --- Cast the result of everything following this to a FoodItem (otherwise it returns a MenuItem). ---
                (FoodItem)
                --- Operating on the Items list ---
                Items
                --- Using Where to filter things out ---
                .Where(
                    --- Filtering out non-FoodItems (Combos), this needs to first because otherwise we will be trying to potentially cast Combos as FoodItems and it will not be happy ---
                    x => x.GetType() == typeof(FoodItem) &&
                    --- AND Filtering out non-FrenchFries FoodItems ---
                    ((FoodItem)x).Type == FoodItem.TypeValue.FrenchFries
                    )
                --- Get the first item that is returned from the Where ---
                .First()
                */


                // Build the combo.
                Combo newCombo = new Combo()
                {
                    ComboItems = new List<FoodItem>() { chicken, fries, drink }
                };

                // Remove the combo items from the Items list.
                Items = Items.Except(newCombo.ComboItems).ToList();

                // Add the combo to the list.
                Items.Add(newCombo);
            }
        }

        public void RemoveItem()
        {
            // Removes the last items in the list (most recent addition, assuming you don't sort the list).
            Items.RemoveAt(Items.Count - 1);
        }

        public Order()
        {
            Items = new List<MenuItem>();
        }


    }
}
