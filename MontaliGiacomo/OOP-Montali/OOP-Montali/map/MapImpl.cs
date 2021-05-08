using Farming_simulator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OOP_Montali.map
{
    public class MapImpl : Map
    {
        private static String MAP_PATH = @"C:\Users\Monta\Documents\coding\Visual Studio\Farming Simulator\Federaffo-OOP20-FarmingSimulator-csharp-task\MontaliGiacomo\OOP-Montali\map\map.txt";
        private static int ROW = 18;
        private static int COLUMN = 32;

        private Block[,] mappa;
        private FactoryBlock factory;

        public MapImpl()
        {
            mappa = new Block[COLUMN, ROW];
            factory = new FactoryBlock();

            int x = 0;
            int y = 0;

            string[] lines = File.ReadAllLines(MAP_PATH);
            foreach (string line in lines)
            {
                string[] rowNumbers = line.Split(" ");
                foreach (string number in rowNumbers)
                {
                    int num = Convert.ToInt32(number);
                    switch (num)
                    {
                        case 0:
                            mappa[x, y] = factory.GetObstacleBlock(x, y);
                            break;
                        case 1:
                            mappa[x, y] = factory.GetTerrainBlock(x, y);
                            break;
                        case 2:
                            mappa[x, y] = factory.GetFieldBlock(x, y);
                            break;
                        case 3:
                            mappa[x, y] = factory.GetLockedBlock(x, y);
                            break;
                        case 4:
                            mappa[x, y] = factory.GetWaterBlock(x, y);
                            break;
                        case 5:
                            mappa[x, y] = factory.GetStallBlock(x, y);
                            break;
                        default:
                            break;
                    }
                    x++;
                }
                y++;
                x = 0;
            }
        }

        public Block GetBlock(Pair<int, int> pos)
        {

            if (!IsInMap(pos))
            {
                throw new ArgumentException();
            }

            return mappa[pos.GetX(), pos.GetY()];
        }

        public void SetBlock(Pair<int, int> pos, BlockType bt)
        {

            if (!IsInMap(pos))
            {
                throw new ArgumentException();
            }

            int x = pos.GetX();
            int y = pos.GetY();

            if (bt == BlockType.FIELD)
            {
                mappa[x, y] = factory.GetFieldBlock(x, y);
            }
        }

        public HashSet<Block> GetMapSet()
        {
            HashSet<Block> mapSet = new HashSet<Block>();

            int row = COLUMN;
            int col = ROW;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    mapSet.Add(mappa[i, j]);
                }
            }

            return mapSet;
        }

        public Pair<int, int> GetBlockCoordinates(Block b)
        {

            for (int i = 0; i < COLUMN; i++)
            {
                for (int j = 0; j < ROW; j++)
                {
                    if (mappa[i, j].Equals(b))
                    {
                        return new Pair<int, int>(i, j);
                    }
                }
            }
            throw new ArgumentException();
        }

        public Block GetRandomFilterBlock(Predicate<Block> blockFilter)
        {
            Random rnd = new Random();
            Block b;
            do
            {
                b = mappa[rnd.Next(COLUMN), rnd.Next(ROW)];
            } while (!blockFilter(b));

            return b;
        }

    public int GetRows()
        {
            return ROW;
        }
   
    public int GetColumns()
        {
            return COLUMN;
        }

        private bool IsInMap(Pair<int, int> pos)
        {
            return !(pos.GetX() < 0 || pos.GetX() >= COLUMN || pos.GetY() < 0 || pos.GetY() >= ROW);
        }
    }
}
