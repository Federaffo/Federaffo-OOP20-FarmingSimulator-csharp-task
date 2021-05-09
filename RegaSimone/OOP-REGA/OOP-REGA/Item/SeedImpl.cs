using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace FarmingSimulator
{
    class SeedImpl : Seed
    {
        private SeedType st;
        private SeedState ss;
        private long growTime;
        private FoodType ofWhichFood;
        

        public SeedImpl(SeedType st)
        {
            this.st = st;
            this.ss = SeedState.PLANTED;
            this.growTime = SeedTypeMethods.GetGrowTime(st);
            this.ofWhichFood = SeedTypeMethods.GetFoodType(st);
            WaitGrow();
        }

        private async void WaitGrow()
        {
            await Task.Delay((int)growTime);
            Grow();
        }

        public FoodType GetFoodType()
        {
            return this.ofWhichFood;
        }

        public double GetGrowTime()
        {
            return this.growTime;
        }

        public SeedState GetSeedState()
        {
            return this.ss;
        }

        public SeedType GetSeedType()
        {
            return this.st;
        }

        public void Grow()
        {
            this.ss = SeedState.GROWN;
        }

        public FoodType Harvest()
        {
            this.ss = SeedState.HARVESTED;
            return ofWhichFood;
        }

        public override bool Equals(object obj)
        {
            return obj is SeedImpl impl &&
                   ss == impl.ss;
        }
    }
}
