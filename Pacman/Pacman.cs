using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Pacman : PacObject
    {
        private int positionX;
        private int positionY;

        public Pacman()
        {
            
        }

        public int PositionX
        {
            get { return this.positionX; }
            set { this.positionX = value; }
        }
        public int PositionY
        {
            get { return this.positionY; }
            set { this.positionY = value; }
        }

        public void PacmanMove(int x, int y)
        {
            this.PositionX = x;
            this.PositionY = y;
        }

        public override void Print()
        {
            Console.Write("C");
        }


    }
}
