using OOP_Fabbri.util;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Fabbri.block
{
    class FactoryBlock
    {

        public BlockImpl GetTerrainBlock()
        {
            return new BlockImpl(BlockType.TERRAIN, true, false);
        }

        public BlockImpl GetObstacleBlock()
        {
            return new BlockImpl(BlockType.WALL, false, false);
        }

        public BlockImpl GetFieldBlock()
        {
            return new BlockFieldImpl(BlockType.FIELD, true, true);
        }

        public BlockImpl GetLockedBlock()
        {
            return new UnlockableBlockImpl(BlockType.LOCKED, true, true);
        }

        public BlockImpl GetWaterBlock()
        {
            return new BlockImpl(BlockType.WATER, true, false);
        }

        public BlockImpl GetStallBlock()
        {
            return new BlockImpl(BlockType.STALL, true, false);
        }
        private class UnlockableBlockImpl : BlockFieldImpl, UnlockableBlock
        {

            private Boolean locked = true;

            public UnlockableBlockImpl(BlockType bt, Boolean isWalkable, Boolean isInteractable) : base(bt, isWalkable, isInteractable) { }


            public Boolean IsLocked()
            {
                return this.locked;
            }

            public void UnlockBlock()
            {
                this.locked = false;
            }

            public void LockBlock()
            {
                this.locked = true;
            }

        }
        private class BlockFieldImpl : BlockImpl, FieldBlock
        {

            private Optional<Seed> myseed = Optional<Seed>.Empty();

            public BlockFieldImpl(BlockType bt, Boolean isWalkable, Boolean isInteractable) : base(bt, isWalkable, isInteractable) { }


            public void Plant(SeedType st)
            {
                myseed = Optional<Seed>.Of(new SeedImpl(st));
            }

            public Pair<FoodType, int> Harvest()
            {
                FoodType food = myseed.Get().Harvest();
                myseed = Optional<Seed>.Empty();
                return new Pair<FoodType, int>(food, FoodTypeMethod.GetQuantity(food));
            }

            public Boolean IsEmpty()
            {
                return (!myseed.IsPresent);
            }

            public Seed GetSeed()
            {
                return myseed.Get();
            }


        }

        public class BlockImpl : Block
        {
            private BlockType blockType;
            private Boolean isWalkable;
            private Boolean isInteractable;

            public BlockImpl(BlockType bt, Boolean isW, Boolean isInteractable)
            {
                this.blockType = bt;
                this.isWalkable = isW;
                this.isInteractable = isInteractable;
            }

            public Boolean IsWalkable()
            {
                return this.isWalkable;
            }

            public Boolean IsInteractable()
            {
                return this.isInteractable;
            }

            public BlockType GetType()
            {
                return blockType;
            }

            public Boolean IsStall()
            {
                if (this.blockType == BlockType.STALL)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
