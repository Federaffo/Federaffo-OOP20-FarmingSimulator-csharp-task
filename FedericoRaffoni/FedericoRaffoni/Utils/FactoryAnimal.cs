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
            throw new NotImplementedException();
        }

        internal Animal GetCow(object p)
        {
            throw new NotImplementedException();
        }

        internal Animal GetPig(object p)
        {
            throw new NotImplementedException();
        }
    }
}
