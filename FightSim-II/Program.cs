using System;

namespace FightSim_II
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player();
            Player p2 = new Player();

            //Players choose their names
            Console.WriteLine("Welcome to Drip Arena PVP");
            Console.WriteLine("Choose name for Player 1:");
            p1.name = Console.ReadLine();
            Console.WriteLine("Player 1 is called: " + p1.name + "!");
            Console.WriteLine("Choose name for Player 2");
            p1.name = Console.ReadLine();
            Console.WriteLine("Player 2 is called: " + p2.name + "!");

            Console.ReadLine();
        }
    }
}
