using System;
using System.Collections.Generic;
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
    public class FoodItem: MenuItem
    {
        public override double Price { get; set; }

        public enum Type
        {
            FrenchFries,
            ChickenStrips,
            Drink
        }
        public Type fooditem { get; set; }
    }
}
