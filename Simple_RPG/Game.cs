using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_RPG
{
    class Game
    {
        public void Start()
        {
            string playerName = "";
            int playerHealth = 100;

            //asks player for name. and assigns name to player;
            Console.WriteLine("What is your name? ");
            playerName = Console.ReadLine();
            Console.WriteLine("Welcome! " + playerName + ".");

            //Monster Encounter
            int monsterDamage = 13;
            Console.WriteLine("");
            Console.WriteLine("A wild thing appears!");

            string action = "";
            Console.WriteLine("What is the plan bose? (fight/flight)");
            action = Console.ReadLine();

            if (action == "fight" || action == "Fight")
            {
                //monster attacks player;
                Console.WriteLine("The  monster attacks! " + playerName + " takes "
                    + monsterDamage + "damage.");

                playerHealth = playerHealth - monsterDamage;

                Console.WriteLine(playerName + " has " + playerHealth +
                    " health remaining.");
                //player attacks monster;
                Console.WriteLine(playerName + " attacks! The monster is defeated.");
            }
            else if (action == "flight" || action == "Flight")
            {
                //escape
                Console.WriteLine("You flapped your arms fast enough...");
            }

            Console.ReadKey();
       }
    }
}
