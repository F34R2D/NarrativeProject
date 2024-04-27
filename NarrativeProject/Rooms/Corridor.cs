using System;

namespace NarrativeProject.Rooms
{
    internal class Corridor : Room
    {
        int correctCode = Rand.GetCode();

        internal override string CreateDescription()
        {


            if (!Players.isPuzzleResolved)
            {

                return @"You are currently in the corridor.
-------------------------------------------------------------
-------------------------------------------------------------

There is almost no light expect those emergency small light that lits up whenever a power surge happens. 
Fortunately for you, the generator room has always a backup emergency battery which means the door should open itself despite the current events.

You can decide to move to the [communication] room on your right.

The [generator] room is on the far left from you.

The [weaponery] is in front of you.

Finally, you can return to your [bunker]
";
            }
            else
            {
                return @"You are currently in the corridor.
-------------------------------------------------------------
-------------------------------------------------------------
The corridor is lit up with all the lights ! 
You still want to be careful to not get attacked again. 
-------------------------------------------------------------
-------------------------------------------------------------
You can return to your [bunker].

The [generator] room is still accessible.

You can move to the [weaponery].

You can try your luck and go directly to the [commuunication] room.

";

            }
        }

        internal override void ReceiveChoice(string choice)
        {
            if (!Players.isPuzzleResolved)
            {


                switch (choice)
                {

                    case "communication":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You present yourself to the Communication Area but as you feared, the door won't budge a bit due to the lack of electricity.");
                        Console.ResetColor();
                        break;

                    case "generator":
                        if (!Rand.isCodeGenerated)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Sneakily, you move your way to the generator room.\n");
                            Console.WriteLine("You type your admin password...\n");
                            Console.WriteLine("'NO WAY!, I forgot they changed the password yesterday as an automatic UPDATE.'");
                            Console.WriteLine("'I must go back to the [bunker] and get this new [code].");
                            Console.ResetColor();
                            Players.isGeneratorRoomChecked = true;
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Please enter your 4 digit code.");
                            Console.ResetColor();
                            string userInput = Console.ReadLine();
                            int enteredCode;
                            if (int.TryParse(userInput, out enteredCode))
                            {
                                if (enteredCode == correctCode)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Code ACCEPTED. " + "IDENTIFICATION: " + Program.currentPlayer.name + ". You may enter this room.");
                                    Console.ResetColor();
                                    Console.WriteLine("You proceed to enter the [generator] room.\n");
                                    Console.WriteLine("Press any KEY to continue.");
                                    Game.Transition<Generator>();

                                }
                                else
                                {
                                    Console.WriteLine("This code is wrong ! TRY AGAIN !");

                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid 4-digit code.");

                            }
                        }

                        break;
                    case "weaponery":
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("You present yourself to the Communication Area but as you feared, the door won't budge a bit due to the lack of electricity.");
                            Console.ResetColor();
                            break;
                        }
                    case "bunker":
                        {
                            Console.WriteLine("You return to your bunker.");
                            Game.Transition<Bunker>();
                            break;
                        }
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
            else
            {

                switch (choice)
                {
                    case "bunker":
                        {
                            Console.WriteLine("You return to your bunker.");
                            Game.Transition<Bunker>();
                            break;
                        }
                    case "generator":
                        {
                            Console.WriteLine("Welcome back to the Generator room" + Program.currentPlayer.name + ".");
                            Game.Transition<Generator>();
                            break;
                        }
                    case "weaponery":
                        {
                            Console.WriteLine("You walk very carefully to the Weaponery door.\n");
                            Game.Transition<FrontWeapon>();
                            break;

                        }
                    case "communication":
                        {
                            if (!Weaponery.isGrenadePicked || !Weaponery.isSaberPicked || !Weaponery.isFlamePicked)
                            {
                                Console.WriteLine("You walk very carefully to the Weaponery door.\n");
                                Console.WriteLine("Suddenly, a big figures appear ! He engages you in combat without your weapons !");
                                Console.ReadKey();
                                Event.NoWeaponAlt();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("You walk very carefully to the Weaponery door.\n");
                                Console.WriteLine("Suddenly, a big figures appear ! He engages you in combat but this time, you are armed !");
                                Console.ReadKey();
                                Event.FinalBattle();
                                break;
                            }
                            
                        }
                }
            }
            

        }
    }
}
