using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NarrativeProject.Rooms;

namespace NarrativeProject
{
    internal class Weaponery : Room
    {
        internal static bool isWeaponMedTaken;
        internal static bool isFlamePicked;
        internal static bool isGrenadePicked;
        internal static bool isSaberPicked;
        internal static bool isWeaponsTaken;
        internal override string CreateDescription() =>
         @"You are currently in the Weaponery
-------------------------------------------------------------
-------------------------------------------------------------

The interior feels empty and safe to discover.

You notice a Wall with lots of Weapon on it !

You can see a big [flamethrower].

On the far right, you can see a Box full of [grenades].

 At your feet, a small [box] is partially open.

and Lastly, under a ray of light, a light [saber] is shown on a pedestal.

You can return at anytime into the [corridor].
";


        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "corridor":
                    {
                        Console.WriteLine("You return at once outside, in the corridor.");
                        Game.Transition<Corridor>();
                        break;
                    }
                case "flamethrower":
                    {
                        if (!isFlamePicked)
                        {
                            Console.WriteLine("You pick up the Flamethrower and put it in your INVENTORY");
                            isFlamePicked = true;
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("You already got the flamethrower...");
                            Console.ResetColor();
                            break;
                        }
                    }
                case "grenades":
                    {
                        if (!isGrenadePicked)
                        {
                            Console.WriteLine("You pick up the Grenades and put it in your INVENTORY");
                            isGrenadePicked = true;
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("You already got the grenades...");
                            Console.ResetColor();
                            break;
                        }
                    }
                case "saber":
                    {
                        if (!isSaberPicked)
                        {
                            Console.WriteLine("You pick up the Saber and put it in your INVENTORY");
                            isSaberPicked = true;
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("You already got the saber...");
                            Console.ResetColor();
                            break;
                        }

                    }
                case "box":
                    {
                        if (!isWeaponMedTaken)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("You find 3 brand new Medkits ! ");
                            Program.currentPlayer.medkit += 3;
                            Console.ResetColor();
                            isWeaponMedTaken = true;    
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("You already got all the medkits here...");
                            Console.ResetColor();
                            break;
                        }

                    }
            }
        }
        
    }
}
