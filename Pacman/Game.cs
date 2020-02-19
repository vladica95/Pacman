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
            field.GhostAttack();
        }
    }
}
