using System;
using System.Collections.Generic;
using System.Linq;
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

        public void TitleScreen()
        {

            Console.Clear();

            Console.WriteLine("\n   ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄  ");
            Console.WriteLine("   ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░  ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(     "            ____              _              _       _____     _      " +
            Environment.NewLine + @"           |  _ \  ___  _ __ | | _____ _   _( )___  |_   _|_ _| | ___ " +
            Environment.NewLine + @"           | | | |/ _ \| '_ \| |/ / _ \ | | |// __|   | |/ _` | |/ _ \" +
            Environment.NewLine + @"           | |_| | (_) | | | |   <  __/ |_| | \__ \   | | (_| | |  __/" +
            Environment.NewLine + @"           |____/ \___/|_| |_|_|\_\___|\__, | |___/   |_|\__,_|_|\___|" +
            Environment.NewLine + @"                                       |___/                          ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n   ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄  ");
            Console.WriteLine("   ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ \n\n ");


            Console.WriteLine("               ░░░░░░░░░░   PRESS 'ENTER' TO CONTINUE  ░░░░░░░░  ");
        }

        public void GameOver()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n   ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄  ");
            Console.WriteLine("   ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░  ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(     "               _____                         ____                  _ " +
            Environment.NewLine + @"              / ____|                       / __ \                | |" +
            Environment.NewLine + @"             | |  __  __ _ _ __ ___   ___  | |  | |_   _____ _ __ | |" +
            Environment.NewLine + @"             | | |_ |/ _` | '_ ` _ \ / _ \ | |  | \ \ / / _ \ '__|| |" +
            Environment.NewLine + @"             | |__| | (_| | | | | | |  __/ | |__| |\ V /  __/ |   |_|" +
            Environment.NewLine + @"              \_____|\__,_|_| |_| |_|\___|  \____/  \_/ \___|_|   (_)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n   ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄ ▄▄  ");
            Console.WriteLine("   ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ ░░ \n\n ");

            Console.ReadLine();
        }

        public void drawScreen()
        {
            Console.CursorVisible = (false);
            Console.Title = "Donkey's Tale";
            Console.SetWindowSize(80, 40);

            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }
    }
}
