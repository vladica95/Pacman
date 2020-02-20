using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Ghost : PacObject
    {
        private Boolean eatable;
        private int positionX;
        private int positionY;
        private int movesEatable;

        public Ghost(int x,int y)
        {
            this.eatable = false;
            this.positionX = x;
            this.positionY = y;
            this.movesEatable = 0;
        }
        public int MovesEatable
        {
            get { return this.movesEatable; }
            set { this.movesEatable = value; }
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
        public Boolean Eatable
        {
            get { return this.eatable; }
            set { this.eatable = value; }
        }

        public void GhostMove(int x, int y)
        {
            this.PositionX = x;
            this.PositionY = y;
        }
        public void GhostAttack(int x,int y)
        {

        }
        public override void Print()
        {
            if (Eatable)
            {
                Console.Write("$");
            }
           else Console.Write("@");
        }
    }
}
