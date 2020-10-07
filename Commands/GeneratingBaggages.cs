using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotAppp228322
{
    public class GeneratingBaggages
    {
        public void Generate(int size, List<Bagage> bagages)
        {
            Random rnd = new Random();
            for(int i = 0; i< bagages.Count; i++)
            {
                int x = rnd.Next(0, size);
                int y = rnd.Next(0, size);
                if(x == 0 && y == 0)
                {
                    i--;
                    continue;
                }
                bool a = true;
                foreach(var b in bagages)
                {
                    if (b.X == x && b.Y == y)
                    {
                        a = false;
                        break;
                    }
                }

                if (a)
                {
                    bagages[i].X = x;
                    bagages[i].Y = y;
                }
                else
                {
                    i--;
                }
            }
        }
    }
}
