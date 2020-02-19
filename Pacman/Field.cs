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
        private Ghost ghost;
        private Ghost[] ghosts;
        private Ghost[] eatenGhosts;
        private Crumb bigCrumb;
        private Crumb littleCrumb;
        private EmptySpot empty;
        private Wall wall;
        private int fieldSize;
        private int crumbNumber;
        private static readonly Random rand = new Random();

        public Field()
        {
            pakman = new Pacman();
            empty = new EmptySpot();
            bigCrumb = new BigCrumb();
            littleCrumb = new LittleCrumb();
            wall = new Wall();
            crumbNumber = 0;
            fieldSize = 20;
            ghosts = new Ghost[4];
            field = new PacObject[fieldSize, fieldSize];

            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    if (i == 0 || j == 0 || i == fieldSize - 1 || j == fieldSize - 1)
                    {
                        this.field[i, j] = wall;
                    }
                    else
                    {
                        if (rand.Next(1, 3824) % 29 == 0)
                        {
                            this.field[i, j] = bigCrumb; //postavljanje velikih kruzica
                            crumbNumber++;
                        }
                        else
                        {
                            this.field[i, j] = littleCrumb; //postavljanje malih kruzica
                            crumbNumber++;
                        }
                    }
                }
            }

            Reset();

        }
        public void Print()
        {
            for (int i = 0; i < ghosts.Length; i++)
            {
                ghosts[i].PrintK();
                /*  for (int i = 0; i < fieldSize; i++)
                  {
                        for (int j = 0; j < fieldSize; j++)
                        {
                            this.field[i, j].Print();
                       }      */
                Console.WriteLine();
            }
        }
        public void Reset()
        {
            int p = 0;
            while (p < ghosts.Length)
            {
                for (int j = 0; j < ghosts.Length / 2; j++)
                {
                    for (int k = 0; k < ghosts.Length / 2; k++)
                    {
                        ghost= new Ghost(fieldSize / 2 - 1 + j, fieldSize / 2 - 1 + k);
                        this.ghosts[p] = ghost;
                        this.field[fieldSize / 2 - 1 + j, fieldSize / 2 - 1 + k] = ghost;
                        p++;
                    }
                }
                this.field[fieldSize - 2, fieldSize - 4] = pakman;
                pakman.PositionX = fieldSize - 2;
                pakman.PositionY = fieldSize - 4;
            }
        }
        public int PacmanMove(string a)
        {
            int returnPoints=0;
            if (a == "w")
            {
                if (pakman.PositionX - 1 > 0)
                {
                    if (this.field[pakman.PositionX - 1, pakman.PositionY] == empty)
                    {
                        this.field[pakman.PositionX - 1, pakman.PositionY] = pakman;
                        this.field[pakman.PositionX, pakman.PositionY] = empty;
                        this.pakman.PositionX = pakman.PositionX - 1;
                        returnPoints = 0;
                    }
                    else if (this.field[pakman.PositionX - 1, pakman.PositionY] == littleCrumb)
                    {
                        this.crumbNumber--;
                        this.field[pakman.PositionX - 1, pakman.PositionY] = pakman;
                        this.field[pakman.PositionX, pakman.PositionY] = empty;
                        this.pakman.PositionX = pakman.PositionX - 1;
                        returnPoints = littleCrumb.Points;
                    }
                    else if (this.field[pakman.PositionX - 1, pakman.PositionY] == bigCrumb)
                    {
                        this.crumbNumber--;
                        this.field[pakman.PositionX - 1, pakman.PositionY] = pakman;
                        this.field[pakman.PositionX, pakman.PositionY] = empty;
                        this.pakman.PositionX = pakman.PositionX - 1;
                        returnPoints = bigCrumb.Points;

                    }
                    else if (this.field[pakman.PositionX - 1, pakman.PositionY] == ghost)
                    {
                        this.field[pakman.PositionX, pakman.PositionY] = empty;
                        Reset();
                        returnPoints = -1;
                    }
                }
                else
                {
                    Console.WriteLine("You hit the wall.");
                    returnPoints = 0;
                }


            }
            else if (a == "a")
            {
                return 0;
            }
            else if (a == "s")
            {
                return 0;
            }
            else if (a == "d")
            {
                return 0;
            }

            else {
                Console.WriteLine("Wrong komand!");
                return 0;
            }
            return returnPoints;
        }

        public void GhostAttack()
        {
            for (int i = 0; i < this.ghosts.Length; i++)
            {
                this.ghosts[i].GhostAttack(pakman.PositionX,pakman.PositionY);
            }
        }



    }
}

