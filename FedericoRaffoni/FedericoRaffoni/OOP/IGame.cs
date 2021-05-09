using System;
using System.Collections.Generic;
using System.Text;
using FedericoRaffoni.Utils;

namespace FedericoRaffoni.OOP
{
    interface IGame
    {
        GameState State { get;}

        void LoadGame(MapImpl map, PlayerImpl player);

        /**
         * update all entities
         */
        void Loop();

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
         * This method manage the interaction between Player and FieldBlock.
         */
        void Interact();

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
         * clear current animals and generate new animals.
         */
        void ResetAnimals();

    }
}
