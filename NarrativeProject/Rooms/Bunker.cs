using System;
using System.IO;

namespace NarrativeProject.Rooms
{
    
    internal class Bunker : Room
    {
        
        internal override string CreateDescription()
        {
            if (!Event.isFirstEventTriggered)
            {
              return @"You are in your bunker.
-------------------------------------------------------------
-------------------------------------------------------------
As mentioned earlier, you have a really hard time to see 3ft away from you. 


Despite the darkness invading the whole room, you do remember vaguely where the entrance to the 
[corridor] is.
--
You also remember how important it can be to have a [flashlight] when it comes to energy outbreak.

Also, if you wish to quit the game, you can do so at any
 given time inside the bunker. Just enter [quit] and your game will save automatically.""


";
            }
            else
            {
                return @"You are back in your bunker.
-------------------------------------------------------------
-------------------------------------------------------------
As mentioned earlier, you have a really hard time to see 3ft away from you.

Despite the darkness invading the whole room, you do remember vaguely where the entrance to the 
[corridor] is.

The [bathroom] is located to the left of you.

Also, if you wish to quit the game, you can do so at any
 given time inside the bunker. Just enter [quit] and your game will save automatically.";


            }
        }
            


        internal override void ReceiveChoice(string choice)
        {
            if (!Event.isFirstEventTriggered)
            {


                switch (choice)
                {
                    case "flashlight":
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Amazing, you find your first tool !");
                            Players.isFlashlightCollected = true;
                            Console.ResetColor();
                            break;
                        }
                    case "quit":
                        {
                            Program.Quit();
                            break;
                        }




                        
                    case "corridor":
                        if (!Players.isFlashlightCollected)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("I really can't see anything in here...");
                            Console.WriteLine("I'd better find some light...");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("You can finally see around you and make it out of your Bunker.\n\n");
                            Console.ResetColor();
                            Console.WriteLine("Press any KEY to continue.");
                            Console.ReadKey();
                            Event.FirstEvent();

                        }
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid command.");
                        Console.ResetColor();
                        break;
                }
            }
            else if (Event.isFirstEventTriggered)
            {
                

                switch (choice)
                {
                    case "flashlight":
                        {
                            Console.WriteLine("You already have a flashlight in your hands...");
                            break;
                        }
                    case "corridor":
                        if (!Players.isFlashlightCollected)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("I really can't see anything in here...");
                            Console.WriteLine("I'd better find some light...");
                            Console.ResetColor();

                            break;
                        }
                        else
                        {
                            Console.WriteLine("You carefully make your way outside the Bunker");
                            Game.Transition<Corridor>();
                            break;

                        }
                    case "bathroom":
                        {
                            Console.WriteLine("You make your way inside the bathroom using your flashlight");
                            Game.Transition<Bathroom>();
                            break;
                        }
                    case "quit":
                        {
                            Program.Quit();
                            break;
                        }
                }
                if (Players.isGeneratorRoomChecked)
                {
                    switch (choice)
                    {
                        case "code":
                            {
                                string filePath = "code.txt";
                                if (File.Exists(filePath))
                                {
                                    File.Delete(filePath);
                                    break;
                                }
                                else
                                {


                                    Console.WriteLine("You look around the room with the flashlight in your mouth...");
                                    Console.WriteLine("You finally manage to find the new 4 digit code !\n");
                                    int code = Rand.GetCode();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("The code for the door is... " + code);
                                    Console.ResetColor();
                                    Rand.isCodeGenerated = true;
                                    break;
                                }
                            }
                       
                    }    
                }
                
            }
        }
        
    }
}
