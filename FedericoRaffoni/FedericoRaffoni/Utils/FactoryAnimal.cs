using System;
using System.Collections.Generic;
using System.Text;

namespace FedericoRaffoni.Utils
{
    [Serializable]

    class FactoryAnimal
    {
        internal Animal GetChicken(object p)
        {
            return new Animal();
        }

        internal Animal GetCow(object p)
        {
            return new Animal();
        }

        internal Animal GetPig(object p)
        {
            return new Animal();
        }
    }
}
