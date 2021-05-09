using System;
using FedericoRaffoni.Utils;

namespace FedericoRaffoni.OOP
{
    internal class WindowManager
    {
        private IGame game;

        public WindowManager(IGame game)
        {
            this.game = game;
        }

        internal void SetWindow(GameState gameState)
        {
            throw new NotImplementedException();
        }
    }
}