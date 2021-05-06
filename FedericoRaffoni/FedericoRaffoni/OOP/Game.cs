using System;
using System.Collections.Generic;
using System.Text;
using FedericoRaffoni.Utils;

namespace FedericoRaffoni.OOP
{
    interface Game
    {

        void LoadGame(MapImpl map, PlayerImpl player);

        /**
         * update all entities
         */
        void Loop();

        /**
         * @return Map
         */
        Map GetMap();

        /**
         * @return Player
         */
        Player GetPlayer();

        /**
         * @return Shop
         */
        Shop GetShop();

        /**
         * @param st
         * @param quantity
         * @return The interaction to buy [quantity] of [st]
         */
        Boolean Buy(SeedType st, int quantity);

        /**
         * @return The interaction to sell all food that player have got in his
         *         inventory
         */
        double SellAll();

        /**
         * @return the state of the Game
         */
        GameState GetState();

        /**
         * This method manage the interaction between Player and FieldBlock.
         */
        void Interact();

        /**
         * @return the Price to unlock LOCKED Block
         */
        double GetUnlockPrice();

        /**
         * This method grow all seed.
         */
        void GrowAllSeed();

        /**
         * updates GameState and put it on PLAY.
         */
        void Play();

        /**
         * updates GameState and put it on SHOP, or PLAY if was already SHOP.
         */
        void Shop();

        /**
         * updates GameState and put it on INFO, or PLAY if was already INFO.
         */
        void Info();

        /**
         * @return a List of the current Animals.
         */
        List<Animal> GetAllAnimals();

        /**
         * clear current animals and generate new animals.
         */
        void ResetAnimals();

    }
}
