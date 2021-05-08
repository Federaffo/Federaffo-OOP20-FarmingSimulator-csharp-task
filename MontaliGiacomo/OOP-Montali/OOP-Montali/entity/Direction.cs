using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farming_simulator
{
    public class Direction
    {
        private bool up;
        private bool down;
        private bool left;
        private bool right;

        public bool IsUp()
        {
            return up;
        }

        public void SetUp(bool up)
        {
            this.up = up;
        }

        public bool IsDown()
        {
            return down;
        }

        public void SetDown(bool down)
        {
            this.down = down;
        }

        public bool IsLeft()
        {
            return left;
        }

        public void SetLeft(bool left)
        {
            this.left = left;
        }

        public bool IsRight()
        {
            return right;
        }

        public void SetRight(bool right)
        {
            this.right = right;
        }

        public bool IsAllFalse()
        {
            if (!up && !right && !down && !left)
            {
                return true;
            }
            return false;
        }
    }
}
