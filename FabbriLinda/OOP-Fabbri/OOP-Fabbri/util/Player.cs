using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Fabbri.util
{
    interface Player
    {
        void IncrementMoney(double moneyToAdd);
        void DecreaseMoney(double moneyToRemove);
        double GetMoney();
        Inventory GetInventory();
    }
}
