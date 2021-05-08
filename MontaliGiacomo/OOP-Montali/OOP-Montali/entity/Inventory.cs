using OOP_Montali;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farming_simulator
{
    public interface Inventory
    {
        Optional<Pair<SeedType, int>> NextSeed();

        void AddSeeds(SeedType type, int number);

        void RemoveSeed(SeedType type);

        bool GotSeeds(SeedType type, int number);

        Dictionary<SeedType, int> GetSeeds();

        Optional<Pair<SeedType, int>> GetCurrentSeed();

        void AddFoods(FoodType type, int number);

        void RemoveFood(FoodType type);

        bool GotFoods(FoodType type, int number);

        Dictionary<FoodType, int> GetFoods();

        void RemoveAllFood();
    }
}
