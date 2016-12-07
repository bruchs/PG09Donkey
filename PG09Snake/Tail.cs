using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PG09Snake
{
    class Tail
    {

        public int m_iTailDelay;
        public int m_iTailLenght;
        public string m_sTailDirection;
        int m_iScore = 0;
        private bool m_bIsTailAlive = true;

        // Keep the reference for the tail position
        private int m_xTailPosition = 15;
        private int m_yTailPosition = 15;

        private bool m_bAss = false;
        int pelletX = 0;
        int pelletY = 0;

        int w = Console.WindowWidth;
        int h = Console.WindowHeight;

        private int[] m_xTailPoints;
        private int[] m_yTailPoints;

        Random randomFoodGenerator = new Random();

        public Tail(int tailDelay, int tailLenght, string tailDirection)
        {
            this.m_iTailDelay = tailDelay;
            this.m_iTailLenght = tailLenght;
            this.m_sTailDirection = tailDirection;

            this.m_xTailPoints = new int[8];
            this.m_yTailPoints = new int[8];
        }


        public void TailFood()
        {
            // Checks if the fo
            if (m_bAss != true)
            {
                bool assTouch = false;
                m_bAss = true;
                pelletX = randomFoodGenerator.Next(4, Console.WindowWidth - 4);
                pelletY = randomFoodGenerator.Next(4, Console.WindowHeight - 4);

                for (int l = (m_xTailPoints.Length - 1); l > 1; l--)
                {
                    if (m_xTailPoints[l] == pelletX & m_yTailPoints[l] == pelletY)
                    {
                        assTouch = true;
                    }
                }

                if (assTouch == true)
                {
                    m_bAss = false;

                }
                else
                {
                    Console.SetCursorPosition(pelletX, pelletY);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write("X");

                    Console.BackgroundColor = ConsoleColor.Black;
                    m_bAss = true;
                }
            }

            if (m_xTailPosition == pelletX & m_yTailPosition == pelletY)
            {
                m_bAss = false;
                m_iTailLenght += 1;
                m_iTailDelay -= m_iTailDelay / 16;

                new Thread(() => Console.Beep(520, 250)).Start();
            }
        }

        public void InputMovement()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.RightArrow:
                        if (m_sTailDirection != "Left")
                        {
                            m_sTailDirection = "Right";
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (m_sTailDirection != "Right")
                        {
                            m_sTailDirection = "Left";
                        }
                        break;

                    case ConsoleKey.UpArrow:

                        if (m_sTailDirection != "Down")
                        {
                            m_sTailDirection = "Up";
                        }
                        break;

                    case ConsoleKey.DownArrow:

                        if (m_sTailDirection != "Up")
                        {
                            m_sTailDirection = "Down";
                        }
                        break;

                    default:
                        break;
                }
            }
            //Inputs & direction

            if (m_sTailDirection == "Right")
            {
                m_xTailPosition += 1;
            }

            else if (m_sTailDirection == "Left")
            {
                m_xTailPosition -= 1;
            }

            else if (m_sTailDirection == "Down")
            {
                m_yTailPosition += 1;
            }

            else if (m_sTailDirection == "Up")
            {
                m_yTailPosition -= 1;
            }
        }

        public void TailMovement()
        {
            while (m_bIsTailAlive)
            {

                TailFood();

                // Change the size of my TailPoints by my TailLenght
                Array.Resize(ref m_xTailPoints, m_iTailLenght);
                Array.Resize(ref m_yTailPoints, m_iTailLenght);

                System.Threading.Thread.Sleep(m_iTailDelay);

                InputMovement();

                // Starting Points for the tail
                m_xTailPoints[0] = m_xTailPosition;
                m_yTailPoints[0] = m_yTailPosition;

                for (int i = (m_xTailPoints.Length - 1); i > 0; i--)
                {
                    m_xTailPoints[i] = m_xTailPoints[i - 1];
                    m_yTailPoints[i] = m_yTailPoints[i - 1];
                }

                try
                {
                    Console.SetCursorPosition(m_xTailPoints[0], m_yTailPoints[0]);
                }
                catch
                {
                    new Thread(() => Console.Beep(200, 250)).Start();
                    m_bIsTailAlive = false;
                }



                Console.ForegroundColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.Write("O");

                Console.SetCursorPosition(m_xTailPoints[m_xTailPoints.Length - 1], m_yTailPoints[m_yTailPoints.Length - 1]);

                // Use Console.BackgroundColor for eliminate the tail of the donkey that is not being used.
                Console.BackgroundColor = ConsoleColor.Black;
                // Use Console.WriteLine to replace the '=' donkey's tail with a blank space.
                Console.Write(" ");

                            //We subtract 8 from the length of the tail so the score begins at 0 and updates as the tail grows.
                m_iScore = ((m_iTailLenght) - 8);
                Console.SetCursorPosition(1, 1);
                Console.WriteLine("Score: {0}", m_iScore);

                // Collision with the tail
                for (int i = (m_xTailPoints.Length - 1); i > 1; i--)
                {
                    if (m_xTailPoints[i] == m_xTailPoints[0] && m_yTailPoints[i] == m_yTailPoints[0])
                    {
                        m_bIsTailAlive = false;
                    }
                }

                if (m_xTailPosition >= w || m_yTailPosition >= h)
                {

                }

            }
            Console.SetCursorPosition(2, 2);
            Console.Clear();

        }
        public void Score()
        {

        }
    }
}
