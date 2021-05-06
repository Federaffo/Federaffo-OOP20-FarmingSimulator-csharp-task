using System;
using System.Collections.Generic;
using System.Text;
using FedericoRaffoni.OOP;

namespace FedericoRaffoni.Utils
{
    [Serializable]

    class InteractionImpl : Interaction
    {
        public void FieldInteraction(Player pg, FieldBlock myBlock)
        {
            throw new NotImplementedException();
        }

        public void PlayerAnimal(Player pg, object p)
        {
            throw new NotImplementedException();
        }

        public bool playerBuy(Player pg, SeedType st, int quantity)
        {
            throw new NotImplementedException();
        }

        public double PlayerSell(Shop shop, Player pg)
        {
            throw new NotImplementedException();
        }

        public void UnlockBlock(Player pg, Map map, Block temp)
        {
            throw new NotImplementedException();
        }
    }
}
