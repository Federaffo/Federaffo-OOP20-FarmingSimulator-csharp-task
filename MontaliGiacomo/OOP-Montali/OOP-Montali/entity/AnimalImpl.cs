using OOP_Montali;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Farming_simulator
{
    public class AnimalImpl : EntityImpl, Animal
    {
        private AnimalType type;
        private long readyTime;
        private bool readyState;
        private Random rnd;
        private Timer timer;

        public AnimalImpl(Pair<int, int> position, AnimalType animalType) : base(position)
        {
            type = animalType;
            SPEED = AnimalTypeMethods.GetSpeed(type);
            readyTime = AnimalTypeMethods.ReadyTime(type);
            rnd = new Random();
            readyState = false;
            ReSchedule();
            SetDirectionFalse();
        }

        public async Task BeginTimer()
        {
            int seconds = (int)AnimalTypeMethods.ReadyTime(type);
            while (readyState == false)
            {
                await Task.Delay(seconds * 1000);
                Ready();
            }
        }

        private void Ready()
        {
            readyState = true;
        }

        public async Task<Pair<FoodType, int>> Collect()
        {
            readyState = false;
            await BeginTimer();
            FoodType returnFood = AnimalTypeMethods.GetReturnFood(type);
            return new Pair<FoodType, int>(returnFood, (int)FoodTypeMethods.GetQuantity(returnFood));
        }

        private async void ReSchedule()
        {
            await BeginTimer();
        }

        private void SetDirectionFalse()
        {
            SetUp(false);
            SetDown(false);
            SetLeft(false);
            SetRight(false);
        }

        private void SetRandomDirection()
        {

            if (readyState)
            {
                SetDirectionFalse();
            }
            else
            {

                int x = rnd.Next(100);

                if (x <= 5 && x >= 0)
                {
                    SetUp(rnd.Next(2) == 0);
                    SetDown(rnd.Next(2) == 0);
                    SetLeft(rnd.Next(2) == 0);
                    SetRight(rnd.Next(2) == 0);
                }
            }

        }

        public void RandomMove(HashSet<Block> map)
        {
            SetRandomDirection();
            Move();
            CheckCollision(map, x=>x.IsStall());
        }

        public bool IsReady()
        {
            return readyState;
        }

        public AnimalType GetType()
        {
            return type;
        }
    }
}
