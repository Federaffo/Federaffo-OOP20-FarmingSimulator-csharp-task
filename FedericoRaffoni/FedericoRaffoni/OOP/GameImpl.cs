using System;
using System.Collections.Generic;
using System.Text;
using FedericoRaffoni.Utils;

namespace FedericoRaffoni.OOP
{
    [Serializable]
    class GameImpl : Game
    {
        private static double PRICE_START = 50.0;
        private static int UNLOCK_STEP = 50;
        private Player pg = new PlayerImpl(new Pair<int, int>(1, 1));
        private Map map = new MapImpl();
        private Shop shop = new ShopImpl();
        private Interaction interaction = new InteractionImpl();
        private List<Animal> animals = new List<Animal>();
        private FactoryAnimal factoryAnimal = new FactoryAnimal();
        private GameState state = GameState.PLAY;
        private double unlockPrice = PRICE_START;

        private int serialNum;

        public GameImpl()
        {
            serialNum = new Random().Next();
            GenerateAnimals();
            pg.GetInventory().AddSeeds(SeedType.WHEAT_SEED, 10);
            pg.IncrementMoney(PRICE_START);
        }

        public void LoadGame(MapImpl map, PlayerImpl player)
        {
            this.pg = player;
            this.map = map;
        }

        public void Loop()
        {
            pg.move();
            //pg.checkCollision(map.GetMapSet(), x->x.isWalkable());

            foreach(Animal a in animals)
            {
                a.RandomMove(map.GetMapSet());
            }
        }

        public Map GetMap()
        {
            return this.map;
        }

        public Player GetPlayer()
        {
            return this.pg;
        }

        public Shop GetShop()
        {
            return this.shop;
        }

        public Boolean Buy(SeedType st, int quantity)
        {
            return interaction.playerBuy(pg, st, quantity);
        }

        public double SellAll()
        {
            return interaction.PlayerSell(shop, pg);
        }

        public GameState GetState()
        {
            return this.state;
        }


        public void Interact()
        {
            Block temp = pg.GetBlockPosition(map.GetMapSet());
            if (!(temp is   UnlockableBlock)) {

                if (temp.GetType().Equals(BlockType.FIELD))
                {
                    FieldBlock myBlock = (FieldBlock) temp;
                    interaction.FieldInteraction(pg, myBlock);
                }
            } else if (pg.GetMoney() >= unlockPrice)
            {
                interaction.UnlockBlock(pg, map, temp);
                pg.DecreaseMoney(unlockPrice); // decremento i soldi del Player
                unlockPrice += UNLOCK_STEP; // aumento il prezzo del prossimo blocco
            }
            if (pg.NearestAnimal(animals).IsPresent)
            {
                interaction.PlayerAnimal(pg, pg.NearestAnimal(animals).Get());
            }
        }

        public double GetUnlockPrice()
        {
            return this.unlockPrice;
        }

        public void GrowAllSeed()
        {
            foreach (Block block in map.GetMapSet())
            {
                
                if (block.GetType().Equals(typeof(FieldBlock))) {
                    FieldBlock field = (FieldBlock)block;
                    if (!field.IsEmpty())
                    {
                        field.GetSeed().Grow();
                    }
                }
            }
        }


        public void Play()
        {
            state = GameState.PLAY;
        }

        public void Shop()
        {
            if (state == GameState.SHOP)
            {
                state = GameState.PLAY;
            }
            else
            {
                state = GameState.SHOP;
            }
        }


        public void Info()
        {
            if (state == GameState.INFO)
            {
                state = GameState.PLAY;
            }
            else
            {
                state = GameState.INFO;
            }
        }

        public List<Animal> GetAllAnimals()
        {
            return this.animals;
        }

        public void ResetAnimals()
        {
            animals.Clear();
            GenerateAnimals();
        }

        public void GenerateAnimals()
        {
            //animals.Add(factoryAnimal.GetChicken(map.GetBlockCoordinates(map.GetRandomFilterBlock(x->x.isStall()))));
            //animals.Add(factoryAnimal.GetCow(map.GetBlockCoordinates(map.GetRandomFilterBlock(x->x.isStall()))));
            //animals.Add(factoryAnimal.GetPig(map.GetBlockCoordinates(map.GetRandomFilterBlock(x->x.isStall()))));
        }

        public override bool Equals(object obj)
        {
            return obj is GameImpl impl &&
                   serialNum == impl.serialNum;
        }
    }
}
