using System;
using System.Collections.Generic;
using System.Text;

namespace RandomBattles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] enemies = { "Giant Spider", "Pissed off Pelican", "Meat Pizza", "Bowl of Soup", "Final Exam" };
            string[] weapons = { "Sword", "Spatula", "Frying Pan", "Pencil", "Chainsaw" };
            int[] damage = { 10, 20, 44, 0, 100 };
            List<string> interdimensionalAdvice = new List<string>();

            // Adding some advice to the list.
            interdimensionalAdvice.Add(
                "\n\tIn a alternate dimension, you looked through" +
                "\n\tyour 3rd pocket and performed techinque 4" +
                "\n\tto defeat a rogue Ham Sandwich\n\n");
            interdimensionalAdvice.Add(
                "\n\tOne of your ancestors 10,000 years ago looked" +
                "\n\tthrough their 5th pocket and performed technique 5" +
                "\n\tto distract a Wooly Mammoth\n\n");

            int weaponChoice = 1;      // The players choice of weapon.  Will be added to interdimensionalAdvice.
            int techniqueChoice = 1;   // The players choice of technique.  Will be added to interdimensionalAdvice.

            // This while loop is the main game loop.  Stops when the player wants to quit.
            bool gameLoopOn = true;
            while (gameLoopOn)
            {
                Random rand = new Random();
                int randomEnemy = rand.Next(0, enemies.Length);

                string enemy = enemies[randomEnemy];    // Select a random enemy

                awesomeWrite("A " + enemy + " appears and looks vicious!\n");
                awesomeWrite("You have 5 pockets (1-5) in your backpack and you know 5 fighting styles (1-5)\n");

                // If the player's input is invalid, loop.
                bool invalidAdviceOrWeaponChoice = true;
                while (invalidAdviceOrWeaponChoice)
                {
                    awesomeWrite("Do you (1) get advice from beyond or (2) search for a weapon?  ");
                    int adviceOrWeaponChoice = Convert.ToInt32(Console.ReadLine());

                    // If player wants to get advice, give them the option to do so then choose your weapon.
                    if (adviceOrWeaponChoice == 1)
                    {
                        invalidAdviceOrWeaponChoice = false;    // Valid choice

                        // Keep asking for the correct input until the player gives it to us.
                        bool invalidAdviceNumber = true;
                        while(invalidAdviceNumber)
                        {
                            awesomeWrite("There are " + interdimensionalAdvice.Count + " sources of advice.  Which one do you want?  ");
                            int adviceChoice = Convert.ToInt32(Console.ReadLine());

                            if (adviceChoice >= 1 && adviceChoice <= interdimensionalAdvice.Count)
                            {
                                invalidAdviceNumber = false;
                                awesomeWrite("You hear a faint voice whisper in your ear:\n");
                                awesomeWrite(interdimensionalAdvice[adviceChoice - 1], 60);
                                adviceOrWeaponChoice = 2;
                            }
                            else
                            {
                                awesomeWrite("You must choose a number between 1 and " + (interdimensionalAdvice.Count) + "\n");
                            }
                        }

                    }

                    // If the player wants to fight, give them the option to select weapon, then select fighting style.
                    if (adviceOrWeaponChoice == 2)
                    {
                        invalidAdviceOrWeaponChoice = false;    // Valid choice

                        // Keep asking for the correct input until the player gives it to us.
                        bool invalidWeaponNumber = true;
                        while (invalidWeaponNumber)
                        {
                            awesomeWrite("Out of the " + weapons.Length + " slots in your pack, which one do you search for a weapon?  ");
                            weaponChoice = Convert.ToInt32(Console.ReadLine());
                            if (weaponChoice >= 1 && weaponChoice <= weapons.Length)
                            {
                                invalidWeaponNumber = false;
                                awesomeWrite("You use a");
                                awesomeWrite(" " + weapons[weaponChoice - 1] + " ", 100);
                                awesomeWrite("to fight off the " + enemy + "\n");
                            }
                            else
                            {
                                awesomeWrite("You must choose a number between 1 and " + (weapons.Length) + "\n");
                            }
                        }

                        // Keep asking for the correct input until the player gives it to us.
                        bool invalidTechniqueNumber = true;
                        while (invalidTechniqueNumber)
                        {
                            awesomeWrite("Out of the " + damage.Length + " techniques that you know, which one do use?  ");
                            techniqueChoice = Convert.ToInt32(Console.ReadLine());
                            if (techniqueChoice >= 1 && techniqueChoice <= damage.Length)
                            {
                                invalidTechniqueNumber = false;
                                awesomeWrite("You deal");
                                awesomeWrite(" " + damage[techniqueChoice - 1] + " ", 100);
                                awesomeWrite("with that technique!\n");
                            }
                            else
                            {
                                awesomeWrite("You must choose a number between 1 and " + (damage.Length) + "\n");
                            }
                        }
                    }
                    if (adviceOrWeaponChoice != 1 && adviceOrWeaponChoice != 2)
                    {
                        awesomeWrite("You must choose 1 or 2!\n");
                    }
                }

                int deathNumber = rand.Next(1, 100);    // The number to decide if you died from the encounter

                // About a 33% chance that the player dies by the enemy.
                if (deathNumber > 66)
                {
                    awesomeWrite("\nUnfortunately, you did not survive the encounter . . . . . \n", 90);
                    awesomeWrite("But your story will live on to help future generations\n\n", 50);
                }
                else
                {
                    awesomeWrite("\nYou defeated the " + enemy + ".  Congratulations!\n", 90);
                    awesomeWrite("You tell the story far and wide to help future generations\n\n", 50);
                }

                awesomeWrite("Do you want to play again? (y or n)  ");
                string playAgain = Console.ReadLine();
                Console.WriteLine();
                if (playAgain == "y")
                {
                    gameLoopOn = true;      // Continue Playing.  This line is technically not needed.

                    // This is to put the correct ending on weaponChoice: 1st, 2nd, 3rd, 4th, 5th
                    interdimensionalAdvice.Add(
                        "\n\tLong ago, A mighty warrior peered into" +
                        "\n\ttheir " + weaponChoice);
                    int position = interdimensionalAdvice.Count - 1;
                    if (weaponChoice == 4 || weaponChoice == 5)
                    {
                        interdimensionalAdvice[position] += "th ";
                    }
                    else if (weaponChoice == 3)
                    {
                        interdimensionalAdvice[position] += "rd";
                    }
                    else if (weaponChoice == 2)
                    {
                        interdimensionalAdvice[position] += "nd";
                    }
                    else if (weaponChoice == 1)
                    {
                        interdimensionalAdvice[position] += "st";
                    }
                    interdimensionalAdvice[position] += 
                        "pocket and performed techinque " + techniqueChoice +
                        "\n\tto take down a deadly " + enemy;
                }
                else
                {
                    gameLoopOn = false;     // End the game
                }
            }

            Console.WriteLine("\nThanks for playing!");
            Console.Read();
        }


        // A method that types your string letter by letter.
        static void awesomeWrite(string text)
        {
            char[] letters = text.ToCharArray();
            foreach (char letter in letters)
            {
                System.Threading.Thread.Sleep(15);
                Console.Write(letter);
            }
        }

        // Overloaded method.  Allows you to change the speed that characters appear.  Bigger number = slower. 5 < speed < 100
        static void awesomeWrite(string text, int speed)
        {
            if (speed < 5 || speed > 100)
            {
                speed = 15;
            }
            char[] letters = text.ToCharArray();
            foreach (char letter in letters)
            {
                System.Threading.Thread.Sleep(speed);
                Console.Write(letter);
            }
        }
    }
}
