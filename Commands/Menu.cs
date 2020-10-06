using System;
using System.Collections.Generic;
using System.Text;

namespace RobotAppp228322
{
    class Menu
    {
        public ICommand command { get; set; }

        public Menu(ICommand command)
        {
            this.command = command;
        }

        public void Work(string[] commands, Action[] methods)
        {
            while (true)
            {
                for (int i = 0; i < commands.Length; i++)
                {
                    command.General(i+1 +": " +commands[i]);
                }

                var commandNumber = command.InputToInt("");
                methods[commandNumber-1].Invoke();
            }
        }

    }
}
