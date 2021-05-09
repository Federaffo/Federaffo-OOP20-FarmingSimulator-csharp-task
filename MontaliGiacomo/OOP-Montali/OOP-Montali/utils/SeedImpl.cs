using Farming_simulator;

namespace OOP_Montali
{
    internal class SeedImpl : Seed
    {
        private SeedType st;

        public SeedImpl(SeedType st)
        {
            this.st = st;
        }

        FoodType Seed.Harvest()
        {
            throw new System.NotImplementedException();
        }
    }
}