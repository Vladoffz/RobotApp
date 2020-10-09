using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RobotAppp228322
{
    public class Bagage : IBagage
    {
        public int Cost { get; set; }
        public int Weight { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
