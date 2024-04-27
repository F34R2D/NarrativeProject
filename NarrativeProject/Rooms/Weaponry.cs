using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class Weaponry : Room
    {
        internal static bool isGrenadeTaken;
        internal static bool isSwordTaken;
        internal static bool isFlameTaken;
        internal override string CreateDescription() =>
            @"You are currently in the Weaponery room.

From memory, you remember where you can find most weapon.

You have access to [grenades] which are great against fire type monsters
You have access to [sword] which is great against water type monsters
Finally, you have access to [flamethrower] which is great against grass type monsters

You can return to the [corridor] lastly.";
            internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "corridor":
                    {
                        Console.WriteLine("You return to the corridor");
                        Game.Transition<Corridor>();
                        break;
                    }
                
            }
            
        }
    }
}
