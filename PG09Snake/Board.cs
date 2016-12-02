using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG09Snake
{
    class Board
    {

        public Board() { }

        public void drawScreen()
        {
            Console.CursorVisible = (false);
            Console.Title = "Donkey's Tale";
            Console.SetWindowSize(56, 38);

            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }
    }
}
