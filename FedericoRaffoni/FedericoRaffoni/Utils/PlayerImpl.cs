using System;
using System.Collections.Generic;
using System.Text;
using FedericoRaffoni.OOP;

namespace FedericoRaffoni.Utils
{
    [Serializable]
    class PlayerImpl : Player
    {
        public PlayerImpl(Pair<int,int> pair)
        {
        }

        public void checkCollision(object p1, object p2)
        {
            throw new NotImplementedException();
        }

        public void DecreaseMoney(double unlockPrice)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public Block GetBlockPosition(object p)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Inventory GetInventory()
        {
            return new Inventory();
        }

        public double GetMoney()
        {
            return 0;
        }

        public void IncrementMoney(double pRICE_START)
        {
        }

        public void move()
        {
            throw new NotImplementedException();
        }

        public Optional<Animal> NearestAnimal(List<Animal> animals)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
