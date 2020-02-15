using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    abstract class Crumb : PacObject
    {
        private int points;
        public Crumb(int x)
        {
            this.points = x;
        }
        public int Points
        {
            get { return this.points; }
        }
        public abstract  override void Print();
       
    }
}
