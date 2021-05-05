using FarmingSimulator;
using NUnit.Framework;
using System.Collections.Generic;

namespace OOP_REGA
{
    public class Tests
    {
        private Shop s;

        [SetUp]
        public void Setup()
        {
            s = new ShopImpl();
        }

        [Test]
        public void CorrectItemList()
        {
            var test = s.GetFoodItemList();
            Assert.True(test.Contains(FoodType.APPLE));
            Assert.True(test.Contains(FoodType.CARROT));
            Assert.True(test.Contains(FoodType.CHERRY));
            Assert.True(test.Contains(FoodType.EGG));
            Assert.True(test.Contains(FoodType.MILK));
            Assert.True(test.Contains(FoodType.ORANGE));
            Assert.True(test.Contains(FoodType.PORK_MEAT));
            Assert.True(test.Contains(FoodType.POTATO));
            Assert.True(test.Contains(FoodType.TOMATO));
            Assert.True(test.Contains(FoodType.WHEAT));
        }
    }
}