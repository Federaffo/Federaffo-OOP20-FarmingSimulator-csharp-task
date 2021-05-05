using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farming_simulator
{
    class Direction
    {
        private bool up;
        private bool down;
        private bool left;
        private bool right;

        public Direction()
        {

        }

        /**
         * @return true if the entity is going up
         */
        public bool isUp()
        {
            return up;
        }

        /**
         * This method set true if the direction is up.
         * @param up
         */
        public void setUp(bool up)
        {
            this.up = up;
        }

        /**
         * @return true if the direction is down
         */
        public bool isDown()
        {
            return down;
        }

        /**
         * This method set true if the direction is down.
         * @param down
         */
        public void setDown(bool down)
        {
            this.down = down;
        }

        /**
         * @return true if the direction is left
         */
        public bool isLeft()
        {
            return left;
        }

        /**
         * This method set true if the direction is left.
         * @param left
         */
        public void setLeft(bool left)
        {
            this.left = left;
        }

        /**
         * @return true if the direction is right
         */
        public bool isRight()
        {
            return right;
        }

        /**
         * This method set true if the direction is right.
         * @param right
         */
        public void setRight(bool right)
        {
            this.right = right;
        }

        /**
         * @return true if the entity is not moving
         */
        public bool isAllFalse()
        {
            if (!up && !right && !down && !left)
            {
                return true;
            }
            return false;
        }
    }
}
