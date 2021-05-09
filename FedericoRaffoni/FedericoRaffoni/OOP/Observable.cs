using System;
using System.Collections.Generic;
using System.Text;

namespace FedericoRaffoni.OOP
{
    interface IObservable <X>
    {

    void NotifyObserver(X notify);

        /**
         * @param obs is a new Observer to be added
         */
        void AddObserver(IObserver<X> obs);
    }
}
