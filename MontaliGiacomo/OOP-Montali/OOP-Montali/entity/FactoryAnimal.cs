using Farming_simulator;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Montali.entity
{
    class FactoryAnimal
    {
        public Animal GetChicken(Pair<int, int> position)
        {
            return new AnimalImpl(position, AnimalType.CHICKEN);
        }

        public Animal GetCow(Pair<int, int> position)
        {
            return new AnimalImpl(position, AnimalType.COW);
        }

        public Animal GetPig(Pair<int, int> position)
        {
            return new AnimalImpl(position, AnimalType.PIG);
        }

        public Animal GenerateAnimal(Pair<int, int> position, AnimalType type)
        {
            return new AnimalImpl(position, type);
        }
    }
}
