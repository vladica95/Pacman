using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class BigCrumb : Crumb
    {
        public BigCrumb() : base (10)
        {

        }
        public override void Print()
        {
            Console.Write("o");
        }
    }
}
