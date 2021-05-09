using Farming_simulator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OOP_Montali
{
    public class PlayerImpl : EntityImpl, Player
    {

        private double money;
        private Inventory bag;

        public PlayerImpl(Pair<int, int> position) : base(position)
        {
            SPEED = 5;
            bag = new InventoryImpl();
        }

        public void IncrementMoney(double moneyToAdd)
        {
            money += moneyToAdd;
        }

        public void DecreaseMoney(double moneyToRemove)
        {
            money -= moneyToRemove;
        }

        public double GetMoney()
        {
            return money;
        }

        public Inventory GetInventory()
        {
            return bag;
        }

        public Animal NearestAnimal(List<Animal> animals)
        {
            float area = 0;
            Animal animalChoosen = null;

            foreach (Animal animal in animals)
            {
                Rectangle temp = new Rectangle(border.Location, border.Size);
                temp.Intersect(animal.GetRectangle());
                float tempArea = temp.Width * temp.Height;

                if (tempArea > area && temp.Width > 0 && temp.Height > 0)
                {
                    animalChoosen = animal;
                    area = tempArea;
                }
            }

            return animalChoosen;
        }
    }
}