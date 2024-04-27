using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NarrativeProject.Rooms;

namespace NarrativeProject
{

    public class Rand
    {
        private static int code = -1;


        public static int GenerateCode()
        {

            int seed = DateTime.Now.GetHashCode();


            Random rand = new Random(seed);


            return rand.Next(1000, 9999);

        }


        public static void SaveCode(int code)
        {
            string filePath = "code.txt";
            File.WriteAllText(filePath, code.ToString());
        }
        internal static bool isCodeGenerated;

        public static int GetCode()
        {
            if (code == -1)
            {
                string filePath = "code.txt";

                if (File.Exists(filePath))
                {

                    string codeString = File.ReadAllText(filePath);
                    if (int.TryParse(codeString, out int savedCode))
                    {

                        code = savedCode;
                        return code;
                    }
                }


                code = GenerateCode();
                SaveCode(code);
            }


            return code;
        }
    }

    public class PatternMatchingPuzzle
    {
        private static string[] playerSequence;
        private static string[] answerSequence;
        private static int maxAttempts;
        private static int currentAttempt;

        public static void Run()
        {
            int sequenceLength = 3; 
            maxAttempts = 5; 

            currentAttempt = 0;

            Console.WriteLine("In order to establish the power back up, you must execute a RESET.");
            Console.WriteLine("Try to replicate the sequence to trigger the RESET.");
            Console.WriteLine("The sequence has a lenght of 3 and can't contain duplicates.\n");
            Console.WriteLine("Good Luck");

            GenerateSequences(sequenceLength);

            

            while (currentAttempt < maxAttempts)
            {
                Console.WriteLine($"Attempt {currentAttempt + 1}/{maxAttempts}:");
                Console.WriteLine("Enter your guess (e.g., Circle Triangle Square ):");
                Console.ForegroundColor = ConsoleColor.Red;
                string[] guess = Console.ReadLine().Split(' ');
                Console.ResetColor();

                if (CheckGuess(guess))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Congratulations! You've solved the puzzle.");
                    Console.ResetColor();
                    Players.isPuzzleResolved = true;
                    return;
                }
                currentAttempt++;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Sorry, you've run out of attempts. Better luck next time!");
            Console.WriteLine($"The correct sequence was: {string.Join(" ", answerSequence)}");
            Console.ResetColor();
        }

        
        private static void GenerateSequences(int length)
        {
            string[] symbols = { "Circle", "Triangle", "Square",  }; 

            Random rand = new Random();

            
            string[] shuffledSymbols = symbols.OrderBy(x => rand.Next()).ToArray();

            
            answerSequence = shuffledSymbols.Take(length).ToArray();

            
            playerSequence = (string[])answerSequence.Clone();
            Shuffle(playerSequence, rand);
        }

        
        private static void Shuffle<T>(T[] array, Random rand)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                T temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        
        private static bool CheckGuess(string[] guess)
        {
            if (guess.Length != playerSequence.Length)
            {
                Console.WriteLine("Invalid guess length.");
                return false;
            }

            bool isCorrect = true;
            for (int i = 0; i < playerSequence.Length; i++)
            {
                if (guess[i] != playerSequence[i])
                {
                    isCorrect = false;
                    break;
                }
            }

            if (isCorrect)
            {
                return true;
            }
            else
            {
                int correctPositionCount = 0;
                int correctSymbolCount = 0;

                HashSet<int> checkedIndices = new HashSet<int>();

                for (int i = 0; i < playerSequence.Length; i++)
                {
                    if (guess[i] == playerSequence[i])
                    {
                        correctPositionCount++;
                        checkedIndices.Add(i);
                    }
                }

                for (int i = 0; i < playerSequence.Length; i++)
                {
                    if (!checkedIndices.Contains(i) && Array.IndexOf(playerSequence, guess[i]) != -1)
                    {
                        correctSymbolCount++;
                        checkedIndices.Add(i);
                    }
                }

                Console.WriteLine($"Correct position: {correctPositionCount}, Correct symbol: {correctSymbolCount}");

                return false;
            }
        }
    }
}