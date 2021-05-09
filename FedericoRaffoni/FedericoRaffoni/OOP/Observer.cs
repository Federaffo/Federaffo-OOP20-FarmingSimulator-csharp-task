using System;
using System.Collections.Generic;
using System.Text;

namespace FedericoRaffoni.OOP
{
    interface IObserver <X>
    {
        void Update(X notify);
    }
}
