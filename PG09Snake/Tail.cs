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
        private int m_iTailLength;
        private string m_sTailDirection;

        private int m_xTailPosition = 20;
        private int m_yTailPosition = 20;

        private bool m_bIsTailAlive = true;

        int[] xPoints;
        int[] yPoints;

        public void SnakeAlive()
        {            
            xPoints = new int[8] { 20, 19, 18, 17, 16, 15, 14, 13 };
            yPoints = new int[8] { 20, 20, 20, 20, 20, 20, 20, 20 };

            while (m_bIsTailAlive != false)
            {
                Array.Resize<int>(ref xPoints, m_iTailLength);
                Array.Resize<int>(ref yPoints, m_iTailLength);

                System.Threading.Thread.Sleep(m_iTailDelay);
            }
        }
    }
}
