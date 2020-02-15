using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Program
    {
        static void Main(string[] args)
        {
            Crumb mrvica = new LittleCrumb();
            Crumb mrva = new BigCrumb();
            Console.WriteLine(mrvica.Points);
            Console.WriteLine(mrva.Points);
        }
    }
}
