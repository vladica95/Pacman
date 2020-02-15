using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Player
    {
        private String name;
        private int score = 0;
        private int lifes = 3;

        public Player()
        {
            Console.WriteLine("Enter name of player: ");
            Name = Console.ReadLine();
           
        }

        public Player(String name, int score)
        {
            Name = name;
            Score = score;
        }

        public void SaveScore(TextWriter textWriter)
        {
            textWriter.WriteLine(Name + " " + Score);

        }
        #region Properties
        public String Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Lifes
        {
            get { return this.lifes; }
            set { this.lifes = value; }
        }

        public int Score
        {
            get { return this.score; }
            set { this.score = value; }
        }
        #endregion
    }
}
