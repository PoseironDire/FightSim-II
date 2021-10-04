using System;

namespace FightSim_II
{
    class Program
    {
        //Players Array
        static Player[] players = { new Player(), new Player() };

        //Weapons Array
        static Weapon[] weapons = { new Weapon(), new Weapon(), new Weapon(), new Weapon() };

        //Variables
        static int round = 0;
        static int attacker;
        static int notAttacker;
        static string weaponChosen;
        static int useWeapon;
        static Random generator = new Random();

        static void Main(string[] args)
        {
            Console.Title = "Drip Arena PVP";

            attacker = generator.Next(2);
            notAttacker = attacker + 1;

            //Weapon Name
            weapons[0].name = "Sword";
            weapons[1].name = "Gun";
            weapons[2].name = "Launcher";
            weapons[3].name = "Frag";

            //Players choose their names
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("--- Welcome to Drip Arena PVP! ---");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Choose name for Player 1:");
            players[0].name = Console.ReadLine();
            if (players[0].name == "" || players[0].name == " ")
            {
                players[0].name = "Player 1";
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Player 1's name is: '" + players[0].name + "'");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Choose name for Player 2");
            players[1].name = Console.ReadLine();
            if (players[1].name == "" || players[1].name == " ")
            {
                players[1].name = "Player 2";
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Player 2's name is: '" + players[1].name + "'");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();

            //Loops while both player's HP are above 0
            while (players[0].hp > 0 && players[1].hp > 0)
            {
                //Start new round
                NewRound();

                Status();

                for (int i = 0; i < players.Length; i++)
                {
                    Turn();

                    WeaponChoose();

                    Attack();

                    Status();
                }
                Console.Clear();
            }
            //Ending results
            Console.ForegroundColor = ConsoleColor.Green;
            if (players[0].hp <= 0)
            {
                Console.WriteLine(players[1].name + " won!");
            }
            else if (players[1].hp <= 0)
            {
                Console.WriteLine(players[0].name + " won!");
            }
            else if (players[1].hp <= 0 && players[0].hp <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Draw!");
            }
            Console.ReadLine();
        }

        //Increase round by 1
        static void NewRound()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            round++;
            Console.WriteLine("Round " + round + ":");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        //Shows status
        static void Status()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(players[0].name + "'s HP: " + players[0].hp);
            Console.WriteLine(players[1].name + "'s HP: " + players[1].hp);
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        //Turn
        static void Turn()
        {
            //Start Player1's turn
            attacker++;
            notAttacker++;
            if (attacker > 1)
            {
                attacker = 0;
            }
            if (notAttacker > 1)
            {
                notAttacker = 0;
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(players[attacker].name + "'s turn:");
            Console.ForegroundColor = ConsoleColor.White;

        }

        //Used to select the right weapon 
        static void WeaponChoose()
        {
            //Damage
            weapons[0].damage = generator.Next(15, 46);
            weapons[1].damage = generator.Next(5, 81);
            weapons[2].damage = generator.Next(20, 100);
            weapons[3].damage = generator.Next(75, 100);

            //Chance
            weapons[0].chance = generator.Next(1);
            weapons[1].chance = generator.Next(2);
            weapons[2].chance = generator.Next(5);
            weapons[3].chance = generator.Next(10);

            //Write weapon options
            Console.WriteLine("Choose a Weapon:");
            Console.WriteLine("1. " + weapons[0].name + ": Hit Chance: 100% Damage Range: 15 - 45");
            Console.WriteLine("2. " + weapons[1].name + ": Hit Chance: 50% Damage Range: 5 - 80");
            Console.WriteLine("3. " + weapons[2].name + ": Hit Chance: 20% Damage Range: 20 - 99");
            Console.WriteLine("4. " + weapons[3].name + ": Hit Chance: 10% Damage Range: 75 - 99");

            weaponChosen = Console.ReadLine().ToLower();

            //Check for a player's answer
            if (weaponChosen == "1" || weaponChosen == "1." || weaponChosen == "sword")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(players[attacker].name + " chose " + weapons[0].name + "!");
                Console.ForegroundColor = ConsoleColor.White;
                useWeapon = 0;
            }
            else if (weaponChosen == "2" || weaponChosen == "2." || weaponChosen == "gun")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(players[attacker].name + " chose " + weapons[1].name + "!");
                Console.ForegroundColor = ConsoleColor.White;
                useWeapon = 1;
            }
            else if (weaponChosen == "3" || weaponChosen == "3." || weaponChosen == "launcher")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(players[attacker].name + " chose " + weapons[2].name + "!");
                Console.ForegroundColor = ConsoleColor.White;
                useWeapon = 2;
            }
            else if (weaponChosen == "4" || weaponChosen == "4." || weaponChosen == "frag")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(players[attacker].name + " chose " + weapons[3].name + "!");
                Console.ForegroundColor = ConsoleColor.White;
                useWeapon = 3;
            }
            else
            {
                //If answer is something else, select Sword (value of 1)
                useWeapon = generator.Next(4);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Invalid choice! " + weapons[useWeapon].name + " was chosen for " + players[attacker].name + "!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.ReadLine();
        }

        //Attack Method
        static void Attack()
        {
            //Check for chosen weapon
            Console.ForegroundColor = ConsoleColor.Red;
            if (weapons[useWeapon].chance == 0)
            {
                players[notAttacker].hp -= weapons[useWeapon].damage;
                Console.WriteLine(players[notAttacker].name + " took " + weapons[useWeapon].damage + "!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                //If the chances are != 0 the Attack will miss
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(players[attacker].name + " missed!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
