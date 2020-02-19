using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class EmptySpot:PacObject
    {
        public EmptySpot()
        {

        }
        public override void Print()
        {
            Console.Write(" ");
        }
    }
}
