using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using FedericoRaffoni.Utils;

namespace FedericoRaffoni.OOP
{
    class Engine : Observer<Boolean>
    {

        private static int TICK_TIME = 20;
        private MusicPlayer player;
        private WindowManager window;
        private Timer timer;
        public Game game { get; private set; }

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
                this.game = gameSaver.Load();
                this.game.GrowAllSeed();
                this.game.ResetAnimals();
            }
            else
            {
                this.game = new GameImpl();
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
                preloader.addObserver(this);
                preloader.askToLoad();
            }
            else
            {
                this.game = new GameImpl();
                this.Start();
            }

        }

        /**
         * start entities and the WindowManager.
         */
        public void Start()
        {

            player = new MusicPlayer();
            window = new WindowManager(game);


            Timer aTimer = new Timer(20);

            aTimer.Start();
            aTimer.Elapsed += OnTimedEvent;
            player.run();
        }


        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            game.Loop();

            if (gameState != game.GetState())
            {
                gameState = game.GetState();
                window.SetWindow(gameState);
            }
        }
    }
}


