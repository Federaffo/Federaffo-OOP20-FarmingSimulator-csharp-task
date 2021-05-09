using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farming_simulator
{
    interface Player : Entity
    {
        void IncrementMoney(double moneyToAdd);

        void DecreaseMoney(double moneyToRemove);

        double GetMoney();

        Inventory GetInventory();

        Animal NearestAnimal(List<Animal> animals);
    }
}
