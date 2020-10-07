using System;
using System.Collections.Generic;

namespace RobotAppp228322
{
    public class GeneratingField
    {
        private Robot Robot;
        private List<Bagage> Bagages;
        private int size;

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

            Bagages = new List<Bagage>();
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
            GeneratingBaggages gb = new GeneratingBaggages();
            gb.Generate(size, Bagages);

            return new Field(this.size, this.Robot, this.Bagages);
        }
    }
}