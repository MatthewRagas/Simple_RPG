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
        int healAbilityMax = 3;
        int deadMonsters = 0;
        int playerAttack = 25;
        int fleeCount = 2;
        int fleeCountMax = 2;
        int fleeCooldown = 0;


        public void Start()
        {
            Welcome();

            bool alive = true;

           //fight until you lose;
            while (alive)
            {
               alive = Encounter(49, 150);
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
        bool Encounter( int monsterDamage, int monsterHealth)
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
                else if(playerCurrentHealth <= playerMaxHealth * 0.33)
                {
                    Console.WriteLine("What is the plan bose? (fight/flight/heal "
                        + healAbilityCharge +" charges)");
                }

                action = Console.ReadLine();

                if (action == "fight" || action == "Fight")
                {
                    return Fight(ref monsterDamage, ref monsterHealth);
                }
                else if (action == "flight" || action == "Flight")
                {

                    return Flee(ref monsterDamage, ref monsterHealth);
                }
                else if(action == "heal" || action == "Heal")
                {
                    Heal(ref monsterHealth, ref monsterDamage);
                }
                
               
            }

            return true;

        }

        bool Fight(ref int monsterDamage, ref int monsterHealth)
        {

            //monster attacks player;
            Console.WriteLine("The  monster attacks! " + playerName + " takes "
                + monsterDamage + "damage.");

            playerCurrentHealth -= monsterDamage;

            Console.WriteLine(playerName + " has " + playerCurrentHealth +
                " health remaining.");

            //player defeat/game over.
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
            playerCurrentHealth += 6;
            Console.WriteLine("The monster has " + monsterHealth + " Remaining");
            return true;
        }

        bool Flee(ref int monsterDamage, ref int monsterHealth)
        {
            //escape;

            fleeCount--;

            if(fleeCount > 0)
            {
                Console.WriteLine("You flapped your arms fast enough..." +
                "\n You bought enough time to regen 20 health.\n You have " + fleeCount +
                " flights remainging.");
                playerCurrentHealth += 20;
                if (playerCurrentHealth > playerMaxHealth)
                {
                    playerCurrentHealth = playerMaxHealth;
                }

                monsterHealth = 150;
                fleeCooldown++;

                if (fleeCooldown == 2)
                {
                    fleeCount++;
                }

                if (fleeCount > fleeCountMax)
                {
                    fleeCount = fleeCountMax;
                }

                else
                {
                    playerCurrentHealth -= monsterDamage;
                    Console.WriteLine("Your flight failed. The sir lands an attack.\n " +
                        "you have " + playerCurrentHealth + " health remaining.");
                }
            }
            

            return true;
        }

        bool Heal(ref int monsterDamage, ref int monsterHealth)
        {
            //player heal ability;
            if (healAbilityCharge > 0)
            {
                playerCurrentHealth += healAbility;
                healAbilityCharge--;
            }

            //checks if current health goes over max health;
            if (playerCurrentHealth > playerMaxHealth)
            {
                playerCurrentHealth = playerMaxHealth;
            }

            Console.WriteLine("You heal yourself to " + playerCurrentHealth + " health.\n"
                + healAbilityCharge + " heal charges remaining");
            Console.ReadKey();

            //Code to keep track of heal charges;
            if (monsterHealth <= 0)
            {
                deadMonsters++;
            }

            if (deadMonsters == 3)
            {
                healAbilityCharge++;
                deadMonsters = 0;
                if (healAbilityCharge >= healAbilityMax)
                    healAbilityCharge = healAbilityMax;
            }
            return true;
        }
    }
}
