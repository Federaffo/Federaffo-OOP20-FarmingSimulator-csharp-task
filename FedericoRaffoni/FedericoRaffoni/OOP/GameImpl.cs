using System;
using System.Collections.Generic;
using System.Text;
using FedericoRaffoni.Utils;

namespace FedericoRaffoni.OOP
{
    [Serializable]
    class GameImpl : IGame
    {
        private static double PRICE_START = 50.0;
        private static int UNLOCK_STEP = 50;

        private Shop shop = new ShopImpl();
        private Interaction interaction = new InteractionImpl();
        private FactoryAnimal factoryAnimal = new FactoryAnimal();
        public double UnlockPrice { get; private set; } = PRICE_START;
        public List<Animal> Animals { get; private set; } = new List<Animal>();
        public GameState State { get; private set; } = GameState.PLAY;
        public Player Pg { get; private set; } = new PlayerImpl(new Pair<int, int>(1, 1));
        public IMap Map { get; private set; } = new MapImpl();

        private int serialNum;

        public GameImpl()
        {
            serialNum = new Random().Next();
            GenerateAnimals();
            Pg.GetInventory().AddSeeds(SeedType.WHEAT_SEED, 10);
            Pg.IncrementMoney(PRICE_START);
        }

        public void LoadGame(MapImpl map, PlayerImpl player)
        {
            this.Pg = player;
            this.Map = map;
        }

        public void Loop()
        {
            Pg.move();
            //pg.checkCollision(map.GetMapSet(), x->x.isWalkable());

            foreach(Animal a in Animals)
            {
                a.RandomMove(Map.GetMapSet());
            }
        }

        public IMap GetMap()
        {
            return this.Map;
        }

        public Player GetPlayer()
        {
            return this.Pg;
        }

        public Shop GetShop()
        {
            return this.shop;
        }

        public Boolean Buy(SeedType st, int quantity)
        {
            return interaction.playerBuy(Pg, st, quantity);
        }

        public double SellAll()
        {
            return interaction.PlayerSell(shop, Pg);
        }



        public void Interact()
        {
            Block temp = Pg.GetBlockPosition(Map.GetMapSet());
            if (temp is UnlockableBlock)
            {
                if (Pg.GetMoney() >= UnlockPrice)
                {
                    interaction.UnlockBlock(Pg, Map, temp);
                    Pg.DecreaseMoney(UnlockPrice); // decremento i soldi del Player
                    UnlockPrice += UNLOCK_STEP; // aumento il prezzo del prossimo blocco
                }
            }
            else
            {

                if (temp.GetType().Equals(BlockType.FIELD))
                {
                    FieldBlock myBlock = (FieldBlock)temp;
                    interaction.FieldInteraction(Pg, myBlock);
                }
            }
            if (Pg.NearestAnimal(Animals).IsPresent)
            {
                interaction.PlayerAnimal(Pg, Pg.NearestAnimal(Animals).Get());
            }
        }

        public void GrowAllSeed()
        {
            foreach (Block block in Map.GetMapSet())
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
            State = GameState.PLAY;
        }

        public void Shop()
        {
            if (State == GameState.SHOP)
            {
                State = GameState.PLAY;
            }
            else
            {
                State = GameState.SHOP;
            }
        }


        public void Info()
        {
            if (State == GameState.INFO)
            {
                State = GameState.PLAY;
            }
            else
            {
                State = GameState.INFO;
            }
        }

        public void ResetAnimals()
        {
            Animals.Clear();
            GenerateAnimals();
        }

        public void GenerateAnimals()
        {
            Animals.Add(factoryAnimal.GetChicken(Map.GetBlockCoordinates(Map.GetRandomFilterBlock(x => x.GetType().Equals(BlockType.STALL)))));
            Animals.Add(factoryAnimal.GetCow(Map.GetBlockCoordinates(Map.GetRandomFilterBlock(x => x.GetType().Equals(BlockType.STALL)))));
            Animals.Add(factoryAnimal.GetPig(Map.GetBlockCoordinates(Map.GetRandomFilterBlock(x => x.GetType().Equals(BlockType.STALL)))));
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(UnlockPrice, Animals, State, Pg, Map, serialNum);
        }

        public override bool Equals(object obj)
        {
            return obj is GameImpl impl &&
                   serialNum == impl.serialNum;
        }
    }
}
