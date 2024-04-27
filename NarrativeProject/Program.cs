using System;
using System.Media;
using System.Threading;
using NarrativeProject.Rooms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Microsoft.Win32;

namespace NarrativeProject
{
    internal class Program
    {
        internal static string input;
        public static Players currentPlayer = new Players();

        static void Main(string[] args)
        {
            if (!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
            }
            currentPlayer = Load(out bool newP);
            if (newP)
            {
                
                //Event.SecondEvent();
            }
           
            
            
            //NewStart(1);
            var game = new Game();
            game.Add(new Bunker());
            game.Add(new Bathroom());
            game.Add(new Corridor());
            game.Add(new Generator());
            game.Add(new FrontWeapon());
            game.Add(new Weaponery());
            game.Add(new Communication());

            while (!game.IsGameOver())
            {
                Console.WriteLine("Name: " + currentPlayer.name);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(currentPlayer.health + " HP");
                Console.ResetColor();
                Console.WriteLine("Medkit(s): " + currentPlayer.medkit );
                Console.WriteLine("--");
                Console.WriteLine(game.CurrentRoomDescription);
                string choice = Console.ReadLine().ToLower() ?? "";
                Console.Clear();
                game.ReceiveChoice(choice);
                
              

            }

            Console.WriteLine("END");
            Console.ReadLine();
        }

        static Players NewStart(int i)
        {
            Console.Clear();
            Players p = new Players();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("          (o)    (o)");
            Console.WriteLine("            \\    //");
            Console.WriteLine("   /\\        \\  //");
            Console.WriteLine("   ||        ----");
            Console.WriteLine("   ||       /(o) \\");
            Console.WriteLine("   ||      (  <   )");
            Console.WriteLine("  ||       \\ -- /");
            Console.WriteLine("/|_||_|\\__(--====--)");
            Console.WriteLine("  (|_______\\======/\\ \\[[/");
            Console.WriteLine("  ||        (--) \\ \\/ /");
            Console.WriteLine("             /  \\  \\_-/");
            Console.WriteLine("            |====|                      __");
            Console.WriteLine("           (  /\\  )         /_\\  |   | | _ |\\ |");
            Console.WriteLine("           |  )(  |        /   \\ |__ | |__ | \\|");
            Console.WriteLine("           [  ][  ]");
            Console.WriteLine("           _||  ||_");
            Console.WriteLine("          (   ][   )\n\n");
            Console.WriteLine("ALIEN TROUBLE\n\n");
            Console.ResetColor();
            Thread.Sleep(2000);
            Console.WriteLine("Enter your Name:");
            p.name = Console.ReadLine();
            p.id = i;
            Console.Clear();
            Console.WriteLine("You, " + p.name + ", awake in the middle of the night to a very LOUD\n" +
                "noise. Sweating and unsure of what it is, you decide to take your courage and get to the bottom of this.\n\n" +
                "You are finally out of bed but... the light won't work ? You must find the generator room.\n\n");
            Console.WriteLine("Press any KEY to continue.");
            Console.ReadKey();
            Console.Clear();
            return p;
               
        }



        
        public static void Quit()
        {
            Save();
            Environment.Exit(0);    
        }

        public static void Save()
        {
            BinaryFormatter binForm = new BinaryFormatter();
            string path = "saves/" + currentPlayer.id.ToString();
            FileStream file = File.Open(path, FileMode.OpenOrCreate);
            binForm.Serialize(file, currentPlayer);
            file.Close();
        }
        public static Players Load(out bool newP)
        {
            newP = false;
            Console.Clear();
            string[] paths = Directory.GetFiles("saves");
            List<Players> player = new List<Players>();
            int idCount = 0;

            BinaryFormatter binForm = new BinaryFormatter();
            foreach (string p in paths)
            {
                FileStream file = File.Open(p, FileMode.Open);
                Players players = (Players)binForm.Deserialize(file);
                file.Close();
                player.Add(players);

            }
            idCount = player.Count;

            

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose your player:");

                foreach (Players p in player)
                {
                    Console.WriteLine(p.id + ": " + p.name);
                }

                Console.WriteLine("Please input player name or id (id:# or playername). Additionally, 'create' will start a new save!");
                string[] data = Console.ReadLine().Split(':');
                Console.Clear();

                try
                {
                    if (data[0] == "id")
                    {
                        if (int.TryParse(data[1], out int id))
                        {
                            foreach (Players players in player)
                            {
                                if(players.id == id)
                                {
                                    return players;
                                }
                            }
                            Console.WriteLine("There is no player with that ID !");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Your ID needs to be a number ! Press any key to continue.");
                            Console.ReadKey();
                        }
                    }
                    else if (data[0] == "create")
                    {
                        Players newPlayer = NewStart(idCount);
                        newP = true;
                        return newPlayer;
                    }
                    else
                    {
                        foreach (Players players in player)
                        {
                            if(players.name == data[0])
                            {
                                return players;
                            }
                        }
                        Console.WriteLine("There is no player with that ID !");
                        Console.ReadKey();
                    }

                }
                catch(IndexOutOfRangeException)
                {
                    Console.WriteLine("Your ID needs to be a number ! Press any key to continue.");
                    Console.ReadKey();
                }
            }
            

        }

        
    }
}
