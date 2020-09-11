using System;
using Xunit;
using XUnitOOPPractice;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace XUnitOOPPractice_Tests
{

    /*
     * Create unit tests to test the following behaviour:
        Adding a single item of each type to the order (3 facts).
        Add a combo to the order (fact).
        Remove a single item from the order (fact).
        Remove a combo from the order (fact).
        The ComboItem’s Price reflects the sum of the items minus 20% (theory).

     */
    public class Program_Tests
    {
/*
        Create unit tests to test the following behaviour:    
       
*/
        //Adding a single item of each type to the order(3 facts).
        [Fact]
        public void AddItem_Test()
        {
            // Arrange
            Order myOrder = new Order();
            FoodItem foodItem = new FoodItem()
            {
                Type = FoodItem.TypeValue.ChickenStrips,
                Price = 3.50
            };
            // Act
            myOrder.AddItem(foodItem);
            // Assert
            Assert.Contains(foodItem, myOrder.Items);
        }

        [Fact]
        public void AddItem_Test2()
        {
            // Arrange
            Order myOrder = new Order();
            FoodItem foodItem = new FoodItem()
            {
                Type = FoodItem.TypeValue.FrenchFries,
                Price = 2.50
            };
            // Act
            myOrder.AddItem(foodItem);
            // Assert
            Assert.Contains(foodItem, myOrder.Items);
        }
        [Fact]
        public void AddItem_Test3()
        {
            // Arrange
            Order myOrder = new Order();
            FoodItem foodItem = new FoodItem()
            {
                Type = FoodItem.TypeValue.Drink,
                Price = 1.50
            };
            // Act
            myOrder.AddItem(foodItem);
            // Assert
            Assert.Contains(foodItem, myOrder.Items);
        }



        //  Add a Combo to the order(fact).
        [Fact]
        public void AddItem_Test_Combo()
        {
            // Arrange & Act
            Order myOrder = new Order();
            myOrder.AddItem(new FoodItem() { Type = FoodItem.TypeValue.Drink, Price = 1.00 });
            myOrder.AddItem(new FoodItem() { Type = FoodItem.TypeValue.ChickenStrips, Price = 3.00 });
            myOrder.AddItem(new FoodItem() { Type = FoodItem.TypeValue.FrenchFries, Price = 1.50 });
            // Assert
            Assert.Equal(1, myOrder.ItemCount);
        }


        // Remove a single item from the order(fact).


        [Fact]
        public void Remove_Single_Item()
        {
            //Arrange
            Order myOrder = new Order();
            myOrder.AddItem(new FoodItem() { Type = FoodItem.TypeValue.Drink, Price = 1.00 });
            myOrder.AddItem(new FoodItem() { Type = FoodItem.TypeValue.ChickenStrips, Price = 3.00 });
            //Act
            myOrder.RemoveItem();
            //Assert
            Assert.Equal(1, myOrder.ItemCount);
        }


        //Remove a combo from the order(fact).
        [Fact]
        public void Remove_Combo()
        {
            //Arrange
            Order myOrder = new Order();
            myOrder.AddItem(new FoodItem() { Type = FoodItem.TypeValue.Drink, Price = 1.00 });
            myOrder.AddItem(new FoodItem() { Type = FoodItem.TypeValue.ChickenStrips, Price = 3.00 });
            myOrder.AddItem(new FoodItem() { Type = FoodItem.TypeValue.FrenchFries, Price = 1.50 });
            myOrder.AddItem(new FoodItem() { Type = FoodItem.TypeValue.Drink, Price = 1.00 });
            myOrder.AddItem(new FoodItem() { Type = FoodItem.TypeValue.ChickenStrips, Price = 3.00 });
            myOrder.AddItem(new FoodItem() { Type = FoodItem.TypeValue.FrenchFries, Price = 1.50 });
            //Act
            myOrder.RemoveItem();
            //Assert
            Assert.Equal(1, myOrder.ItemCount);
        }


        //The Combo’s Price reflects the sum of the items minus 20% (theory).

        [Theory,
             InlineData(3.45),
             InlineData(4.76),
             InlineData(4.6),
             ]
        public void ComboItems_Price(double price)
        {
            Combo myCombo = new Combo();
            myCombo.Price = price;
                      
        }
    }
}
