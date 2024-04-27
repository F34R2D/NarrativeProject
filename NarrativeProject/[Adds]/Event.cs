using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NarrativeProject.Rooms;

namespace NarrativeProject
{
    public class Event
    {
        public static bool isWeaponDoorDeactivated = false;
        public static bool isSecondEventTriggered = false;
        public static bool isFirstEventTriggered = false;
        
        static Random rand = new Random();

        //Explosion DOOR
        public static void FirstEvent()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("As you walked of that door, an explosion is triggered..!\n");
            Console.WriteLine("As you try to get back on your feet, you realized you took 15 damage !\n\n");
            Console.ResetColor();
            Console.WriteLine("Press any KEY to continue.");
            Console.ReadKey();
            Program.currentPlayer.health -= 15;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("It came to your mind that your [bathroom] inside your bunker exist.\n");
            Console.WriteLine("You realize that patching yourself up would be a good idea.\n\n");
            Console.ResetColor();
            Console.WriteLine("Press any KEY to continue.");
            isFirstEventTriggered = true;
            Console.ReadKey();
            Game.Transition<Bunker>();
            
        }
        //Enemy BATHROOM
        public static void SecondEvent()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("You turn around as fast as you can and throw yourself away from the unknown creature.");
            Console.WriteLine("It seems agressive, and ready to fight. You don't have your weapons with you...\n");
            Console.ResetColor();
            Console.WriteLine("Press any KEY to continue.");
            Console.ReadKey();
            bathroomCombat("Baby Alien", 10, 15);
        }
        public static void FinalBattle()
        {
            Console.Clear();
            Console.WriteLine("It seems agressive, and ready to fight.");
            Console.WriteLine("Press any KEY to continue.");
            Console.ReadKey();
            advancedCombat("Faustino, THE GREAT", 20, 50);

        }
        public static void ThirdEvent()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("As you walked of that door, an explosion is triggered..!\n");
            Console.WriteLine("As you try to get back on your feet, you realized you took 15 damage !\n\n");
            Console.ResetColor();
            Console.WriteLine("Maybe the tools would have helped out...");
            Console.WriteLine("Press any KEY to continue.");
            Console.ReadKey();
            Game.Transition<Weaponery>();
        }
        public static void WeaponDoor()
        {
            Program.currentPlayer.health -= 15;
            Event.isWeaponDoorDeactivated = true;
            Game.Transition<Weaponery>();
        }

        public static void NoWeaponAlt()
        {
            Console.WriteLine("Since you have no weapons to defend yourself with... you have very few options.\n");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("[Choose an action !]\n\n");
            Console.ResetColor();
            Console.WriteLine("Take a chance to [flee]");


            string input = Console.ReadLine();

            if (input.ToLower() == "flee")
            {
                if (Event.rand.Next(0, 2) == 0)
                {
                    Console.WriteLine("In an attempt to get away, it blocks your way making your escape impossible !");
                    Console.WriteLine("He Takes his Laser gun and kills you instantly.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("You successfully flee the confrontation from and return safely to your Bunker");
                    Game.Transition<Bunker>();
                }
            }
            else
            {
                Console.WriteLine("Invalid command.");
            }
        }

        public static void bathroomCombat(string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;
            n = name;
            p = power;
            h = health;

            while (h > 0)
            {
                Console.Clear();
                Console.WriteLine("Name: " + Program.currentPlayer.name);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(Program.currentPlayer.health + " HP");
                Console.ResetColor();
                Console.WriteLine("Medkit(s): " + Program.currentPlayer.medkit);
                Console.WriteLine("");
                Console.WriteLine("");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(n);
                Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine(p + " power " + "/ " + h + " health");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Choose an [action]\n\n");
                Console.ResetColor();

                Console.WriteLine("Use [Toothbrush] !");
                Console.WriteLine("------------------");
                Console.WriteLine("Use [Soap] !");
                Console.WriteLine("------------------");
                Console.WriteLine("Use [Charm] !");
                Console.WriteLine("------------------");
                Console.WriteLine("Use [Toaster] !");
                Console.WriteLine("------------------");
                Console.WriteLine("Use [Medkit] !");
                Console.WriteLine("------------------");

                string input1 = Console.ReadLine();

                if(input1.ToLower() == "toothbrush")
                {
                    Console.WriteLine("\nYou begin to feel the toothbrush in your left hand. ");
                    Console.WriteLine("Once you feel a bit more confident, you take a wild swing at " +n);
                    int damage = p - Program.currentPlayer.armor + rand.Next(5,10);
                    int attack = rand.Next(0, Program.currentPlayer.weaponD) + rand.Next(1,4);
                    if (damage < 0)
                        damage = 0;
                    Console.WriteLine("You deal " + attack + " damage and take " + damage + " damage.");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                    Console.ReadKey();

                }
                else if(input1.ToLower() == "soap")
                {
                    Console.WriteLine("In a desperate attempt, you grab on the Soap bar next to you but it slips up");
                    Console.WriteLine("from your hand before you can manage to throw it at " +n);
                    int damage = p - Program.currentPlayer.armor + rand.Next(5, 10);
                    Console.WriteLine("This poor manoeuver cost you " + damage + "health.");
                    Program.currentPlayer.health -= damage;
                    Console.ReadKey();
                }
                else if (input1.ToLower() == "charm")
                {
                    Console.WriteLine("\nYou start feeling desperate. You give the " +n+ " a sexy look followed by a wink.");
                    Console.WriteLine("The " + n + " is not convinced and murders you on the spot.\n\n");
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("YOU DIED");
                    Console.ResetColor();
                    Console.ReadKey();
                    Thread.Sleep(2000);
                    Environment.Exit(0);

                }
                else if (input1.ToLower() == "toaster")
                {
                    Console.WriteLine("\nStrangely enough, you enjoy eating your toasts in your bathroom in the morning.");
                    Console.WriteLine("You unplug the toaster and start swinging it by the cord to the " +n);
                    int damage = p - Program.currentPlayer.armor + rand.Next(5, 10);
                    int attack = rand.Next(0, Program.currentPlayer.weaponD) + rand.Next(5, 8);
                    if (damage < 0)
                        damage = 0;
                    Console.WriteLine("You deal " + attack + " damage and take " + damage + " damage.");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                    Console.ReadKey();
                }
                else if (input1.ToLower() == "medkit")
                {
                    if (Program.currentPlayer.medkit == 0)
                    {
                        Console.WriteLine("\nAs you rumble through your entire inventory, you realize you are out of Medkits !");
                        int damage = p - Program.currentPlayer.armor + rand.Next(5, 10);
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("The " + n + " takes this opportunity to attack you which makes you lose " + damage + " health !");
                        Program.currentPlayer.health -= damage;
                    }
                    else
                    {
                        int medkitValue = 15;
                        Console.WriteLine("\nYou find a Medkit in your inventory and succesfully healed yourself !");
                        Console.WriteLine("You recover" + medkitValue + "health");
                        Program.currentPlayer.health += medkitValue;
                        Program.currentPlayer.medkit -= 1;
                    }

                    Console.ReadKey();
                }


                if (Program.currentPlayer.health <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("You succomb to death itself\n\n");
                    Thread.Sleep(2000);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("YOU DIED");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    Environment.Exit(0);



                }
                if( h <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nAmazing, you defeated your first enemy called the " + n +" !" );
                    Console.ResetColor();
                    Console.ReadKey();
                    Game.Transition<Bathroom>();
                }
                
                    
            }
            Console.ReadKey();
        }
        //Advanced combat when Player gets his wepaons
        public static void advancedCombat( string name, int power, int health)
        {
            string n = "";
            string t = "";
            int p = 0;
            int h = 0;
            
           
            
                n = name;
                
                h = health;
                p = power;
            

            while (h > 0)
            {
                Console.Clear();
                Console.WriteLine("Name: " + Program.currentPlayer.name);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(Program.currentPlayer.health + " HP");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(n);
                Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine(p + " power " + "/ " + h + " health");
                Console.WriteLine("");

                Console.WriteLine("Chose an [action]\n\n");
                Console.WriteLine("Use [Sword]");
                Console.WriteLine("-----------");
                Console.WriteLine("Use [Grenade]");
                Console.WriteLine("-----------");
                Console.WriteLine("Use [FlameThrower]");
                Console.WriteLine("-----------");
                Console.WriteLine("[Use Flee] !");
                Console.WriteLine("-----------");
                Console.WriteLine("Use the [MEDKIT] " + "[" + Program.currentPlayer.medkit + "]");
                
                string input = Console.ReadLine();

                if (input.ToLower() == "sword")
                {
                    //sword attack
                    Console.WriteLine("You take your laserbeam sword in your hands and slash" + n + ".");
                    int damage = p - Program.currentPlayer.armor + rand.Next(12, 16);
                    int attack = rand.Next(0, Program.currentPlayer.weaponD) + rand.Next(15, 20);
                    if (damage < 0)
                        damage = 0;
                    Console.WriteLine("You deal " + attack + " damage and take " + damage + " damage.");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                    Console.ReadKey();

                    
                }
                else if (input.ToLower() == "grenade")
                {
                    //grenade attackk
                    Console.WriteLine("You throw a few Grenades at " + n + ".");
                    int damage = p - Program.currentPlayer.armor + rand.Next(12, 16);
                    int attack = rand.Next(0, Program.currentPlayer.weaponD) + rand.Next(15, 20);
                    if (damage < 0)
                        damage = 0;
                    Console.WriteLine("You deal " + attack + " damage and take " + damage + " damage.");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                    Console.ReadKey();
                }
                else if (input.ToLower() == "flamethrower")
                {
                    //flamethrower attack
                    Console.WriteLine("You start engaging your big Flamethrower to " + n + ".");
                    int damage = p - Program.currentPlayer.armor + rand.Next(12, 16);
                    int attack = rand.Next(0, Program.currentPlayer.weaponD) + rand.Next(15, 20);
                    if (damage < 0)
                        damage = 0;
                    Console.WriteLine("You deal " + attack + " damage and take " + damage + " damage.");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                    Console.ReadKey();
                }
                else if (input.ToLower() == "flee")
                {
                    if (Event.rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("In an attempt to get away from" + n + ", they block your way making your escape impossible !");
                        int damage = p - Program.currentPlayer.health;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("Your poor attempt to escape makes you lose" + damage + "health.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You successfully flee the confrontation from" +n+ "and return safely to your Bunker");
                        Game.Transition<Bunker>();
                    }
                }
                else if (input.ToLower() == "medkit")
                {
                    if(Program.currentPlayer.medkit == 0)
                    {
                        Console.WriteLine("As you rumble through your entire inventory, you realize you are out of Medkits !");
                        int damage = p - Program.currentPlayer.health;
                        if(damage < 0)
                            damage = 0;
                        Console.WriteLine("The " +n+ " takes this opportunity to attack you which makes you lose " +damage+" health");
                    }
                    else
                    {
                        int medkitValue = 15;
                        Console.WriteLine("You find a Medkit in your inventory and succesfully healed yourself !");
                        Console.WriteLine("You recover" +medkitValue+ "health");
                        Program.currentPlayer.health += medkitValue;
                        Program.currentPlayer.medkit -= 1;
                    }
                    
                    Console.ReadKey();
                }

                if (Program.currentPlayer.health <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("You succomb to death itself\n\n");
                    Thread.Sleep(2000);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("YOU DIED");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    Environment.Exit(0);



                }
                if (h <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nAmazing, you defeated your enemy called the " + n + " !");
                    Console.ResetColor();
                    Console.ReadKey();
                    Game.Transition<Communication>();
                }

            }
            


        }
        public static string GetName()
        {
            switch (rand.Next(0, 3))
            {
                case 0:
                    return "Alien";
                case 1:
                    return "Larvae";
                case 2:
                    return "Predator";
            }
            return "";

        }
        public static string GetType()
        {
            switch (rand.Next(0, 3))
            {
                case 0:
                    return "Fire";
                case 1:
                    return "Water";
                case 2:
                    return "Grass";
            }
            return "Normal";

        }

    }
}
