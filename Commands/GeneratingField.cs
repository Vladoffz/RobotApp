using System;
using System.Collections.Generic;

namespace RobotAppp228322
{
    public class GeneratingField
    {
        private IRobot Robot;
        private List<IBagage> Bagages;
        private int size;
        private GeneratingBaggages gb;

        public GeneratingField(GeneratingBaggages gb)
        {
            this.gb = gb;
        }
        public Field Generate(int size)
        {
            this.size = size;

            Random rnd = new Random();
            int res = rnd.Next(0, 100);
            if (res < 51)
            {
                Robot = new Worker(size);
            }
            else if (res < 81)
            {
                Robot = new Cyborg(size);
            }
            else
            {
                Robot = new Clever(size);
            }

            Bagages = new List<IBagage>();
            Bagages.Add(new ClassicBaggage());
            Bagages.Add(new DecodingBaggage());
            Bagages.Add(new DecodingBaggage());
            Bagages.Add(new DecodingBaggage());
            Bagages.Add(new DecodingBaggage());
            Bagages.Add(new DecodingBaggage());
            Bagages.Add(new DecodingBaggage());
            Bagages.Add(new DecodingBaggage());
            Bagages.Add(new ToxicBaggage());
            Bagages.Add(new WeightBaggage());
            
            gb.Generate(size, Bagages);

            return new Field(this.size, this.Robot, this.Bagages);
        }
    }
}