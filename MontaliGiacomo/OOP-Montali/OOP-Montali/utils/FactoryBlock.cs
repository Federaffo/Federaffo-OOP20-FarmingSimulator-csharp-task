using Farming_simulator;
using OOP_Montali.map;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OOP_Montali
{
    public class FactoryBlock
    {
        public BlockImpl GetTerrainBlock(int posx, int posy)
        {
            return new BlockImpl(BlockType.TERRAIN, true, false);
        }

        public BlockImpl GetObstacleBlock(int posx, int posy)
        {
            return new BlockImpl(BlockType.WALL, false, false);
        }

        public BlockImpl GetFieldBlock(int posx, int posy)
        {
            return new BlockFieldImpl(BlockType.FIELD, true, true);
        }

        public BlockImpl GetLockedBlock(int posx, int posy)
        {
            return new UnlockableBlockImpl(BlockType.LOCKED, true, true);
        }

        public BlockImpl GetWaterBlock(int posx, int posy)
        {
            return new BlockImpl(BlockType.WATER, true, false);
        }

        public BlockImpl GetStallBlock(int posx, int posy)
        {
            return new BlockImpl(BlockType.STALL, true, false);
        }
        private class UnlockableBlockImpl : BlockFieldImpl, UnlockableBlock
        {

            private bool locked = true;

            public UnlockableBlockImpl(BlockType bt, bool isWalkable, bool isInteractable) : base(bt, isWalkable, isInteractable) { }


            public bool IsLocked()
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

            public BlockFieldImpl(BlockType bt, bool isWalkable, bool isInteractable) : base(bt, isWalkable, isInteractable) { }


            public void Plant(SeedType st)
            {
                myseed = Optional<Seed>.Of(new SeedImpl(st));
            }

            public Pair<FoodType, int> Harvest()
            {
                FoodType food = myseed.Get().Harvest();
                myseed = Optional<Seed>.Empty();
                return new Pair<FoodType, int>(food, (int)FoodTypeMethods.GetQuantity(food));
            }

            public bool IsEmpty()
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
            private bool isWalkable;
            private bool isInteractable;
            private Rectangle border;

            public BlockImpl(BlockType bt, bool isW, bool isInteractable)
            {
                this.blockType = bt;
                this.isWalkable = isW;
                this.isInteractable = isInteractable;
            }

            public bool IsWalkable()
            {
                return this.isWalkable;
            }

            public bool IsInteractable()
            {
                return this.isInteractable;
            }

            public BlockType GetType()
            {
                return blockType;
            }

            public bool IsStall()
            {
                if (this.blockType == BlockType.STALL)
                {
                    return true;
                }
                return false;
            }

            public Rectangle getBorder()
            {
                return border;
            }
        }
    }
}
