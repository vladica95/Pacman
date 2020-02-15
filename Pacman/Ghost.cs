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
        public Ghost()
        {
            this.eatable = false;

        }
        public Boolean Eatable
        {
            get { return this.eatable; }
            set { this.eatable = value; }
        }
        public override void Print()
        {
            Console.Write("@");
        }
    }
}
