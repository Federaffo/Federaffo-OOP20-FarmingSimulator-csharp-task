using System;
using System.Collections.Generic;
using System.Text;

namespace FedericoRaffoni.OOP
{
    interface Observable <X>
    {

    void NotifyObserver(X notify);

        /**
         * @param obs is a new Observer to be added
         */
        void AddObserver(Observer<X> obs);
    }
}
