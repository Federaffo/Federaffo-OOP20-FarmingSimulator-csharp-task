using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farming_simulator
{
    public class Pair<X,Y>
    {
        private X x;
        private Y y;

        public Pair(X x, Y y)
        {
            this.x = x;
            this.y = y;
        }

        public X GetX()
        {
            return x;
        }

        public Y GetY()
        {
            return y;
        }

        public void SetX(X x)
        {
            this.x = x;
        }

        public void SetY(Y y)
        {
            this.y = y;
        }


    public bool Equals(Object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj == null)
            {
                return false;
            }
            if (GetType() != obj.GetType())
            {
                return false;
            }
            Pair<X, Y> other = (Pair<X, Y>)obj;
            if (x == null)
            {
                if (other.x != null)
                {
                    return false;
                }
            }
            else if (!x.Equals(other.x))
            {
                return false;
            }
            if (y == null)
            {
                if (other.y != null)
                {
                    return false;
                }
            }
            else if (!y.Equals(other.y))
            {
                return false;
            }
            return true;
        }


    public String ToString()
        {
            return "Pair [x=" + x + ", y=" + y + "]";
        }
    }
}
