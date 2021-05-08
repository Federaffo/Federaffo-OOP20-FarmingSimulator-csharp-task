using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace FedericoRaffoni.OOP
{
    internal class GameSaver
    {
        private String filePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + Path.DirectorySeparatorChar + ".farmingSimulator_Saves.json";
        public bool IsSavingPresent()
        {
            return File.Exists(filePath);
        }

        public void Save(GameImpl g)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, g);
            stream.Close();

        }

        public GameImpl Load()
        {
            IFormatter formatter = new BinaryFormatter();

            Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return (GameImpl) formatter.Deserialize(stream);
        }
    }
}