using System;
using System.Collections.Generic;

namespace Mastermind
{
    public class Prompts
    {
        public int[] EnterGuess()
        {
            var codeGuess = new int[4];
            int guessNumber = 0;
            
            do
            {
                Console.WriteLine(Messages.EnterNumber(guessNumber));
                var guess = Console.ReadKey();
                var numberRange = new List<int> { 1, 2, 3, 4, 5, 6 };
                var isInputANumber = int.TryParse(guess.KeyChar.ToString(), out int guessInt);

                if (isInputANumber)
                {
                    if (numberRange.Contains(guessInt))
                    {
                        codeGuess[guessNumber - 1] = Convert.ToChar(guessInt);
                        guessNumber++;
                    }
                    else
                        Console.WriteLine($"{Messages.NotWithinRange(guessInt)}");
                }
                else
                    Console.WriteLine($"{Messages.NotANumber}{Messages.PressEnter}");
            } while (guessNumber < 5);

            return codeGuess;
        }

        public List<int[]> AddGuessToGuesses(int[] latestGuess, List<int[]> guesses)
        {
            guesses.Add(latestGuess);
            return guesses;
        }
    }
}
