using OOP_Fabbri.block;
using OOP_Fabbri.util;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Fabbri.interaction
{
    interface Interaction
    {
        void PlayerPlant(Player pg, FieldBlock block);
        void PlayerHarvest(Player pg, FieldBlock block);
        void UnlockBlock(Player pg, Map map, Block block);
        Boolean PlayerBuy(Player pg, SeedType st, int quantity);
        double PlayerSell(Player pg, Shop shop);
        void FieldInteraction(Player pg, FieldBlock block);
        void PlayerAnimal(Player pg, Animal animal);
    }
}
