using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG09Snake
{
    class Tail
    {
        public int m_iTailDelay;
        public int m_iTailLenght;
        public string m_sTailDirection;
        private bool m_bIsTailAlive = true;

        public Tail(int tailDelay, int tailLenght, string tailDirection)
        {
            this.m_iTailDelay = tailDelay;
            this.m_iTailLenght = tailLenght;
            this.m_sTailDirection = tailDirection;
        }

        public void TailMovement()
        {

            ConsoleColor bgColor = Console.BackgroundColor;
            ConsoleColor fgColor = Console.ForegroundColor;

            Random randomFoodGenerator = new Random();

            int x = 20;
            int y = 20;

            bool pelletOn = false;
            int pelletX = 0;
            int pelletY = 0;

            int[] xPoints;
            xPoints = new int[8] { 20, 19, 18, 17, 16, 15, 14, 13 };
            int[] yPoints;
            yPoints = new int[8] { 20, 20, 20, 20, 20, 20, 20, 20 };


            while (m_bIsTailAlive)
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
                Array.Resize<int>(ref xPoints, m_iTailLenght);
                Array.Resize<int>(ref yPoints, m_iTailLenght);

                System.Threading.Thread.Sleep(m_iTailDelay);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.RightArrow:
                            if (m_sTailDirection != "left")
                            {
                                m_sTailDirection = "right";
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (m_sTailDirection != "right")
                            {
                                m_sTailDirection = "left";
                            }
                            break;
                        case ConsoleKey.UpArrow:

                            if (m_sTailDirection != "down")
                            {
                                m_sTailDirection = "up";
                            }
                            break;
                        case ConsoleKey.DownArrow:

                            if (m_sTailDirection != "up")
                            {
                                m_sTailDirection = "down";
                            }
                            break;
                        default:
                            break;
                    }
                } //Inputs & direction


                if (m_sTailDirection == "right")
                {
                    x += 1;
                }
                else if (m_sTailDirection == "left")
                {
                    x -= 1;
                }
                else if (m_sTailDirection == "down")
                {
                    y += 1;
                }
                else if (m_sTailDirection == "up")
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
                    

                Console.ForegroundColor = fgColor;
                Console.Write("=");

                Console.SetCursorPosition(xPoints[xPoints.Length - 1], yPoints[yPoints.Length - 1]);


                Console.BackgroundColor = bgColor;
                Console.Write(" ");

                if (x == pelletX & y == pelletY)
                {
                    pelletOn = false;
                    m_iTailLenght += 1;
                    m_iTailDelay -= m_iTailDelay / 16;
                    //new Thread(() => Console.Beep(320, 250)).Start();
                }

                for (int l = (xPoints.Length - 1); l > 1; l--)
                {
                    if (xPoints[l] == xPoints[0] & yPoints[l] == yPoints[0])
                    {
                        m_bIsTailAlive = false;
                    }

                }

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

        }
    }
}
