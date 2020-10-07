using System;

namespace RobotAppp228322
{
    public class ConsoleCommand : ICommand
    {
        public void General<T>(T message)
        {
            Console.WriteLine(message);
        }

        public void Success<T>(T message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void Error<T>(T message)
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
