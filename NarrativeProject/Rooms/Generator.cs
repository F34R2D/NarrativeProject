using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NarrativeProject.Rooms;

namespace NarrativeProject
{
    internal class Generator : Room
    {
        
        internal override string CreateDescription()
        {

            if (!Players.isPuzzleResolved)
            {

                return @"You are currently inside the Generator Room.
-------------------------------------------------------------
-------------------------------------------------------------
The room has dim lights but you know your way around just fine.

To prevent anyone from messing around too hard with the generators,
a security system is in place.

To bypass this security, you must initiate a right squence puzzle.
-------------------------------------------------------------
-------------------------------------------------------------
You can attempt to [bypass] the security.



You can return to the [corridor]";
            }
            else
            {
                return @"You are currently inside the Generator Room.
-------------------------------------------------------------
-------------------------------------------------------------
Now that the lights are back, it means we have access to the [communication] room and the [weaponery] room ! 
I need to make sure to give a distress signal and ask for backup, I don't know how many more of these things are aboard the ship.
-------------------------------------------------------------
-------------------------------------------------------------
You can return to the [corridor].

You also take a glimpse a some [tools] laying on the floor..

";

            }
        }





        internal override void ReceiveChoice(string choice)
        {
       
           switch (choice)
           {
               case "corridor":
                        {
                            Console.WriteLine("You exit the generator room and transfer back to the corridor");
                            
                            Game.Transition<Corridor>();
                            break;
                        }
                case "bypass":
                    {
                        if (!Players.isPuzzleResolved)
                        {
                            PatternMatchingPuzzle.Run();
                            Console.WriteLine();
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("No need to use [bypass] anymore, the electricity is already back and operational !");
                            Console.ResetColor();
                            break;
                        }
                       
                    }
                case "tools":
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You find tools which look useful to disarm traps...");
                        Console.ResetColor();
                        Players.isToolsPickedUp = true; 
                        break;
                    }
                default:
                    Console.WriteLine("Invalid command.");
                    break;



            }

        }
    }
}
