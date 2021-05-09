using FedericoRaffoni.OOP;
using NUnit.Framework;

namespace FedericoRaffoni
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        { 
        }

        [Test]
        public void TestSave()
        {
            GameSaver saver = new GameSaver();
            GameImpl myGame = new GameImpl();


            saver.Save(myGame);

            Assert.IsTrue(saver.IsSavingPresent());
            Assert.AreNotEqual(saver.Load(), new GameImpl());
            Assert.AreEqual(myGame, saver.Load());
        }

        [Test]
        public void TestEngineNewGame()
        {
            Engine engine = new Engine();
            engine.Update(false);

            GameSaver saver = new GameSaver();
            GameImpl myGame = new GameImpl();
            saver.Save(myGame);

            Assert.NotNull(engine.Game);
            Assert.AreNotEqual(myGame, engine.Game);
        }

        [Test]
        public void TestEngineOldGame()
        {
            GameSaver saver = new GameSaver();
            GameImpl myGame = new GameImpl();
            saver.Save(myGame);


            Engine engine = new Engine();
            engine.Update(true);

            Assert.AreEqual(engine.Game, myGame);
        }

    }
}