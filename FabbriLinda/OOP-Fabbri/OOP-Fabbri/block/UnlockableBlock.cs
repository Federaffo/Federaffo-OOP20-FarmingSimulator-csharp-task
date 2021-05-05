using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Fabbri.block
{
    interface UnlockableBlock : FieldBlock
    {
        Boolean IsLocked();

        void UnlockBlock();

        void LockBlock();
    }
}
