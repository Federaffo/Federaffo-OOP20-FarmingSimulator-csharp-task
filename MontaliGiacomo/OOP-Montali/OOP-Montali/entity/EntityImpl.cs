using OOP_Montali;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farming_simulator
{
    public class EntityImpl : Entity
    {
        protected Rectangle border;
        protected int SPEED;
        private static Size SIZE = new Size();
        private Direction direction;
        private bool isMoving;

        public EntityImpl(Pair<int, int> position)
        {
            Point p = new Point(position.GetX(), position.GetY());
            border = new Rectangle(p, SIZE);

            direction = new Direction();
        }

        private void UpdateIsMoving()
        {
            if (direction.IsAllFalse())
            {
                isMoving = false;
            }
            else
            {
                isMoving = true;
            }
        }

    public void SetUp(bool isMoving)
        {
            direction.SetUp(isMoving);
            UpdateIsMoving();
        }

    public void SetDown(bool isMoving)
        {
            direction.SetDown(isMoving);
            UpdateIsMoving();
        }

    public void SetLeft(bool isMoving)
        {
            direction.SetLeft(isMoving);
            UpdateIsMoving();
        }

    public void SetRight(bool isMoving)
        {
            direction.SetRight(isMoving);
            UpdateIsMoving();
        }

    public void MoveTo(Pair<int, int> pos)
        {
            border.X = pos.GetX() * SIZE.Width;
            border.Y = pos.GetY() * SIZE.Width;
        }

    public void Move()
        {
            if (direction.IsUp())
            {
                border.Y -= SPEED;
            }
            if (direction.IsDown())
            {
                border.Y += SPEED;
            }
            if (direction.IsLeft())
            {
                border.X -= SPEED;
            }
            if (direction.IsRight())
            {
                border.X += SPEED;
            }

        }

    public void CheckCollision(HashSet<Block> map, Predicate<Block> rightBlockFilter)
        {
            foreach (Block block in map)
            {
                Rectangle temp = new Rectangle(border.Location, border.Size);
                temp.Intersect(block.getBorder());

                if (temp.Width > 0 && temp.Height > 0)
                {
                    if (!rightBlockFilter(block))
                    {
                        if (temp.Width >= temp.Height)
                        {
                            if (border.Y < temp.Y)
                            {
                                border.Y -= temp.Height;
                            }
                            else
                            {
                                border.Y += temp.Height;
                            }
                        }
                        else
                        {
                            if (border.X < temp.X)
                            {
                                border.X -= temp.Width;
                            }
                            else
                            {
                                border.X += temp.Width;
                            }
                        }
                    }
                }
            }
        }

    public int GetPosX()
        {
            return border.X;
        }

    public int GetPosY()
        {
            return border.Y;
        }

    public bool IsMoving()
        {
            return isMoving;
        }

    public Direction GetDirection()
        {
            return this.direction;
        }

    public Block GetBlockPosition(HashSet<Block> array)
        {
            float area = 0;
            Block currentBlockPos = null;

            foreach (Block b in array)
            {
                Rectangle temp = new Rectangle(border.Location, border.Size);
                temp.Intersect(b.getBorder());
                float tempArea = temp.Width * temp.Height;

                if (tempArea > area && temp.Width > 0 && temp.Height > 0)
                {
                    currentBlockPos = b;
                    area = tempArea;
                }
            }

            return currentBlockPos;
        }


        public Rectangle GetRectangle()
        {
            return border;
        }
    }
}
