using System;

namespace RobotAppp228322
{
    class RobotCommands
    {
        private readonly Robot robot;
        private readonly ICommand command;

        public RobotCommands(Robot robot, ICommand command)
        {
            this.robot = robot;
            this.command = command;
        }

        public void TurnOn()
        {
            robot.TurnOn();
            command.Success("robot is on");
        }

        public void TurnOff()
        {
            robot.TurnOff();
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
            catch (Exception)
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
                command.General(robot.GetStepsCount((RobotDirection)direction));
            }
            catch (Exception)
            {
                command.Error("wrong command");
            }
        }
    }
}
