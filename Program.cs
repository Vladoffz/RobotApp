using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace RobotAppp228322
{
    class Program
    {
        static void Main(string[] args)
        {
            GeneratingField gf = new GeneratingField();
            var field = gf.Generate(20);
            Game game = new Game(field);
            game.Play();


            //Menu menu = new Menu(new ConsoleCommand());
            //Robot robot = new Robot();
            //ICommand command = new ConsoleCommand();
            //RobotCommands commands = new RobotCommands(robot, command);
            //menu.Work(new string[]{"turn on", "turn off", "make step", "get robot's state", "get state's count"}, 
            //    new Action[]{commands.TurnOn, commands.TurnOff, commands.MakeStep, commands.GetState, commands.StatesCount});
        }
    }
}
