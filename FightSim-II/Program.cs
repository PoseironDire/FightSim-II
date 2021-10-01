using System;

namespace FightSim_II
{
    class Program
    {
        static int round = 0;
        static bool playing = true;
        static Random generator = new Random();

        static void Main(string[] args)
        {
            Player p1 = new Player();
            Player p2 = new Player();

            //Players choose their names
            Console.Title = "Drip Arena PVP";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("--- Welcome to Drip Arena PVP! ---");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Choose name for Player 1:");
            p1.name = Console.ReadLine();
            if (p1.name == "")
            {
                p1.name = "Player 1";
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Player 1's name is: '" + p1.name + "'");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Choose name for Player 2");
            p2.name = Console.ReadLine();
            if (p2.name == "")
            {
                p2.name = "Player 2";
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Player 2's name is: '" + p2.name + "'");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();

            while (playing)
            {
                NewRound();
                Console.WriteLine("Round " + round + ":");
                int chance = generator.Next(1, 100);

                Console.ReadLine();
                Console.Clear();
            }

            void NewRound()
            {
                round++;
            }
        }
    }
}
