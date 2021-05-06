using System;
using System.Collections.Generic;
using System.Text;

namespace FedericoRaffoni.OOP
{
    interface Observer <X>
    {
        void Update(X notify);
    }
}
