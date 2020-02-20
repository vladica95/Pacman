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
            Player player = new Player();
            Game game = new Game();
            
            while (player.Lifes > 0 && game.Crumbs())
            {
                Console.WriteLine("Enter your move.");
                string move = Console.ReadLine();
                int points = game.PacmanMove(move);
                if (points > -1)
                {
                    player.AddPoints(points);
                }
                else
                {
                    player.LoseLife();
                }
                player.PrintScore();
            }
            if (player.Lifes < 1)
            {
                Console.WriteLine("Game over!");
                Console.WriteLine("You lost!");
            }else if (!game.Crumbs())
            {
                Console.WriteLine("Game over!");
                Console.WriteLine("You won!");
            }
        }
    }
}
