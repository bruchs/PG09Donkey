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

        private static bool m_bExit;

        static void Main(string[] args)
        {

            while (m_bExit != true)
            {
                //// Create a new SoundPlayer for the background music.
                SoundPlayer music = new SoundPlayer();
                //// Search for the audio file.
                music.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Music.wav";
                //// PlayLooping to get music trough the whole gameplay.
                music.PlayLooping();

                Board myGameBoard = new Board();
                myGameBoard.drawScreen();

                myGameBoard.TitleScreen();
                Console.ReadLine();
                Console.Clear();

                Tail myDonkeyTail = new Tail(100, 8, "Up");
                myDonkeyTail.TailMovement();

                myGameBoard.GameOver();
            }
         }
    }
}
