using OOP_Montali;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farming_simulator
{
    public interface Animal : Entity
    {
        Task<Pair<FoodType, int>> Collect();

        void RandomMove(HashSet<Block> map);

        AnimalType GetType();

        bool IsReady();
    }
}
