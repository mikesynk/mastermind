using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastermind
{
    public class Game
    {
        Prompts prompts = new Prompts();
        private bool _isWinner = false;

        public void Play()
        {
            var guesses = new List<int[]>();
            var scores = new List<Symbol[]>();
            var roundCount = 0;
            Symbol[] roundScore = new Symbol[4];
            
            //Load game title
            Console.WriteLine($"{Messages.MasterMind}\n");

            //Get code
            int[] code = GenerateCode();

            //Display Board
            Board.DisplayEmptyBoard();

            do
            {
                if (roundCount > 0)
                {
                    //Load current board with scores
                    Board.CurrentDisplay(guesses, scores);  
                }

                //Prompt player for guess
                int[] currentGuess = prompts.EnterGuess();

                //Load guess into array of guesses
                guesses = prompts.AddGuessToGuesses(currentGuess, guesses);
                roundCount++;

                //Score the round
                roundScore = CurrentRoundResult(currentGuess, code);
                if (currentGuess.SequenceEqual(code))
                {
                    _isWinner = true;
                    break;
                }
                                                
                //Load score into list of scores
                scores = AddRoundScoreToScores(roundScore, scores);

                //Load guesses into board
                Board.CurrentDisplay(guesses, scores);
            } while (roundCount < 10);

            ExitGame(roundCount, code, _isWinner);
        }

        private void ExitGame(int guesses, int[] code, bool isWinner)
        {
            Console.Clear();
            Console.WriteLine(Messages.MasterMind);
            if (isWinner)
                Console.WriteLine(Messages.NumberOfGuesses(guesses));
            else
                Console.WriteLine(Messages.UnsuccessfulGame);
            Console.WriteLine(Messages.CrackedTheCode(code));
        }

        private List<Symbol[]> AddRoundScoreToScores(Symbol[] roundScore, List<Symbol[]> scores)
        {
            scores.Add(roundScore);
            return scores;
        }

        private static int[] GenerateCode()
        {
            Random random = new Random();
            int[] code = new int[4];
            List<int> generatedNumbers = new List<int>();
 
            for (int i = 0; i < code.Length; i++)
            {
                code[i] = Convert.ToChar(random.Next(1, 7));
            }

            return code;
        }

        private Symbol[] CurrentRoundResult(int[] guess, int[] code)
        {
            Symbol[] roundResult = new Symbol[4];
            List<Symbol> symbolsList = new List<Symbol>();

            _isWinner = guess.SequenceEqual(code);

            if (_isWinner)
            {
                for (int i = 0; i < roundResult.Length; i++)
                {
                    symbolsList.Add(Symbol.Plus);
                }
            }
            else
            {
                for (int i = 0; i < guess.Length; i++)
                {
                    if (code.Contains(guess[i]) && code.ElementAt(i) == guess[i])
                    {
                        symbolsList.Add(Symbol.Plus);
                    }
                    else if (code.Contains(guess[i]))
                    {
                        symbolsList.Add(Symbol.Minus);
                    }
                    else
                    {
                        symbolsList.Add(Symbol.Space);
                    }
                }
            }
            symbolsList = PutScoresInOrder(symbolsList);

            return symbolsList.ToArray();
        }

        private List<Symbol> PutScoresInOrder(List<Symbol> symbols)
        {
            return symbols.OrderByDescending(s => (int) (s)).ToList();
        }
    }
}
