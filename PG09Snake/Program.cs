using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace PG09Snake
{
    class Program
    {
        private static void TitleScreen()
        {
            Console.Clear();   
            Console.WriteLine(    " ____              _              _       _____     _      " +
            Environment.NewLine +@"|  _ \  ___  _ __ | | _____ _   _( )___  |_   _|_ _| | ___ " +
            Environment.NewLine +@"| | | |/ _ \| '_ \| |/ / _ \ | | |// __|   | |/ _` | |/ _ \" +
            Environment.NewLine +@"| |_| | (_) | | | |   <  __/ |_| | \__ \   | | (_| | |  __/" +
            Environment.NewLine +@"|____/ \___/|_| |_|_|\_\___|\__, | |___/   |_|\__,_|_|\___|" +
            Environment.NewLine +@"                            |___/                          ");
        }

        private static bool m_bExit;

        static void Main(string[] args)
        {

            int m_iScore = 0;

            TitleScreen();
            while (m_bExit != true)
            {
                //// Create a new SoundPlayer for the background music.
                //SoundPlayer music = new SoundPlayer();
                //// Search for the audio file.
                //music.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Music.wav";
                //// PlayLooping to get music trough the whole gameplay.
                //music.PlayLooping();

                Board myGameBoard = new Board();
                myGameBoard.drawScreen();

                Tail myDonkeyTail = new Tail(100, 8, "Up");
                myDonkeyTail.TailMovement();

                //We subtract 8 from the length of the tail so the score begins at 0.
                m_iScore = ((myDonkeyTail.m_iTailLenght) - 8);
                Console.SetCursorPosition(2, 2);
                Console.WriteLine("Score: {0}", m_iScore);
            }
         }
    }
}
