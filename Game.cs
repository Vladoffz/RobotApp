using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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
                if (field.Robot.Battery <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    for (int i = 0; i < 7; i++)
                    {
                        Console.WriteLine("Game over, your score is: " + field.Robot.Bagages.Sum(x => x.Cost));
                        Thread.Sleep(500);
                        Console.Clear();
                        Thread.Sleep(100);
                    }
                    Console.WriteLine("Game over, your score is: " + field.Robot.Bagages.Sum(x => x.Cost));
                    Thread.Sleep(500);
                    Console.Write("Steps made: ");

                    var stepsSum = field.Robot.GetStepsCount(RobotDirection.Left) +
                                   field.Robot.GetStepsCount(RobotDirection.Right) +
                                   field.Robot.GetStepsCount(RobotDirection.Up) +
                                   field.Robot.GetStepsCount(RobotDirection.Down);
                    Thread.Sleep(500);
                    Console.WriteLine(stepsSum);
                    Thread.Sleep(500);
                    Console.WriteLine("Up: " + field.Robot.GetStepsCount(RobotDirection.Up));
                    Thread.Sleep(500);
                    Console.WriteLine("Down: " + field.Robot.GetStepsCount(RobotDirection.Down));
                    Thread.Sleep(500);
                    Console.WriteLine("Left: " + field.Robot.GetStepsCount(RobotDirection.Left));
                    Thread.Sleep(500);
                    Console.WriteLine("Right: " + field.Robot.GetStepsCount(RobotDirection.Right));
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
                }
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Battery: " + field.Robot.Battery + "      State: " +
                                      field.Robot.GetCurrentState() + "       Score: " +
                                      field.Robot.Bagages.Sum(x => x.Cost));
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Class: " + field.Robot.GetType().ToString().Substring(16) + "\n");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Bagages:\n");
                    foreach (var i in field.Robot.Bagages.GroupBy(x => x.GetType()))
                    {
                        Console.WriteLine(i.Key.ToString().Substring(16) + " " + i.Count());
                    }

                    Console.ResetColor();


                    for (int i = 0; i < field.Size; i++)
                    {
                        for (int j = 0; j < field.Size; j++)
                        {
                            if (i == field.Robot.Y && j == field.Robot.X)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("R    ");
                                Console.ResetColor();
                                continue;
                            }

                            var b = true;
                            foreach (var baggage in field.Bagages)
                            {
                                if (i == baggage.Y && j == baggage.X)
                                {
                                    Console.Write("B    ");
                                    b = false;
                                    break;
                                }
                            }

                            int size = field.Bagages.Count;
                            for (int z = 0; z < size; z++)
                            {
                                if (field.Robot.X == field.Bagages[z].X && field.Robot.Y == field.Bagages[z].Y)
                                {
                                    if (field.Bagages[z].GetType() == typeof(DecodingBaggage))
                                    {

                                        Random rnd2 = new Random();
                                        var res = rnd2.Next(0, 100);
                                        if (res > field.Robot.DecodeProbability)
                                        {
                                            if (field.Robot.lastDirection == RobotDirection.Right) field.Robot.MakeStep(1, RobotDirection.Left);
                                            if (field.Robot.lastDirection == RobotDirection.Left) field.Robot.MakeStep(1, RobotDirection.Right);
                                            if (field.Robot.lastDirection == RobotDirection.Down) field.Robot.MakeStep(1, RobotDirection.Up);
                                            if (field.Robot.lastDirection == RobotDirection.Up) field.Robot.MakeStep(1, RobotDirection.Down);
                                            break;
                                        }
                                        else
                                        {
                                            field.Robot.Bagages.Add(field.Bagages[z]);
                                            field.Bagages.Remove(field.Bagages[z]);
                                            break;
                                        }
                                    }

                                    field.Robot.Bagages.Add(field.Bagages[z]);
                                    field.Bagages.Remove(field.Bagages[z]);
                                    break;
                                }
                            }

                            if (b == false) continue;

                            Console.Write(".    ");
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
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(2000);
                    Console.Clear();
                    continue;
                }
            }
        }
    }
}
