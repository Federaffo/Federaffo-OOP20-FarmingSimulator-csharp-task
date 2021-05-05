using OOP_Fabbri.util;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Fabbri.block
{
    interface FieldBlock : Block
    {
        void Plant(SeedType st);

        Pair<FoodType, int> Harvest();

        Boolean IsEmpty();

        Seed GetSeed();
    }
}
