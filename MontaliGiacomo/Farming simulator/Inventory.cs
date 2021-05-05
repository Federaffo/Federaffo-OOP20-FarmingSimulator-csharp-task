using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farming_simulator
{
    interface Inventory
    {
        // MANAGE SEEDS

        /**
         * @return the next seedType as the activeSeed
         */
        Optional<Pair<SeedType, int>> nextSeed();

        /**
         * This method add seeds to inventory.
         * 
         * @param type
         * @param number
         */
        void addSeeds(SeedType type, int number);


        /**
         * This method remove 1 seed from inventory.
         * @param type
         */
        void removeSeed(SeedType type);


        /**
         * @param type
         * @param number
         * @return true if there's seed of the given type and number in the inventory
         */
        bool gotSeeds(SeedType type, int number);


        /**
         * @return map of seeds
         */
        Dictionary<SeedType, int> getSeeds();


        /**
         * @return current seed
         */
        Optional<Pair<SeedType, int>> getCurrentSeed();

        // MANAGE FOODS


        /**
         * This method add foods to inventory.
         * @param type
         * @param number
         */
        void addFoods(FoodType type, int number);


        /**
         * This method remove 1 food from inventory.
         * @param type
         */
        void removeFood(FoodType type);


        /**
         * @param type
         * @param number
         * @return if there's any food of the given type and number in the inventory
         */
        bool gotFoods(FoodType type, int number);


        /**
         * @return map of foods
         */
        Dictionary<FoodType, int> getFoods();


        /**
         * This method remove all the food from inventory.
         */
        void removeAllFood();
    }
}
