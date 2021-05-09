using System;
using System.Collections.Generic;
using System.Text;
using FedericoRaffoni.OOP;

namespace FedericoRaffoni.Utils
{
    [Serializable]
    class MapImpl : IMap
    {
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public object GetBlockCoordinates(object p)
        {
            return new object();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public HashSet<Block> GetMapSet()
        {
            return new HashSet<Block>();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        Block IMap.GetRandomFilterBlock(Predicate<Block> p)
        {
            return new Block();
        }


    }
}
