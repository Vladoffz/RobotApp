using System;
using System.Collections.Generic;
using System.Text;

namespace RobotAppp228322
{
    public class Field
    {
        public List<IBagage> Bagages { get; }
        public IRobot Robot { get; }
        public int Size { get; }

        public Field(int size, IRobot robot, List<IBagage> bagages)
        {
            this.Size = size;
            this.Robot = robot;
            this.Bagages = bagages;
        }
    }
}
