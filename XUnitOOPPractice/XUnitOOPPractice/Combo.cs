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
        public override double Price { get; set; }
        //private List<FoodItem> ComboItems { get; set; }
        public List<FoodItem> ComboItems { 
            get
            {
                return ComboItems;
            }
            set
            {
                double newPrice= ComboItems.Select(x => x.Price).Sum();
                double newPricing = newPrice - 0.20;
                
            }
            
        }

        public Combo()
        {
            ComboItems = new List<FoodItem>();
        }


    }
}
