using System;
using System.Collections.Generic;
using System.Text;

namespace RobotAppp228322
{
    public class Field
    {
        public List<Bagage> Bagages { get; }
        public Robot Robot { get; }
        public int Size { get; }

        public Field(int size, Robot robot, List<Bagage> bagages)
        {
            this.Size = size;
            this.Robot = robot;
            this.Bagages = bagages;
        }
    }
}
