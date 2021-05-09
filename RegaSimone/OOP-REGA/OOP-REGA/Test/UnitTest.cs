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
        public void CorrectFoodList()
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

        [Test]
        public void CorrectSeedList()
        {
            var test = s.GetSeedItemList();
            Assert.True(test.Contains(SeedType.APPLE_SEED));
            Assert.True(test.Contains(SeedType.CARROT_SEED));
            Assert.True(test.Contains(SeedType.CHERRY_SEED));
            Assert.True(test.Contains(SeedType.ORANGE_SEED));
            Assert.True(test.Contains(SeedType.POTATO_SEED));
            Assert.True(test.Contains(SeedType.TOMATO_SEED));
            Assert.True(test.Contains(SeedType.WHEAT_SEED));
        }

        [Test]
        public void BuySeedTest()
        {
            Seed seed  = s.buy(SeedType.APPLE_SEED);

            Assert.AreEqual(seed, new SeedImpl(SeedType.APPLE_SEED));
        }

        [Test]
        public void SellFoodTest()
        {
            double wallet = 0;
            for(int i =0; i < 10; i ++)
            {
                wallet += s.sell(FoodType.APPLE);
            }
            Assert.AreEqual(wallet,1000);
        }

        [Test]
        public void SellAllFoodTest()
        {
            Dictionary<FoodType, int> foodToSell = new Dictionary<FoodType, int>();
            foodToSell.Add(FoodType.APPLE, 10);
            foodToSell.Add(FoodType.CARROT, 10);
            foodToSell.Add(FoodType.POTATO, 10);

            double wallet = s.sellAll(foodToSell);

            Assert.AreEqual(wallet, 1350);
        }
    }
}