using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farming_simulator
{
    class EntityImpl : Entity
    {
        protected int SPEED;
        private static int SIZE = 50;
        private Direction direction;
        private bool isMoving;

        public EntityImpl(Pair<int, int> position) : base(position.getX() * SIZE, position.getY() * SIZE, SIZE, SIZE)
        {
            super(position.getX() * SIZE, position.getY() * SIZE, SIZE, SIZE);
            direction = new Direction();
        }

        // update isMoving variable
        private void updateIsMoving()
        {
            if (direction.isAllFalse())
            {
                isMoving = false;
            }
            else
            {
                isMoving = true;
            }
        }

        /**
         * {@inheritDoc}
         */

    public void setUp(bool isMoving)
        {
            direction.setUp(isMoving);
            updateIsMoving();
        }

        /**
         * {@inheritDoc}
         */
    public void setDown(bool isMoving)
        {
            direction.setDown(isMoving);
            updateIsMoving();
        }

        /**
         * {@inheritDoc}
         */
    public void setLeft(bool isMoving)
        {
            direction.setLeft(isMoving);
            updateIsMoving();
        }

        /**
         * {@inheritDoc}
         */
    public void setRight(bool isMoving)
        {

            direction.setRight(isMoving);
            updateIsMoving();
        }

        /**
         * {@inheritDoc}
         */
    public void moveTo(Pair<int, int> pos)
        {
            super.x = pos.getX() * SIZE;
            super.y = pos.getY() * SIZE;
        }

        /**
         * {@inheritDoc}
         */
    public void move()
        {
            if (direction.isUp())
            {
                super.y -= SPEED;
            }
            if (direction.isDown())
            {
                super.y += SPEED;
            }
            if (direction.isLeft())
            {
                super.x -= SPEED;
            }
            if (direction.isRight())
            {
                super.x += SPEED;
            }

        }

        /**
         * {@inheritDoc}
         */
    public <Block> void checkCollision(HashSet<Block> map, Predicate<Block> rightBlockFilter)
        {
            for (Block block : map)
            {
                Rectangle temp = this.intersection((Rectangle)block);

                if (temp.width > 0 && temp.height > 0)
                {
                    if (!rightBlockFilter.test(block))
                    {
                        if (temp.width >= temp.height)
                        {
                            if (this.y < temp.y)
                            {
                                this.y -= temp.height;
                            }
                            else
                            {
                                this.y += temp.height;
                            }
                        }
                        else
                        {
                            if (this.x < temp.x)
                            {
                                this.x -= temp.width;
                            }
                            else
                            {
                                this.x += temp.width;
                            }
                        }
                    }
                }
            }
        }

        /**
         * {@inheritDoc}
         */
    public int getPosX()
        {
            return super.x;
        }

        /**
         * {@inheritDoc}
         */
    public int getPosY()
        {
            return super.y;
        }

        /**
         * {@inheritDoc}
         */
    public bool isMoving()
        {
            return isMoving;
        }

        /**
         * {@inheritDoc}
         */
    
    public Direction getDirection()
        {
            return this.direction;
        }

        /**
         * {@inheritDoc}
         */
       
    public Block getBlockPosition(HashSet<Block> array)
        {
            float area = 0;
            Block currentBlockPos = null;

            for (Block b : array)
            {
                Rectangle temp = this.intersection((Rectangle)b);
                float tempArea = temp.width * temp.height;

                if (tempArea > area && temp.width > 0 && temp.height > 0)
                {
                    currentBlockPos = b;
                    area = tempArea;
                }
            }

            return currentBlockPos;
        }

        void Entity.checkCollision(HashSet<Block> map, Predicate<Block> filter)
        {
            throw new NotImplementedException();
        }
    }
}
