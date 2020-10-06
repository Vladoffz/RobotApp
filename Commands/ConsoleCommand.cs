using System;
using System.Collections.Generic;
using System.Text;

namespace RobotAppp228322
{
    public class ConsoleCommand : ICommand
    {
        public void General(object message)
        {
            Console.WriteLine(message);
        }

        public void Success(object message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void Error(object message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public int InputToInt(string message)
        {
            Console.WriteLine(message);
            var result = Convert.ToInt32(Console.ReadLine());
            return result;
        }

    }
}
