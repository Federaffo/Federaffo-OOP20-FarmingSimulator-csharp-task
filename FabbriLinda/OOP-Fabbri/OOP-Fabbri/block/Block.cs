using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Fabbri.block
{
    interface Block
    {
       
        Boolean IsWalkable();

        Boolean IsInteractable();

        BlockType GetType();

        Boolean IsStall();
    }
}
