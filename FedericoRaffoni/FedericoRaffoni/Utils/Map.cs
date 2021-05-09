using System;
using System.Collections.Generic;
using System.Text;
using FedericoRaffoni.OOP;

namespace FedericoRaffoni.Utils
{
    interface IMap
    {

        HashSet<Block> GetMapSet();
        object GetBlockCoordinates(object p);
        Block GetRandomFilterBlock(Predicate<Block> p);
    }
}
