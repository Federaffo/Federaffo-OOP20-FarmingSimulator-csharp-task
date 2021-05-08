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
        public void Test1()
        {
            GameSaver saver = new GameSaver();
            GameImpl myGame = new GameImpl();


            saver.Save(myGame);

            Assert.IsTrue(saver.IsSavingPresent());
            Assert.AreNotEqual(saver.Load(), new GameImpl());
            Assert.AreEqual(myGame, saver.Load());
        }

        [Test]
        public void TestEngine()
        {
            Engine engine = new Engine();
            engine.Update(false);

            Assert.NotNull(engine.game);
        }

    }
}