using System;
using System.Collections.Generic;
using System.Text;

namespace FedericoRaffoni.Utils
{
    [Serializable]
    class Animal
    {
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        internal void RandomMove(object p)
        {
            throw new NotImplementedException();
        }

    }
}
