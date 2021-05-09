using Farming_simulator;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Montali
{
    static class AnimalTypeMethods
    {
        public static FoodType GetReturnFood(AnimalType t)
        {
            switch (t)
            {
                case AnimalType.CHICKEN:
                    return FoodType.EGG;
                case AnimalType.COW:
                    return FoodType.MILK;
                case AnimalType.PIG:
                    return FoodType.PORK_MEAT;
                default:
                    return 0;
            }
        }

        public static String GetName(AnimalType t)
        {
            switch (t)
            {
                case AnimalType.CHICKEN:
                    return "Chicken";
                case AnimalType.COW:
                    return "Cow";
                case AnimalType.PIG:
                    return "Pig";
                default:
                    return "Animal";
            }
        }

        public static long ReadyTime(AnimalType t)
        {
            switch (t)
            {
                case AnimalType.CHICKEN:
                    return ItemConstants.MEDIUM_GROW_TIME;
                case AnimalType.COW:
                    return ItemConstants.HYPER_LONG_GROW_TIME;
                case AnimalType.PIG:
                    return ItemConstants.VERY_LONG_GROW_TIME;
                default:
                    return 0;
            }
        }

        public static int GetSpeed(AnimalType t)
        {
            switch (t)
            {
                case AnimalType.CHICKEN:
                    return ItemConstants.FAST_SPEED;
                case AnimalType.COW:
                    return ItemConstants.SLOW_SPEED;
                case AnimalType.PIG:
                    return ItemConstants.MEDIUM_SPEED;
                default:
                    return 0;
            }
        }
    }
}
