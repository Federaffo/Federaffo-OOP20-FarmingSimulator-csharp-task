using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using FedericoRaffoni.Utils;

namespace FedericoRaffoni.OOP
{
    class Engine : IObserver<Boolean>
    {

        private static int TICK_TIME = 20;
        private MusicPlayer player;
        private WindowManager window;
        public IGame Game { get; private set; }

        // = new GameImpl();
        private GameState gameState = GameState.PLAY;
        private GameSaver gameSaver = new GameSaver();

        /**
         * true if Engine have to load last game, false otherwise.
         */

        public void Update(Boolean loadLastGame)
        {
            if (loadLastGame)
            {
                this.Game = gameSaver.Load();
                this.Game.GrowAllSeed();
                this.Game.ResetAnimals();
            }
            else
            {
                this.Game = new GameImpl();
            }
            this.Start();
        }

        /**
         * create the actual game instance after checking if load file is present.
         */
        public void CreateGame()
        {

            if (gameSaver.IsSavingPresent())
            {
                GamePreloader preloader = new GamePreloader();
                preloader.AddObserver(this);
                preloader.AskToLoad();
            }
            else
            {
                this.Game = new GameImpl();
                this.Start();
            }

        }

        /**
         * start entities and the WindowManager.
         */
        public void Start()
        {

            player = new MusicPlayer();
            window = new WindowManager(Game);


            Timer aTimer = new Timer(TICK_TIME);

            aTimer.Start();
            aTimer.Elapsed += OnTimedEvent;
            player.run();
        }


        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Game.Loop();

            if (gameState != Game.State)
            {
                gameState = Game.State;
                window.SetWindow(gameState);
            }
        }
    }
}


