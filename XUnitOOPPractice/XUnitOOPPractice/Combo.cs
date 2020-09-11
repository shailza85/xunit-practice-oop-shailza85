using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace XUnitOOPPractice
{
         
          /* Create inherited classes from MenuItem called “FoodItem” and “Combo”
            ComboItem should have a polymorphic list property of FoodItems called “ComboItems”.
            ComboItem’s Price should be a sum of all of the combo Items prices, minus 20%.

            FoodItem’s Price should be a normal double.
            FoodItem should have a “Type” enum of:
            FrenchFries
            ChickenStrips
            Drink
            */

    public class Combo: MenuItem
    {

        public double Discount => 0.8;

        public List<FoodItem> ComboItems { get; set; }

        public override double Price
        {
            get
            {
                // LINQ: Select all of the prices, add them up, then multiple by 0.8 (80%, or 20% off).
                return Math.Round(ComboItems.Select(x => x.Price).Sum() * Discount, 3);
            }
            // The value is derived from ComboItems, so setting the price shouldn't work, but we have to declare it as a consequence of the derived property.
            set { }
        }

        public Combo()
        {
            ComboItems = new List<FoodItem>();
        }


    }
}
