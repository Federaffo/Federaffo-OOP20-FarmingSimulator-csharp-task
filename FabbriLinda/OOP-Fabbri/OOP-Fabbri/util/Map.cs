using OOP_Fabbri.block;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Fabbri.util
{
    interface Map
    {
        Pair<int, int> GetBlockCoordinates(Block block);
        void SetBlock(Pair<int, int> blockPos, BlockType fIELD);
    }
}
