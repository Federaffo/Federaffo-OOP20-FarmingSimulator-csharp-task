using Farming_simulator;
using NUnit.Framework;
using OOP_Montali.entity;
using OOP_Montali.map;
using System.Collections.Generic;

namespace OOP_Montali
{
    public class Tests
    {
        private Map mappa;
        private List<Animal> animals;
        private Player player;

        [SetUp]
        public void Setup()
        {
            mappa = new MapImpl();

            animals = new List<Animal>();
            FactoryAnimal f = new FactoryAnimal();
            player = new PlayerImpl(new Pair<int, int>(10, 10));

            animals.Add(f.GetPig(new Pair<int, int>(5,5)));
            animals.Add(f.GetChicken(new Pair<int, int>(5, 5)));
            animals.Add(f.GetCow(new Pair<int, int>(5, 5)));
        }

        [Test]
        public void AnimalCreationTest()
        {
            animals[0].Move();
            Assert.True(animals[0].GetPosX() == 5 && animals[0].GetPosY() == 5);
        }

        [Test]
        public void AnimalRandomMovementTest()
        {
            int x = animals[1].GetPosX();
            int y = animals[1].GetPosY();

            animals[1].SetRight(true);

            for (int i=0; i<10; i++)
                animals[1].Move();

            Assert.False(animals[1].GetPosX() == x && animals[1].GetPosY() == y);
        }

        [Test]
        public void PLayerMoneyTest()
        {
            Assert.True(player.GetMoney() == 0);
            player.IncrementMoney(100);
            Assert.True(player.GetMoney() == 100);
            player.DecreaseMoney(50);
            Assert.True(player.GetMoney() == 50);
        }

        [Test]
        public void PlayerInventoryTest()
        {
            Assert.False(player.GetInventory().GotSeeds(SeedType.CARROT_SEED, 1));
            Assert.False(player.GetInventory().GotSeeds(SeedType.APPLE_SEED, 1));

            player.GetInventory().AddSeeds(SeedType.CARROT_SEED, 10);
            Assert.True(player.GetInventory().GotSeeds(SeedType.CARROT_SEED, 10));
        }

        [Test]
        public void MapBorderTest()
        {
            Assert.AreEqual(mappa.GetBlock(new Pair<int, int>(0,0)).GetType(), BlockType.WALL);
        }
    }
}