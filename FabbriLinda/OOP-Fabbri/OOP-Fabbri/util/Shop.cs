using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Fabbri.util
{
    interface Shop
    {
        double SellAll(Dictionary<FoodType, int> dictionary);
    }
}
