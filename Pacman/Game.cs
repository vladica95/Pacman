using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Game
    {
        private Field field;

        public Game()
        {
            field = new Field();
            field.Print();

        }
        public Boolean Crumbs()
        {
            if (field.Crumbs>0)
            return true;
            else return false;
        }
        public int PacmanMove(string move)
        {
            int points= field.PacmanMove(move);
            field.Print();
            return points;
        }
    }
}
