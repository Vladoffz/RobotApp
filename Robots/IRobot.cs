using System.Collections.Generic;
using System.Drawing;

namespace RobotAppp228322
{
    public interface IRobot
    {
        int Id { get; set; }
        string Avatar { get; set; }
        string Name { get; set; }
        int Battery { get; set; }
        int LoadCapacity { get; set; }
        int DecodeProbability { get; set; }
        List<IBagage> Bagages { get; set; }
        int X { get; set; }
        int Y { get; set; }
        RobotDirection lastDirection { get; set; }
        void TurnOn();
        void TurnOff();
        void MakeStep(int x, RobotDirection direction);
        Point GetCurrentState();
        int GetStepsCount(RobotDirection direction);

    }
}