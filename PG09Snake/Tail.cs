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

        int x = 20;
        int y = 20;

        bool pelletOn = false;
        int pelletX = 0;
        int pelletY = 0;

        int[] xPoints = {20, 19, 18, 17, 16, 15, 14, 13 };
        int[] yPoints = { 20, 20, 20, 20, 20, 20, 20, 20 };
        Random randomFoodGenerator = new Random();

        public Tail(int tailDelay, int tailLenght, string tailDirection)
        {
            this.m_iTailDelay = tailDelay;
            this.m_iTailLenght = tailLenght;
            this.m_sTailDirection = tailDirection;
        }

        public void TailFood()
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
                    
                }
                else
                {
                    Console.SetCursorPosition(pelletX, pelletY);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write("#");
                    pelletOn = true;
                }
            }
        }

        public void TailMovement()
        {           
            while (m_bIsTailAlive)
            {

                TailFood();
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
                } 
                //Inputs & direction

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
                    

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("=");

                Console.SetCursorPosition(xPoints[xPoints.Length - 1], yPoints[yPoints.Length - 1]);

                // Use Console.BackgroundColor for eliminate the tail of the donkey that is not being used.
                Console.BackgroundColor = ConsoleColor.Black;
                // Use Console.WriteLine to replace the '=' donkey's tail with a blank space.
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
          
        }
    }
}
