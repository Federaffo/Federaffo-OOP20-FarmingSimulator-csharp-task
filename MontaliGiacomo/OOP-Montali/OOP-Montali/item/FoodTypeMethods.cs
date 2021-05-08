using Farming_simulator;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Montali
{
    static class FoodTypeMethods
    {
        public static double GetQuantity(FoodType f)
        {
            switch (f)
            {
                case FoodType.PORK_MEAT:
                    return 1;
                case FoodType.EGG:
                    return 1;
                case FoodType.MILK:
                    return 1;
                case FoodType.WHEAT:
                    return 3;
                case FoodType.CARROT:
                    return 3;
                case FoodType.POTATO:
                    return 3;
                case FoodType.TOMATO:
                    return 3;
                case FoodType.APPLE:
                    return 4;
                case FoodType.ORANGE:
                    return 4;
                case FoodType.CHERRY:
                    return 4;
                default:
                    return 0;
            }
        }

        public static List<FoodType> GetValues()
        {
            return new List<FoodType> { FoodType.PORK_MEAT, FoodType.EGG, FoodType.MILK,
                FoodType.WHEAT, FoodType.CARROT, FoodType.POTATO, FoodType.TOMATO,
                FoodType.APPLE, FoodType.ORANGE, FoodType.CHERRY };
        }
    }
}
