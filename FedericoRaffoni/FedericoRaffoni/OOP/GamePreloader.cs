﻿using System;

namespace FedericoRaffoni.OOP
{
    internal class GamePreloader
    {
        private Observer<Boolean> obs;
        internal void addObserver(Observer<Boolean> engine)
        {
            obs = engine;
        }

        internal void askToLoad()
        {
                int result = 0;
            do
            {
                Console.WriteLine("Do you want to load the last game ? press 1 to load the last game, 0 to start a new game");
                try
                {
                    result = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error");
                }
            } while (result != 0 && result != 1);

            if (result == 1)
            {
                NotifyObserver(true);
            }
            else
            {
                NotifyObserver(false);
            }

        }

        private void NotifyObserver(bool v)
        {
            obs.Update(v);
        }
    }
}