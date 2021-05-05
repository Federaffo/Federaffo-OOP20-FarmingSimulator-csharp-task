using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Fabbri.util
{
    interface Animal
    {
        bool isReady();
        Pair<FoodType, int> Collect();
    }
}
