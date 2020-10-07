using System;
using System.Collections.Generic;
using System.Text;

namespace RobotAppp228322
{
    public class Game
    {
        private Field field;

        public Game(Field field)
        {
            this.field = field;
        }
        public void Play()
        {
            field.Robot.TurnOn();
            while (true)
            {
                try
                {
                    for (int i = 0; i < field.Size; i++)
                    {
                        for (int j = 0; j < field.Size; j++)
                        {
                            if (i == field.Robot.Y && j == field.Robot.X)
                            {
                                Console.Write("R");
                                continue;
                            }

                            var b = true;
                            foreach (var baggage in field.Bagages)
                            {
                                if (i == baggage.Y && j == baggage.X)
                                {
                                    Console.Write("B");
                                    b = false;
                                    break;
                                }
                            }

                            if (b == false) continue;

                            Console.Write(".");
                        }

                        Console.WriteLine();
                    }

                    var dir = Console.ReadKey();
                    Console.Clear();
                    if (dir.Key == ConsoleKey.UpArrow)
                    {
                        field.Robot.MakeStep(1, RobotDirection.Up);
                    }
                    else if (dir.Key == ConsoleKey.DownArrow)
                    {
                        field.Robot.MakeStep(1, RobotDirection.Down);
                    }
                    else if (dir.Key == ConsoleKey.LeftArrow)
                    {
                        field.Robot.MakeStep(1, RobotDirection.Left);
                    }
                    else if (dir.Key == ConsoleKey.RightArrow)
                    {
                        field.Robot.MakeStep(1, RobotDirection.Right);
                    }
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}
