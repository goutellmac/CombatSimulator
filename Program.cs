using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CombatSimulator
{
    class Program
    {
        //global random number generator
        static Random rng = new Random();
        //global variable for playerHP
        static int playerHP = 100;
        //global variable for dragonHP
        static int dragonHP = 200;
        //global variable for number of rounds played
        static int round;
        //global variable for playerChoice to be used for choosing attacks
        static string playerChoice;
        //dragon hit chance variable
        static int dragonChanceToHit = 0;
        //dragon damage variable
        static int dragonDamage = 0;
        //swordhitchance variable
        static int SwordChanceToHit = 0;
        //sworddamage variable
        static int swordDamage = 0;
        //fireball damage variable
        static int fireballDamage = 0;
        //heal amount variable
        static int healAmount = 0;
        //bool to control playing loop
        static bool playing = true;
 
        static void Main(string[] args)
        {
            //explain game to player
           
            Console.WriteLine("You are about to do battle with a powerful dragon.  Best of luck warrior.");
            
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("For each round of combat you will have the option to attack");
            Console.WriteLine("with your sword by pressing 1");
            Console.WriteLine("The sword attack deals between 20 and 35 damage but has a 30% chance to miss.");
     
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You will also have to option to use a fireball spell.");
            Console.WriteLine("The fireball spell deals between 10 and 15 damage, but hits 100% of the time.");
            
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Finally, you will have the option to heal.");
            Console.WriteLine("This will heal you for 10 to 20 HP.");
           
            Console.ReadKey();
            Console.Clear();
            while (playing == true)
            {


                while (playerHP > 0 && dragonHP > 0)
                {
                    Console.WriteLine("Press 1 for a sword attack...");
                    Console.WriteLine("Press 2 for a fireball attack...");
                    Console.WriteLine("Press 3 for a self heal...");
                    playerChoice = Console.ReadLine();
                    while (playerChoice == string.Empty)
                    {
                        Console.WriteLine("Please enter 1, 2 or 3.");
                        playerChoice = Console.ReadLine();
                    }
                    //validation check to see if input is between 1-3 - otherwise reprompt for valid input
                    int thePlayerChoice = int.Parse(playerChoice);

                    //execute the sword attack
                    if (thePlayerChoice == 1)
                    {
                        SwordAttack();
                    }
                    //execute the fireball attack
                    else if (thePlayerChoice == 2)
                    {
                        FireballAttack();
                    }
                    //execute the player heal
                    else if (thePlayerChoice == 3)
                    {
                        Heal();
                    }
                    else
                    {
                        SwordAttack();
                    }
                    //dragon attacks
                    DragonAttack();
                    //increment number of rounds
                    round++;
                    Display();
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();


                }



                //victory / defeat messages
                if (playerHP > 0 && dragonHP <= 0)
                {
                    Console.WriteLine("You've done it!  You've slain the dragon!");
                    Console.ReadKey();
                }
                if (dragonHP > 0 && playerHP <= 0)
                {
                    Console.WriteLine("The dragon has defeated you.  You suck.");
                    Console.ReadKey();
                }
               

                Console.WriteLine("Please press 1 if you would like to play again.");
                string again = Console.ReadLine();
                if (again == "1")
                {
                    dragonHP = 200;
                    playerHP = 100;
                    round = 0;
                    
                }
                else
                {
                    playing = false;
                }
            }
        }

        public static void Display()
        {
            Console.WriteLine("Your HP: {0}", playerHP);
            Console.WriteLine("Dragon HP: {0}", dragonHP);
            Console.WriteLine("Turns: {0}", round);
        }
        /// <summary>
        /// function for player sword attack option
        /// </summary>
        public static void SwordAttack()
        {
            
            SwordChanceToHit = rng.Next(1, 11);
            if (SwordChanceToHit <= 7)
            {
                swordDamage = rng.Next(20, 36);
                dragonHP -= swordDamage;
                Console.WriteLine("Cool! You hit the dragon for {0}", swordDamage);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("You swing and miss!  The powerful wyrm chuckles at your pitiful attempt to fight.");
                Console.ReadKey();
            }

        }
        /// <summary>
        /// function for player fireball attack option
        /// </summary>
        public static void FireballAttack()
        {
            fireballDamage = rng.Next(10, 16);
            dragonHP -= fireballDamage;
            Console.WriteLine("Cool! You hit for the dragon for {0}", fireballDamage);
            Console.ReadKey();
        }
        /// <summary>
        /// function for player heal option
        /// </summary>
        public static void Heal()
        {
            healAmount = rng.Next(10, 21);
            playerHP += healAmount;
            Console.WriteLine("Cool!  You healed yourself for {0}", healAmount);
            Console.ReadKey();
        }

        public static void DragonAttack()
        {
            dragonChanceToHit = rng.Next(1, 11);
            if (dragonChanceToHit <= 8)
            {
                dragonDamage = rng.Next(5, 15);
                playerHP -= dragonDamage;
                Console.WriteLine("Yikes!  The dragon hit you for {0}", dragonDamage);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("The dragon missed you!  You've got this!");
                Console.ReadKey();
            }
        }
        /// <summary>
        /// function to test for a valid input
        /// </summary>
        /// <param name="userEntry"></param>
        /// <returns></returns>
        public static bool ValidInput(string userEntry)
        {
            return true;
        }
    }
}
