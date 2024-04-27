using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NarrativeProject.Rooms;

namespace NarrativeProject
{
    internal class Communication : Room
    {
        internal override string CreateDescription() =>
            @"You are currently inside the Communication room.
-------------------------------------------------------------
-------------------------------------------------------------
After defeating this last enemy, you finally reach the communication room.
In order to seek exterior help, you must simply activate the radio.

Activate [radio].

Return to the [corridor].";
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "radio":
                    {
                        Console.WriteLine("You send a distress signal to close by Unit.");
                        Console.WriteLine("They are coming to your help but you must survive in the meantime...\n\n");
                        Console.WriteLine("This concludes the end of PART 1 of this game.");
                        Console.WriteLine("Thanks for playing.");
                        Console.ReadKey();
                        Game.Finish();

                        break;
                    }
                case "corridor":
                    {
                        Console.WriteLine("You step out of the communication room.");
                        Game.Transition<Corridor>();
                        break;
                    }
            }
        }
    }
}
