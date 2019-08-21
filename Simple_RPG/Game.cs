using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_RPG
{
    class Game
    {
        string playerName = "";
        int playerHealth = 100;
        int playerAttack = 25;


        public void Start()
        {
            Welcome();

            bool alive = true;

           //fight until you lose;
            while (alive)
            {
               alive = Encounter(13, 150);
            }

            Console.ReadKey();
        }

        void Welcome()
        {
            //asks player for name. and assigns name to player;
            Console.WriteLine("What is your name? ");
            playerName = Console.ReadLine();
            Console.WriteLine("Welcome! " + playerName + ".");
        }
        //Monster Encounter
        bool Encounter(int monsterDamage, int monsterHealth)
        {
           
            Console.WriteLine("");
            Console.WriteLine("A wild thing appears!");

            string action = "";
            Console.WriteLine("What is the plan bose? (fight/flight)");
            action = Console.ReadLine();

            if (action == "fight" || action == "Fight")
            {
                //loop of the fight option;
                while(playerHealth > 0 && monsterHealth > 0)
                {
                    //monster attacks player;
                    Console.WriteLine("The  monster attacks! " + playerName + " takes "
                        + monsterDamage + "damage.");

                    playerHealth -= monsterDamage;

                    Console.WriteLine(playerName + " has " + playerHealth +
                        " health remaining.");
                    if (playerHealth <= 0)
                    {
                        Console.WriteLine("You have been defeated. \n Game Over.");
                        Console.ReadKey();
                        return false;
                    }
                    Console.ReadKey();

                    //player attacks monster;
                    Console.WriteLine(playerName + " attacks The monster.");

                    monsterHealth -= playerAttack;
                    Console.WriteLine("The monster has " + monsterHealth + " Remaining");                    

                }

                
            }
            else if (action == "flight" || action == "Flight")
            {
                //escape
                Console.WriteLine("You flapped your arms fast enough...");
            }

            return true;

        }
    }
}
