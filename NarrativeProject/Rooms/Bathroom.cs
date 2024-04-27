using System;

namespace NarrativeProject.Rooms
{

    internal class Bathroom : Room
    {
        
        


        internal override string CreateDescription()
        {

            if (!Event.isSecondEventTriggered)
            {

                return @"You are currently inside your own Bathroom.
-------------------------------------------------------------
-------------------------------------------------------------
You have access to the [sink].

The [bath] is close right to you.

The [pharmacy] is straight ahead of you.

You can return to your [bunker] lastly.

";
            }
            else
            {
                return @"You are currently inside your own Bathroom.
-------------------------------------------------------------
-------------------------------------------------------------
Exhausted after your first encounter, you take some time to regain control of yourself.
You are now certain that unknown life forms are inside your ship, and you are ready to take them on.
The only thing is, you need to repair the generator and get the lights back on and send a distress call from
the communication room.
-------------------------------------------------------------
-------------------------------------------------------------
You have access to the [sink].

The [bath] is close right to you.

The [pharmacy] is straight ahead of you.

You can return to your [bunker] lastly.

";

            }
        }
        internal override void ReceiveChoice(string choice)
        {
            if (!Event.isSecondEventTriggered)
            {


                switch (choice)
                {
                    case "bath":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("While the idea of a taking a hot bath is tempting, you remember there are no more");
                        Console.WriteLine("electricity which means no hot water, and on top of that, there might be someone else on board !");
                        Console.ResetColor();
                        break;
                    case "sink":
                        Console.WriteLine("You close your eyes and splash water on your face... this situation feels unreal.");
                        Console.WriteLine("As you open your eyes, you see a strange figure in the mirror behind you ! \n");
                        Console.WriteLine("Press any KEY to continue.");
                        Console.ReadKey();
                        Event.SecondEvent();
                        Event.isSecondEventTriggered = true;
                        break;
                    case "bunker":
                        Console.WriteLine("I feel like I need to do something here...");
                        break;
                    case "pharmacy":
                        {
                            if (!Players.isBathroomMedTaken)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("You find 3 medkits in your pharmacy !");
                                Console.WriteLine("You decide to use one on you right away.");
                                Program.currentPlayer.medkit += 2;
                                Program.currentPlayer.health += 15;
                                Console.WriteLine("On use, these medkits can give back 15 HP");
                                Console.ResetColor();
                                Players.isBathroomMedTaken = true;
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
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid command.");
                        Console.ResetColor();
                        break;
                }
            }
            else
            {
                switch (choice)
                {
                    case "bath":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("While the idea of a taking a hot bath is tempting, you remember there are no more");
                        Console.WriteLine("electricity which means no hot water, and on top of that, there might be someone else on board !");
                        Console.ResetColor();
                        break;
                    case "sink":
                        Console.WriteLine("You close your eyes and splash water on your face... this STILL situation feels unreal.");
                        Console.WriteLine("No enemies are attacking you this time...\n");
                        Console.WriteLine("Press any KEY to continue.");
                        Console.ReadKey();
                        
                        
                        break;
                    case "bunker":
                        Console.WriteLine("You return to your bunker.");
                        Game.Transition<Bunker>();
                        break;
                    case "pharmacy":
                        {
                            if (!Players.isBathroomMedTaken)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("You find 3 medkits in youWillr pharmacy !");
                                Console.WriteLine("You decide to use one on you right away.");
                                Program.currentPlayer.medkit += 2;
                                Program.currentPlayer.health += 15;
                                Console.WriteLine("On use, these medkits can give back 15 HP");
                                Console.ResetColor();
                                Players.isBathroomMedTaken = true;
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
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid command.");
                        Console.ResetColor();
                        break;
                }


            }
        }
    }

}