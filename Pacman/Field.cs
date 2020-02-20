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
        private Crumb bigCrumb;
        private Crumb littleCrumb;
        private EmptySpot empty;
        private Wall wall;
        private int fieldSize;
        private int crumbNumber;
        private static readonly Random rand = new Random();

        public int Crumbs
        {
            get { return this.crumbNumber; }
        }

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
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    this.field[i, j].Print();
                }
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
                        this.ghosts[p] = new Ghost(fieldSize / 2 - 1 + j, fieldSize / 2 - 1 + k);
                        this.field[ghosts[p].PositionX, ghosts[p].PositionY] = ghosts[p];
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
                        ReduceEatableMoves();
                        returnPoints = 0;
                    }
                    else if (this.field[pakman.PositionX - 1, pakman.PositionY] == littleCrumb)
                    {
                        this.crumbNumber--;
                        this.field[pakman.PositionX - 1, pakman.PositionY] = pakman;
                        this.field[pakman.PositionX, pakman.PositionY] = empty;
                        this.pakman.PositionX = pakman.PositionX - 1;
                        ReduceEatableMoves();
                        returnPoints = littleCrumb.Points;
                    }
                    else if (this.field[pakman.PositionX - 1, pakman.PositionY] == bigCrumb)
                    {
                        this.crumbNumber--;
                        this.field[pakman.PositionX - 1, pakman.PositionY] = pakman;
                        this.field[pakman.PositionX, pakman.PositionY] = empty;
                        this.pakman.PositionX = pakman.PositionX - 1;
                        ReduceEatableMoves();
                        MakeThemEatable();
                        returnPoints = bigCrumb.Points;

                    }
                    else if (FindGhost(pakman.PositionX - 1, pakman.PositionY) != null)
                    {
                        if (!CheckGhostEatable(pakman.PositionX - 1, pakman.PositionY))
                        {
                            this.field[pakman.PositionX, pakman.PositionY] = empty;
                            for (int i = 0; i < this.ghosts.Length; i++)
                            {
                                this.field[ghosts[i].PositionX, ghosts[i].PositionY]=empty;
                            }
                            Reset();
                            returnPoints = -1;
                        }
                        else
                        {
                            ResetEatenGhost(pakman.PositionX - 1, pakman.PositionY);
                            this.field[pakman.PositionX - 1, pakman.PositionY] = pakman;
                            this.field[pakman.PositionX, pakman.PositionY] = empty;
                            this.pakman.PositionX = pakman.PositionX - 1;
                            ReduceEatableMoves();
                            returnPoints = 100;
                        }
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
                if (pakman.PositionY - 1 > 0)
                {
                    if (this.field[pakman.PositionX, pakman.PositionY - 1] == empty)
                    {
                        this.field[pakman.PositionX, pakman.PositionY - 1] = pakman;
                        this.field[pakman.PositionX, pakman.PositionY] = empty;
                        this.pakman.PositionY = pakman.PositionY - 1;
                        ReduceEatableMoves();
                        returnPoints = 0;
                    }
                    else if (this.field[pakman.PositionX, pakman.PositionY - 1] == littleCrumb)
                    {
                        this.crumbNumber--;
                        this.field[pakman.PositionX, pakman.PositionY - 1] = pakman;
                        this.field[pakman.PositionX, pakman.PositionY] = empty;
                        this.pakman.PositionY = pakman.PositionY - 1;
                        ReduceEatableMoves();
                        returnPoints = littleCrumb.Points;
                    }
                    else if (this.field[pakman.PositionX, pakman.PositionY - 1] == bigCrumb)
                    {
                        this.crumbNumber--;
                        this.field[pakman.PositionX, pakman.PositionY - 1] = pakman;
                        this.field[pakman.PositionX, pakman.PositionY] = empty;
                        this.pakman.PositionY = pakman.PositionY - 1;
                        ReduceEatableMoves();
                        MakeThemEatable();
                        returnPoints = bigCrumb.Points;

                    }
                    else if (FindGhost(pakman.PositionX, pakman.PositionY - 1) != null) 
                    {
                        if (!CheckGhostEatable(pakman.PositionX, pakman.PositionY - 1))
                        {
                            this.field[pakman.PositionX, pakman.PositionY] = empty;
                            for (int i = 0; i < this.ghosts.Length; i++)
                            {
                                this.field[ghosts[i].PositionX, ghosts[i].PositionY] = empty;
                            }
                            Reset();
                            returnPoints = -1;
                        }
                        else
                        {
                            ResetEatenGhost(pakman.PositionX, pakman.PositionY - 1);
                            this.field[pakman.PositionX, pakman.PositionY - 1] = pakman;
                            this.field[pakman.PositionX, pakman.PositionY] = empty;
                            this.pakman.PositionY = pakman.PositionY - 1;
                            ReduceEatableMoves();
                            returnPoints = 100;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You hit the wall.");
                    returnPoints = 0;
                }
            }
            else if (a == "s")
            {
                if (pakman.PositionX + 1 < fieldSize - 1)
                {
                    if (this.field[pakman.PositionX + 1, pakman.PositionY] == empty)
                    {
                        this.field[pakman.PositionX + 1, pakman.PositionY] = pakman;
                        this.field[pakman.PositionX, pakman.PositionY] = empty;
                        this.pakman.PositionX = pakman.PositionX + 1;
                        ReduceEatableMoves();
                        returnPoints = 0;
                    }
                    else if (this.field[pakman.PositionX + 1, pakman.PositionY] == littleCrumb)
                    {
                        this.crumbNumber--;
                        this.field[pakman.PositionX + 1, pakman.PositionY] = pakman;
                        this.field[pakman.PositionX, pakman.PositionY] = empty;
                        this.pakman.PositionX = pakman.PositionX + 1;
                        ReduceEatableMoves();
                        returnPoints = littleCrumb.Points;
                    }
                    else if (this.field[pakman.PositionX + 1, pakman.PositionY] == bigCrumb)
                    {
                        this.crumbNumber--;
                        this.field[pakman.PositionX + 1, pakman.PositionY] = pakman;
                        this.field[pakman.PositionX, pakman.PositionY] = empty;
                        this.pakman.PositionX = pakman.PositionX + 1;
                        ReduceEatableMoves();
                        MakeThemEatable();
                        returnPoints = bigCrumb.Points;

                    }
                    else if (FindGhost(pakman.PositionX + 1, pakman.PositionY) != null)
                    {
                        if (!CheckGhostEatable(pakman.PositionX + 1, pakman.PositionY))
                        {
                            this.field[pakman.PositionX, pakman.PositionY] = empty;
                            for (int i = 0; i < this.ghosts.Length; i++)
                            {
                                this.field[ghosts[i].PositionX, ghosts[i].PositionY] = empty;
                            }
                            Reset();
                            returnPoints = -1;
                        }
                        else
                        {
                            ResetEatenGhost(pakman.PositionX + 1, pakman.PositionY);
                            this.field[pakman.PositionX + 1, pakman.PositionY] = pakman;
                            this.field[pakman.PositionX, pakman.PositionY] = empty;
                            this.pakman.PositionX = pakman.PositionX + 1;
                            ReduceEatableMoves();
                            returnPoints = 100;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You hit the wall.");
                    returnPoints = 0;
                }
            }
            else if (a == "d")
            {
                if (pakman.PositionY + 1 < fieldSize - 1)
                {
                    if (this.field[pakman.PositionX, pakman.PositionY + 1] == empty)
                    {
                        this.field[pakman.PositionX, pakman.PositionY + 1] = pakman;
                        this.field[pakman.PositionX, pakman.PositionY] = empty;
                        this.pakman.PositionY = pakman.PositionY + 1;
                        ReduceEatableMoves();
                        returnPoints = 0;
                    }
                    else if (this.field[pakman.PositionX, pakman.PositionY + 1] == littleCrumb)
                    {
                        this.crumbNumber--;
                        this.field[pakman.PositionX, pakman.PositionY + 1] = pakman;
                        this.field[pakman.PositionX, pakman.PositionY] = empty;
                        this.pakman.PositionY = pakman.PositionY + 1;
                        ReduceEatableMoves();
                        returnPoints = littleCrumb.Points;
                    }
                    else if (this.field[pakman.PositionX, pakman.PositionY + 1] == bigCrumb)
                    {
                        this.crumbNumber--;
                        this.field[pakman.PositionX, pakman.PositionY + 1] = pakman;
                        this.field[pakman.PositionX, pakman.PositionY] = empty;
                        this.pakman.PositionY = pakman.PositionY + 1;
                        ReduceEatableMoves();
                        MakeThemEatable();
                        returnPoints = bigCrumb.Points;

                    }
                    else if (FindGhost(pakman.PositionX, pakman.PositionY + 1) != null)
                    {
                        if (!CheckGhostEatable(pakman.PositionX, pakman.PositionY + 1))
                        {
                            this.field[pakman.PositionX, pakman.PositionY] = empty;
                            for (int i = 0; i < this.ghosts.Length; i++)
                            {
                                this.field[ghosts[i].PositionX, ghosts[i].PositionY] = empty;
                            }
                            Reset();
                            returnPoints = -1;
                        }
                        else
                        {
                            ResetEatenGhost(pakman.PositionX, pakman.PositionY + 1);
                            this.field[pakman.PositionX, pakman.PositionY + 1] = pakman;
                            this.field[pakman.PositionX, pakman.PositionY] = empty;
                            this.pakman.PositionY = pakman.PositionY + 1;
                            ReduceEatableMoves();
                            returnPoints = 100;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You hit the wall.");
                    returnPoints = 0;
                }
            }

            else {
                Console.WriteLine("Wrong komand!");
                returnPoints = 0;
            }
            return returnPoints;
        }
        private Boolean CheckGhostEatable(int x, int y)
        {
            Boolean state = false;
            Ghost g = FindGhost(x, y);
            if (g != null) 
            {
                if (FindGhost(x, y).Eatable)
                {
                    state = true;
                }
            }
            return state;
        }
        private Ghost FindGhost(int x,int y)
        {
            Ghost g = null;
            for (int i = 0; i < this.ghosts.Length; i++)
            {
                if (ghosts[i].PositionX == x)
                {
                    if (ghosts[i].PositionY == y)
                    {
                        g = ghosts[i];
                    }
                }
            }
            return g;
        }
        private void ResetEatenGhost(int x, int y)
        {
            for (int i = 0; i < this.ghosts.Length; i++)
            {
                if (ghosts[i].PositionX == x)
                {
                    if (ghosts[i].PositionY == y)
                    {
                        if (this.field[fieldSize / 2 - 1, fieldSize / 2 - 1] == empty)
                        {
                            ghosts[i] = new Ghost(fieldSize / 2 - 1, fieldSize / 2 - 1);
                            this.field[fieldSize / 2 - 1, fieldSize / 2 - 1] = ghosts[i];
                        }
                        else
                        {
                            Ghost g = FindEmptySpot();
                            if (g != null)
                            {
                                ghosts[i] = new Ghost(g.PositionX, g.PositionY);
                                this.field[g.PositionX, g.PositionY] = ghosts[i];
                            }
                        }
                    }
                }
            }
        }
        private Ghost FindEmptySpot()
        {
            Ghost g = null;
            for(int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    if (this.field[i, j] == empty)
                    {
                        g = new Ghost(i, j);
                        return g;
                    }
                }
            }
            return g;
        }
        private void MakeThemEatable()
        {
            for (int i = 0; i < this.ghosts.Length; i++)
            {
                this.ghosts[i].Eatable = true;
                this.ghosts[i].MovesEatable = +10;
            }
        }
        private void ReduceEatableMoves()
        {
            for (int i = 0; i < this.ghosts.Length; i++)
            {
                if (this.ghosts[i].MovesEatable > 0)
                {
                    this.ghosts[i].MovesEatable--;
                    if (this.ghosts[i].MovesEatable == 0)
                    {
                        this.ghosts[i].Eatable = false;
                    }
                }
            }
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

