using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Fabbri.util
{
    class Pair<X, Y>
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
    }
}
