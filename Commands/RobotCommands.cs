using System;
using System.Collections.Generic;
using System.Text;

namespace RobotAppp228322
{
    class RobotCommands
    {
        private Robot robot;
        private ICommand command;

        public RobotCommands(Robot robot, ICommand command)
        {
            this.robot = robot;
            this.command = command;
        }
        public void TurnOn()
        {
            this.robot.TurnOn();
            command.Success("robot is on");
        }

        public void TurnOff()
        {
            this.robot.TurnOff();
            command.Success("robot is off");
        }

        public void MakeStep()
        {
            try
            {
                var length = command.InputToInt("enter step's length");
                var direction = command.InputToInt("enter direction (1:left, 2:right, 3:up, 4:down)");
                robot.MakeStep(length, (RobotDirection)direction);
                command.Success("success");
            }
            catch (ArgumentException ex)
            {
                command.Error(ex.Message);
            }
            catch
            {
                command.Error("wrong command");
            }
        }

        public void GetState()
        {
            command.General(robot.GetCurrentState());
        }

        public void StatesCount()
        {
            try
            {
                var direction = command.InputToInt("enter direction (1:left, 2:right, 3:up, 4:down)");
                command.General(robot.GetStepsCount((RobotDirection) direction));
            }
            catch
            {
                command.Error("wrong command");
            }
        }

    }
}
