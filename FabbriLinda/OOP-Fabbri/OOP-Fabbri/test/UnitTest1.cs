using NUnit.Framework;
using OOP_Fabbri.block;
using OOP_Fabbri.interaction;
using OOP_Fabbri.util;
using static OOP_Fabbri.block.FactoryBlock;

namespace OOP_Fabbri
{
    public class Tests
    {
        private FactoryBlock block;
        [SetUp]
        public void Setup()
        {
            block = new FactoryBlock();

        }

        [Test]
        public void TestFieldBlock()
        {
            
            BlockImpl fieldBlock = block.GetFieldBlock();
            Assert.AreEqual(fieldBlock.GetType(), BlockType.FIELD);
            Assert.True(fieldBlock.IsInteractable());
            Assert.False(fieldBlock.IsStall());
        }

        [Test]
        public void TestUnlockableBlock()
        {

            BlockImpl lockedBlock = block.GetLockedBlock();
            Assert.AreEqual(lockedBlock.GetType(), BlockType.LOCKED);
            Assert.True(lockedBlock.IsInteractable());
            Assert.False(lockedBlock.IsStall());
            Assert.True(lockedBlock.IsWalkable());
        }

        [Test]
        public void TestTerrainBlock()
        {

            BlockImpl terrainBlock = block.GetTerrainBlock();
            Assert.AreEqual(terrainBlock.GetType(), BlockType.TERRAIN);
            Assert.AreNotEqual(terrainBlock.GetType(), BlockType.LOCKED);
            Assert.False(terrainBlock.IsInteractable());
            Assert.False(terrainBlock.IsStall());
            Assert.True(terrainBlock.IsWalkable());
        }
    }
}