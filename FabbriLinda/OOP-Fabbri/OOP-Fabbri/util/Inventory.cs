using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Fabbri.util
{
    interface Inventory
    {
        void AddSeeds(SeedType type, int number);
        void AddFoods(FoodType type, int number);
        void RemoveSeed(SeedType type);
        void RemoveFood(FoodType type);
        Dictionary<SeedType, int> GetSeeds();
        Dictionary<FoodType, int> GetFoods();
        void RemoveAllFood();
        Optional<Pair<SeedType, int>> getCurrentSeed();

    }
}
