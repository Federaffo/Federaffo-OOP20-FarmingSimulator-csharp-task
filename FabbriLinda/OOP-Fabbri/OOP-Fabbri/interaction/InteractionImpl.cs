using OOP_Fabbri.block;
using OOP_Fabbri.util;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Fabbri.interaction
{
    class InteractionImpl : Interaction
    {
        public void PlayerPlant(Player pg, FieldBlock block)
        {
            SeedType st = pg.GetInventory().getCurrentSeed().Get().GetX();
            block.Plant(st);
            pg.GetInventory().RemoveSeed(st);
        }

        public void PlayerHarvest(Player pg, FieldBlock block)
        {

            Pair<FoodType, int> food = block.Harvest();
            pg.GetInventory().AddFoods(food.GetX(), food.GetY());
        }

        public void UnlockBlock(Player pg, Map map, Block block)
        {

            ((UnlockableBlock)block).UnlockBlock();
            Pair<int, int> blockPos = map.GetBlockCoordinates(block);
            map.SetBlock(blockPos, BlockType.FIELD);

        }

        public Boolean PlayerBuy(Player pg, SeedType st, int quantity)
        {

            if (pg.GetMoney() >= SeedTypeMethods.GetPrice(st) * quantity)
            {
                pg.GetInventory().AddSeeds(st, quantity);
                pg.DecreaseMoney(SeedTypeMethods.GetPrice(st) * quantity);
                return true;
            }
            return false;
        }


        public double PlayerSell(Player pg, Shop shop)
        {
            double money = shop.SellAll(pg.GetInventory().GetFoods());
            pg.IncrementMoney(money);
            pg.GetInventory().RemoveAllFood();
            return money;
        }

        public void FieldInteraction(Player pg, FieldBlock block)
        {
            // TODO Auto-generated method stub

            if (block.IsEmpty())
            {
                if (pg.GetInventory().getCurrentSeed().IsPresent)
                {
                    this.PlayerPlant(pg, block);
                }
            }
            else
            {
                if (block.GetSeed().GetSeedState() == SeedState.GROWN)
                {
                    this.PlayerHarvest(pg, block);
                }

            }

        }

        public void PlayerAnimal(Player pg, Animal animal)
        {
            // TODO Auto-generated method stub
            if (animal.isReady())
            {
                Pair<FoodType, int> temp = animal.Collect();
                pg.GetInventory().AddFoods(temp.GetX(), temp.GetY());
            }

        }
    }
}
