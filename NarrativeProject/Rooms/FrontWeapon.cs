using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NarrativeProject.Rooms;

namespace NarrativeProject
{
    internal class FrontWeapon : Room
    {
        internal override string CreateDescription() =>
            @"As you prepare yourself to open the door, something feels... out of place ?
You start asking yourself if you are not getting crazy over what's going on.
-------------------------------------------------------------
-------------------------------------------------------------
You can either go right a head and [open] the door.

You can also [leave] this area for now.
";


        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "open":
                    {
                        if (!Event.isWeaponDoorDeactivated)
                        {

                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Another bomb device is triggered !\n");
                            Console.WriteLine("You take another 15 damage from the impact.\n");
                            Console.WriteLine("Maybe I should have used the tools...\n");
                            Console.WriteLine("Despite this mistake, you enter the Weaponery room.");
                            Console.ResetColor();
                            Event.WeaponDoor();


                            
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You enter the Weaponery room.");
                            break;
                        }
                    }
                case "leave":
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You decide to leave for the moment and return to the corridor.");
                        Console.ResetColor();
                        Game.Transition<Corridor>();
                        break;
                    }
                case "tools":
                    {
                        if(Players.isToolsPickedUp)
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Good thinking ! You disarm the harmful bomb and make your way inside.");
                        Console.ResetColor();
                        Game.Transition<Weaponery>();
                        Event.isWeaponDoorDeactivated = true;
                        break;
                    }
            }
        }

    }
}
