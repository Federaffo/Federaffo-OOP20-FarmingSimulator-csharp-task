using OOP_Montali;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farming_simulator
{
    public interface Entity
    {
        void Move();

        void CheckCollision(HashSet<Block> map, Predicate<Block> filter);

        void SetUp(bool isMoving);

        void SetDown(bool isMoving);

        void SetLeft(bool isMoving);

        void SetRight(bool isMoving);

        Direction GetDirection();

        bool IsMoving();

        void MoveTo(Pair<int, int> pos);

        int GetPosX();

        int GetPosY();

        Block GetBlockPosition(HashSet<Block> array);

        Rectangle GetRectangle();
    }
}
