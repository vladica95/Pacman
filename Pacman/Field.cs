using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Field
    {
        private PacObject[,] field;
        private Pacman pakman;
        private Ghost[] ghosts;
        private Ghost[] eatenGhosts;
        private Crumb crumb;
        private int fieldSize;
        private static readonly Random rand = new Random();

        public Field()
        {
            pakman = new Pacman();
            fieldSize = 20;
            ghosts = new Ghost[4];
            field = new PacObject[fieldSize, fieldSize];

            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    if (i == 0 || j == 0 || i == fieldSize - 1 || j == fieldSize - 1)
                    {
                        this.field[i, j] = new Wall();
                    }
                    else
                    {
                        if (rand.Next(1, 3824) % 29 == 0)
                        {
                            this.field[i, j] = new BigCrumb(); //postavljanje velikih kruzica
                        }
                        else
                        {
                            this.field[i, j] = new LittleCrumb(); //postavljanje malih kruzica
                        }
                    }
                }
            }
            int p = 0;
            while (p < ghosts.Length)
            {
                for (int j = 0; j < ghosts.Length / 2; j++)
                {
                    for (int k = 0; k < ghosts.Length / 2; k++)
                    {
                        this.ghosts[p] = new Ghost();
                        this.field[fieldSize / 2 - 1 + j, fieldSize / 2 - 1 + k] = ghosts[p];
                        p++;
                    }
                    
                }
                this.field[fieldSize - 2, fieldSize - 4] = pakman;
            }
        }
        public void Print()
        {
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    this.field[i, j].Print();
                }
                Console.WriteLine();
            }
        } 






    }
}

