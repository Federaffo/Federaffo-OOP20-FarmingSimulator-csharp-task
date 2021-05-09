using System;
using System.Collections.Generic;
using System.Text;
using FedericoRaffoni.OOP;

namespace FedericoRaffoni.Utils
{
    interface Player
    {
        Inventory GetInventory();
        void IncrementMoney(double pRICE_START);
        void move();
        void checkCollision(object p1, object p2);
        Block GetBlockPosition(object p);
        void DecreaseMoney(double unlockPrice);
        Optional<Animal> NearestAnimal(List<Animal> animals);
        double GetMoney();
    }
}
