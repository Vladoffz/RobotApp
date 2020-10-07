using System;
using System.Collections.Generic;
using System.Text;

namespace RobotAppp228322
{
    public class Worker : Robot
    {
        public Worker(int size) : base(size)
        {
            DecodeProbability = 10;
            Battery = 120;
            LoadCapacity = 120;

        }
    }
}
