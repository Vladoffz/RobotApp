using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RobotAppp228322
{
    public enum RobotDirection
    {
        None,
        Left,
        Right,
        Up,
        Down
    }
    public class Robot
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
        public int Battery { get; set; }
        public int LoadCapacity { get; set; }

        public int DecodeProbability { get; set; }

        public bool state = false;
        public int X { get; set; }
        public int Y { get; set; }

        private Dictionary<RobotDirection, int> dictionary = new Dictionary<RobotDirection, int>();

        private RobotDirection lastDirection = RobotDirection.None;

        public Robot()
        {
            dictionary[RobotDirection.Right] = 0;
            dictionary[RobotDirection.Left] = 0;
            dictionary[RobotDirection.Up] = 0;
            dictionary[RobotDirection.Down] = 0;
        }
        public void TurnOn()
        {
            state = true;
        }
        public void TurnOff()
        {
            state = false;
        }
        public void MakeStep(int x, RobotDirection direction)
        {
            if (state)
            {
                if (this.lastDirection == direction)
                {
                    throw new ArgumentException("robot can't go to the same direction");
                }

                var tempX = this.X;
                var tempY = this.Y;

                if (direction == RobotDirection.Down) this.Y += x;
                else if (direction == RobotDirection.Up) this.Y -= x;
                else if (direction == RobotDirection.Right) this.X += x;
                else if (direction == RobotDirection.Left) this.X -= x;
                if (this.X > 100 || this.X < 0 || this.Y > 100 || this.Y < 0)
                {
                    this.X = tempX;
                    this.Y = tempY;
                    throw new ArgumentException("robot is outside of a field");
                }
                lastDirection = direction;
                dictionary[direction]++;
            }
            else
            {
                throw new ArgumentException("robot is off");
            }
        }
        public Point GetCurrentState()
        {
            return new Point(X, Y);
        }
        public int GetStepsCount(RobotDirection direction)
        {
            return dictionary[direction];
        }
    }
}
