using OOP_Montali.map;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OOP_Montali
{
    public interface Block 
    {
        public Rectangle getBorder();

        public bool IsStall();

        BlockType GetType();
    }
}
