using Farming_simulator;
using System.Collections.Generic;

namespace OOP_Montali
{
    public class InventoryImpl : Inventory
    {
        private Dictionary<SeedType, int> seeds;
        private Dictionary<FoodType, int> foods;
        private List<SeedType> activeSeed;

        public InventoryImpl()
        {
            seeds = new Dictionary<SeedType, int>();
            foods = new Dictionary<FoodType, int>();

            foreach (SeedType s in SeedTypeMethods.GetValues())
            {
                seeds[s] = 0;
            }
            foreach (FoodType f in FoodTypeMethods.GetValues())
            {
                foods[f] = 0;
            }

            activeSeed = new List<SeedType>();
            SeedTypeMethods.GetValues().ForEach(x => activeSeed.Add(x));
        }

        public Optional<Pair<SeedType, int>> NextSeed()
        {
            bool isThereASeed = false;
            MoveBottom(activeSeed[0]);

            foreach (SeedType seedType in activeSeed.ToArray())
            {
                if (seeds[seedType] > 0)
                {
                    MoveTop(seedType);
                    isThereASeed = true;
                    break;
                }
            }

            if (!isThereASeed)
            {
                return Optional<Pair<SeedType, int>>.Empty();
            }
            else
            {
                return Optional<Pair<SeedType, int>>.Of(new Pair<SeedType, int>(activeSeed[0], seeds[activeSeed[0]]));
            }
        }

        public Optional<Pair<SeedType, int>> GetCurrentSeed()
        {
            if (seeds[activeSeed[0]] > 0)
            {
                return Optional<Pair<SeedType, int>>.Of(new Pair<SeedType, int>(activeSeed[0], seeds[activeSeed[0]]));
            }
            else
            {
                return Optional<Pair<SeedType, int>>.Empty();
            }
        }

        private void MoveBottom(SeedType type)
        {
            foreach (SeedType s in activeSeed.ToArray())
            {
                if (s.Equals(type))
                {
                    activeSeed.Remove(s);
                    activeSeed.Add(s);
                }
            }
        }

        private void MoveTop(SeedType type)
        {
            foreach (SeedType seedType in activeSeed.ToArray())
            {
                if (!seedType.Equals(type))
                {
                    MoveBottom(seedType);
                }
            }
        }

        public void AddSeeds(SeedType type, int number)
        {
            seeds[type] += number;
            MoveTop(type);
        }

        public void RemoveSeed(SeedType type)
        {
            seeds[type]--;
            if (seeds[type] == -1)
            {
                throw new System.InvalidOperationException();
            }
        }

        public bool GotSeeds(SeedType type, int number)
        {
            return (seeds[type] >= number);
        }

        public void AddFoods(FoodType type, int number)
        {
            foods[type] += number;
        }

        public void RemoveFood(FoodType type)
        {
            foods[type]--;
        }

        public bool GotFoods(FoodType type, int number)
        {
            return (foods[type] >= number);
        }

        public Dictionary<FoodType, int> GetFoods()
        {
            return this.foods;
        }

        public Dictionary<SeedType, int> GetSeeds()
        {
            return this.seeds;
        }

        public void RemoveAllFood()
        {
            foreach (var element in foods.Keys)
            {
                foods[element] = 0;
            }
        }
    }
}
