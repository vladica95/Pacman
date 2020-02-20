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
        private int score;
        private int lifes;

        public Player()
        {
            Console.WriteLine("Enter name of player: ");
            Name = Console.ReadLine();
            score = 0;
            lifes = 3;
        }

        public Player(String name, int score)
        {
            Name = name;
            Score = score;
        }
        public void AddPoints(int points)
        {
            this.score = score + points;
        }
        public void LoseLife()
        {
            this.lifes--;
        }
        public void PrintScore()
        {
            Console.WriteLine("Score: " + score + "   Lifes: " + lifes);
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
