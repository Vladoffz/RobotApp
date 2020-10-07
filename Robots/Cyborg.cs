using System;
using System.Collections.Generic;
using System.Text;

namespace RobotAppp228322
{
    public class Cyborg : Robot
    {
        public Cyborg(int size) : base(size)
        {
            DecodeProbability = 60;
            Battery = 110;
            LoadCapacity = 110;
        }
    }
}
