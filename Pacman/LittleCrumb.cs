using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class LittleCrumb : Crumb
    {
        public LittleCrumb():base (2)
        {
            
        }
        public override void Print()
        {
            Console.Write(".");
        }
    }
}
