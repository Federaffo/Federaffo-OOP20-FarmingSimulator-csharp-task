using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farming_simulator
{
    interface Animal : Entity
    {
        /**
     * @return the food of the animal
     */
        Pair<FoodType, int> collect();

        /**
         * move the animal in a random direction.
         * 
         * @param map
         * 
         */
        void randomMove(HashSet<Block> map);


        /**
         * @return the type of the animal
         */
        AnimalType getType();

        /**
         * @return true if the animal is ready
         */
        bool isReady();
    }
}
