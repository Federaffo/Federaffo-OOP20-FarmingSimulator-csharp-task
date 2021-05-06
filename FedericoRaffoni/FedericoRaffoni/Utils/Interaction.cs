using System;
using System.Collections.Generic;
using System.Text;
using FedericoRaffoni.OOP;

namespace FedericoRaffoni.Utils
{
    interface Interaction
    {
        bool playerBuy(Player pg, SeedType st, int quantity);
        double PlayerSell(Shop shop, Player pg);
        void FieldInteraction(Player pg, FieldBlock myBlock);
        void UnlockBlock(Player pg, Map map, Block temp);
        void PlayerAnimal(Player pg, object p);
    }
}
