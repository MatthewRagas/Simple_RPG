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
        int playerMaxHealth = 100;
        int playerCurrentHealth = 100;
        int healAbility = 50;
        int healAbilityCharge = 3;
        int deadMonsters = 0;
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
            Console.WriteLine("A wild Sir appears!");

            //loop of the fight option;
            while (playerCurrentHealth > 0 && monsterHealth > 0)
            {
                string action = "";
                
                if (playerCurrentHealth > playerMaxHealth * 0.33)
                {
                    Console.WriteLine("What is the plan bose? (fight/flight)");
                }
                else if(playerCurrentHealth < playerMaxHealth * 0.33)
                {
                    Console.WriteLine("What is the plan bose? (fight/flight/heal)");
                }

                action = Console.ReadLine();

                if (action == "fight" || action == "Fight")
                {



                    //monster attacks player;
                    Console.WriteLine("The  monster attacks! " + playerName + " takes "
                        + monsterDamage + "damage.");

                    playerCurrentHealth -= monsterDamage;

                    Console.WriteLine(playerName + " has " + playerCurrentHealth +
                        " health remaining.");
                    if (playerCurrentHealth <= 0)
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
                else if (action == "flight" || action == "Flight")
                {
                    //escape;
                    Console.WriteLine("You flapped your arms fast enough...");
                }
                else if(action == "heal" || action == "Heal")
                {
                    //player heal ability;
                    playerCurrentHealth += healAbility;

                    //checks if health goes over max health;
                    if (playerCurrentHealth > playerMaxHealth)
                    {
                        playerCurrentHealth = playerMaxHealth;
                    }

                    Console.WriteLine("You heal yourself to " + playerCurrentHealth + " health.");
                    Console.ReadKey();
                }
            }

            return true;

        }
    }
}
