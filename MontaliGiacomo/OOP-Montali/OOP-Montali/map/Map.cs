using Farming_simulator;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Montali.map
{
    interface Map
    {
        HashSet<Block> GetMapSet();

        Block GetBlock(Pair<int, int> pos);

        void SetBlock(Pair<int, int> pos, BlockType bt);

        Pair<int, int> GetBlockCoordinates(Block b);

        Block GetRandomFilterBlock(Predicate<Block> blockFilter);

        int GetRows();

        int GetColumns();
    }
}
