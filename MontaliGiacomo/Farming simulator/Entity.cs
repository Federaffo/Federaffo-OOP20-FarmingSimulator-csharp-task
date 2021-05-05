using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farming_simulator
{
    interface Entity
    {
        /**
     * move entity in the current direction.
     */
        void move();

    /**
     * @param <Block>
     * @param map
     * @param filter  check if the entity is on a blocked block if it is, then this
     *                take the entity back to the walkable block
     */
    <Block> void checkCollision(HashSet<Block> map, Predicate<Block> filter);

        /**
         * @param isMoving set the current direction of the entity
         */
        void setUp(bool isMoving);

        /**
         * @param isMoving set the current direction of the entity
         */
        void setDown(bool isMoving);

        /**
         * @param isMoving set the current direction of the entity
         */
        void setLeft(bool isMoving);

        /**
         * @param isMoving set the current direction of the entity
         */
        void setRight(bool isMoving);

        /**
         * @return the entity direction
         */
        Direction getDirection();

        /**
         * @return a true if the entity has some current direction, false otherwise
         */
        bool isMoving();

        /**
         * @param pos moves the entity to the current position
         */
        void moveTo(Pair<int, int> pos);

        /**
         * @return entity X position
         */
        int getPosX();

        /**
         * @return entity Y position
         */
        int getPosY();

        /**
         * @param array
         * @return the Block where the entity is standing on
         */
        Block getBlockPosition(HashSet<Block> array);
    }
}
