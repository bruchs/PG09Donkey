using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG09Snake
{
    class Program
    {
        private static bool m_bExit;

        static void Main(string[] args)
        {
            while (m_bExit != true)
            {
                Board myGameBoard = new Board();
                myGameBoard.drawScreen();

                Tail myDonkeyTail = new Tail(100, 8, "right");
                myDonkeyTail.TailMovement();

                myDonkeyTail.
            }
        }
    }
}
