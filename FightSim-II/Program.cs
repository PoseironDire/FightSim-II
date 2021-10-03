using System;

namespace FightSim_II
{
    class Program
    {
        //Players
        static Player p1 = new Player();
        static Player p2 = new Player();

        //Weapons (tried making both Weapons & Players into Arrays, hoped that would work but it didn't..)
        static Weapon weapons1 = new Weapon();
        static Weapon weapons2 = new Weapon();
        static Weapon weapons3 = new Weapon();
        static Weapon weapons4 = new Weapon();

        //Variables
        static int round = 0;
        static int currentPlayer;
        static string weaponChosen;
        static int useWeapon;
        static Random generator = new Random();

        static void Main(string[] args)
        {
            Console.Title = "Drip Arena PVP";

            //Weapon Name
            weapons1.name = "Sword";
            weapons2.name = "Gun";
            weapons3.name = "Launcher";
            weapons4.name = "Frag";

            //Players choose their names
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("--- Welcome to Drip Arena PVP! ---");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Choose name for Player 1:");
            p1.name = Console.ReadLine();
            if (p1.name == "" || p1.name == " ")
            {
                p1.name = "Player 1";
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Player 1's name is: '" + p1.name + "'");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Choose name for Player 2");
            p2.name = Console.ReadLine();
            if (p2.name == "" || p2.name == " ")
            {
                p2.name = "Player 2";
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Player 2's name is: '" + p2.name + "'");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();

            //Loops while both player's HP are above 0
            while (p1.hp > 0 && p2.hp > 0)
            {
                //Start new round
                NewRound();
                //Show Player HP
                Status();

                //Start Player1's turn
                currentPlayer = 1;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(p1.name + "'s turn:");
                Console.ForegroundColor = ConsoleColor.White;

                //Choose weapon method
                WeaponChoose();

                //Check for chosen weapon
                if (useWeapon == 1 && weapons1.chance == 0)
                {
                    p2.hp -= weapons1.damage;
                    Console.WriteLine(p2.name + " took " + weapons1.damage + "!");
                }
                else if (useWeapon == 2 && weapons2.chance == 0)
                {
                    p2.hp -= weapons2.damage;
                    Console.WriteLine(p2.name + " took " + weapons2.damage + "!");
                }
                else if (useWeapon == 3 && weapons3.chance == 0)
                {
                    p2.hp -= weapons3.damage;
                    Console.WriteLine(p2.name + " took " + weapons3.damage + "!");
                }
                else if (useWeapon == 4 && weapons4.chance == 0)
                {
                    p2.hp -= weapons4.damage;
                    Console.WriteLine(p2.name + " took " + weapons4.damage + "!");
                }
                else
                {
                    //If the chances are != 0 the Attack will miss
                    Console.WriteLine(p1.name + " missed!");
                }

                Status();

                //Start Player2's turn
                currentPlayer = 2;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(p2.name + " turn:");
                Console.ForegroundColor = ConsoleColor.White;

                WeaponChoose();

                if (useWeapon == 1 && weapons1.chance == 0)
                {
                    p1.hp -= weapons1.damage;
                    Console.WriteLine(p1.name + " took " + weapons1.damage + "!");
                }
                else if (useWeapon == 2 && weapons2.chance == 0)
                {
                    p1.hp -= weapons2.damage;
                    Console.WriteLine(p1.name + " took " + weapons2.damage + "!");
                }
                else if (useWeapon == 3 && weapons3.chance == 0)
                {
                    p1.hp -= weapons3.damage;
                    Console.WriteLine(p1.name + " took " + weapons3.damage + "!");
                }
                else if (useWeapon == 4 && weapons4.chance == 0)
                {
                    p1.hp -= weapons4.damage;
                    Console.WriteLine(p1.name + " took " + weapons4.damage + "!");
                }
                else
                {
                    Console.WriteLine(p2.name + " missed!");
                }

                Status();
                Console.Clear();
            }
            //Ending results
            Console.ForegroundColor = ConsoleColor.Green;
            if (p1.hp <= 0)
            {
                Console.WriteLine(p2.name + " won!");
            }
            else if (p2.hp <= 0)
            {
                Console.WriteLine(p1.name + " won!");
            }
            else if (p2.hp <= 0 && p1.hp <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Draw!");
            }
            Console.ReadLine();
        }
        //Increase round by 1
        static void NewRound()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            round++;
            Console.WriteLine("Round " + round + ":");
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Shows status
        static void Status()
        {
            Console.WriteLine(p1.name + "'s HP: " + p1.hp);
            Console.WriteLine(p2.name + "'s HP: " + p2.hp);
            Console.ReadLine();
        }

        //Used to select the right weapon 
        static void WeaponChoose()
        {
            //Damage
            weapons1.damage = generator.Next(15, 46);
            weapons2.damage = generator.Next(5, 81);
            weapons3.damage = generator.Next(20, 100);
            weapons4.damage = generator.Next(75, 100);

            //Chance
            weapons1.chance = generator.Next(1);
            weapons2.chance = generator.Next(2);
            weapons3.chance = generator.Next(5);
            weapons4.chance = generator.Next(10);

            //Write weapon options
            Console.WriteLine("Choose a Weapon:");
            Console.WriteLine("1. " + weapons1.name + ": Hit Chance: 100% Damage Range: 15 - 45");
            Console.WriteLine("");
            Console.WriteLine("2. " + weapons2.name + ": Hit Chance: 50% Damage Range: 5 - 80");
            Console.WriteLine("");
            Console.WriteLine("3. " + weapons3.name + ": Hit Chance: 20% Damage Range: 20 - 99");
            Console.WriteLine("");
            Console.WriteLine("4. " + weapons4.name + ": Hit Chance: 10% Damage Range: 75 - 99");

            weaponChosen = Console.ReadLine().ToLower();

            //Check for player answer
            if (weaponChosen == "1" || weaponChosen == "1." || weaponChosen == "sword")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (currentPlayer == 1)
                {
                    Console.WriteLine(p1.name + " chose " + weapons1.name + "!");
                }
                else
                {
                    Console.WriteLine(p2.name + " chose " + weapons1.name + "!");
                }
                Console.ForegroundColor = ConsoleColor.White;
                useWeapon = 1;
            }
            else if (weaponChosen == "2" || weaponChosen == "2." || weaponChosen == "gun")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (currentPlayer == 1)
                {
                    Console.WriteLine(p1.name + " chose " + weapons2.name + "!");
                }
                else
                {
                    Console.WriteLine(p2.name + " chose " + weapons2.name + "!");
                }
                Console.ForegroundColor = ConsoleColor.White;
                useWeapon = 2;
            }
            else if (weaponChosen == "3" || weaponChosen == "3." || weaponChosen == "launcher")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (currentPlayer == 1)
                {
                    Console.WriteLine(p1.name + " chose " + weapons3.name + "!");
                }
                else
                {
                    Console.WriteLine(p2.name + " chose " + weapons3.name + "!");
                }
                Console.ForegroundColor = ConsoleColor.White;
                useWeapon = 3;
            }
            else if (weaponChosen == "4" || weaponChosen == "4." || weaponChosen == "frag")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (currentPlayer == 1)
                {
                    Console.WriteLine(p1.name + " chose " + weapons4.name + "!");
                }
                else
                {
                    Console.WriteLine(p2.name + " chose " + weapons4.name + "!");
                }
                Console.ForegroundColor = ConsoleColor.White;
                useWeapon = 4;
            }
            else
            {
                //If answer is something else, select Sword (value of 1)
                weaponChosen = "1";
                Console.ForegroundColor = ConsoleColor.Red;
                if (currentPlayer == 1)
                {
                    Console.WriteLine("Invalid choice! " + weapons1.name + " was chosen for " + p1.name + "!");
                }
                else
                {
                    Console.WriteLine("Invalid choice! " + weapons1.name + " was chosen for " + p2.name + "!");
                }
                Console.ForegroundColor = ConsoleColor.White;
                useWeapon = 1;
            }
            Console.ReadLine();
        }
    }
}
