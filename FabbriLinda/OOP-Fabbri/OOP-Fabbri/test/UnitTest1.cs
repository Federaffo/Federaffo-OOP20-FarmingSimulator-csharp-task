using NUnit.Framework;
using OOP_Fabbri.block;
using static OOP_Fabbri.block.FactoryBlock;

namespace OOP_Fabbri
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
            FactoryBlock block = new FactoryBlock();
            BlockImpl fieldBlock = block.GetFieldBlock();
            Assert.AreEqual(fieldBlock.GetType(), BlockType.FIELD);
            Assert.True(fieldBlock.IsInteractable());
            Assert.False(fieldBlock.IsStall());
        }
    }
}