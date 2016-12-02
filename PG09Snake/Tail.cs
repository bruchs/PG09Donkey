using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG09Snake
{
    class Tail
    {
        private int m_iTailDelay;
        private int m_sTailLenght;

        public Tail() { }

        public void TailMovement()
        {

                

                ConsoleColor bgColor = Console.BackgroundColor;
                ConsoleColor fgColor = Console.ForegroundColor;
                int delay = 100;
                string direction = "right";

                int snakeLength = 8;

                Random randomFoodGenerator = new Random();

                int score = 0;
                int x = 20;
                int y = 20;
                int colourTog = 1;
                bool alive = true;
                bool pelletOn = false;
                int pelletX = 0;
                int pelletY = 0;

                int[] xPoints;
                xPoints = new int[8] { 20, 19, 18, 17, 16, 15, 14, 13 };
                int[] yPoints;
                yPoints = new int[8] { 20, 20, 20, 20, 20, 20, 20, 20 };


                while (alive)
                {
                    if (pelletOn == false)
                    {
                        bool collide = false;
                        pelletOn = true;
                        pelletX = randomFoodGenerator.Next(4, Console.WindowWidth - 4);
                        pelletY = randomFoodGenerator.Next(4, Console.WindowHeight - 4);

                        for (int l = (xPoints.Length - 1); l > 1; l--)
                        {
                            if (xPoints[l] == pelletX & yPoints[l] == pelletY)
                            {
                                collide = true;
                            }
                        }
                        if (collide == true)
                        {
                            pelletOn = false;
                            break;
                        }
                        else
                        {
                            Console.SetCursorPosition(pelletX, pelletY);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.BackgroundColor = bgColor;
                            Console.Write("#");
                            pelletOn = true;
                        }

                    }
                    Array.Resize<int>(ref xPoints, snakeLength);
                    Array.Resize<int>(ref yPoints, snakeLength);

                    System.Threading.Thread.Sleep(delay);
                    colourTog++;
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(true);
                        switch (key.Key)
                        {
                            case ConsoleKey.RightArrow:
                                if (direction != "left")
                                {
                                    direction = "right";
                                }
                                break;
                            case ConsoleKey.LeftArrow:
                                if (direction != "right")
                                {
                                    direction = "left";
                                }
                                break;
                            case ConsoleKey.UpArrow:

                                if (direction != "down")
                                {
                                    direction = "up";
                                }
                                break;
                            case ConsoleKey.DownArrow:

                                if (direction != "up")
                                {
                                    direction = "down";
                                }
                                break;
                            default:
                                break;
                        }
                    } //Inputs & direction


                    if (direction == "right")
                    {
                        x += 1;
                    }
                    else if (direction == "left")
                    {
                        x -= 1;
                    }
                    else if (direction == "down")
                    {
                        y += 1;
                    }
                    else if (direction == "up")
                    {
                        y -= 1;
                    }

                    xPoints[0] = x;
                    yPoints[0] = y;

                    for (int l = (xPoints.Length - 1); l > 0; l--)
                    {
                        xPoints[l] = xPoints[l - 1];
                        yPoints[l] = yPoints[l - 1];
                    }

                    Console.SetCursorPosition(xPoints[0], yPoints[0]);

                    if (colourTog == 2)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    }
                    else
                    {
                        colourTog = 1;
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    Console.ForegroundColor = fgColor;
                    Console.Write("*");

                    Console.SetCursorPosition(xPoints[xPoints.Length - 1], yPoints[yPoints.Length - 1]);


                    Console.BackgroundColor = bgColor;
                    Console.Write(" ");

                    if (x == pelletX & y == pelletY)
                    {
                        pelletOn = false;
                        snakeLength += 1;
                        delay -= delay / 16;
                        //new Thread(() => Console.Beep(320, 250)).Start();
                    }

                    for (int l = (xPoints.Length - 1); l > 1; l--)
                    {
                        if (xPoints[l] == xPoints[0] & yPoints[l] == yPoints[0])
                        {
                            alive = false;
                        }

                    }
                    score = ((snakeLength) - 8);
                    Console.SetCursorPosition(2, 2);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("Score: {0} ", score);

                }
                //new Thread(() => Console.Beep(37, 1)).Start();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                /*

                Console.Beep(2093, 260);

                Console.Beep(1319, 260);

                Console.Beep(1047, 260);

                Console.Beep(1319, 260);

                Console.Beep(1760, 260);

                Console.Beep(1319, 260);

                Console.Beep(932, 260);

                Console.Beep(784, 260);
               

                Console.Beep(2093, 200);

                Console.Beep(1319, 200);

                Console.Beep(1047, 200);

                Console.Beep(1319, 200);

                Console.Beep(1760, 200);

                Console.Beep(1319, 200);
                */

                Console.Beep(831, 250);


                Console.Beep(785, 250);

                ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

                for (int i = 0; i < 1; i++)
                {
                    foreach (var color in colors)
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.ForegroundColor = color;
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n\n");
                        Console.WriteLine("\n                       Game over :(");
                        Console.WriteLine("\n\n                   Your score was: {0} !", score);
                        System.Threading.Thread.Sleep(100);
                    }
                }
                //Thread.Sleep(1000);
                Console.WriteLine("\n\n\n\n\n\n             -- Press Any Key To Continue --");
                //Thread.Sleep(500);
                Console.ReadKey(true);
                Console.ReadKey(true);
            }
        }
    }
