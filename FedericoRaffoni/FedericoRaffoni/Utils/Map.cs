using System;
using System.Collections.Generic;
using System.Text;
using FedericoRaffoni.OOP;

namespace FedericoRaffoni.Utils
{
    interface Map
    {

        HashSet<Block> GetMapSet();
        object GetBlockCoordinates(object p);
        object GetRandomFilterBlock(object p);
    }
}
