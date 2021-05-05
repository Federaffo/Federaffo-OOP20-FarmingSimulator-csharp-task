using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Fabbri.util
{
    interface Seed
    {
        void Grow();
        FoodType Harvest();
        double GetGrowTime();
        FoodType GetFoodType();
        SeedType GetSeedType();
        SeedState GetSeedState();
    }
}
