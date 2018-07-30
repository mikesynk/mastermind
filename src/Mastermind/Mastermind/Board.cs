using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastermind
{
    public static class Board
    {       
        public static void CurrentDisplay(List<int[]> roundResults, List<Symbol[]> scores)
        {
            Console.Clear();
            Console.WriteLine($"{Messages.MasterMind}\n");

            foreach (int[] rou in roundResults)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine($"Round {roundResults.IndexOf(rou) + 1}         | {rou[0]} | {rou[1]} | {rou[2]} | {rou[3]} |");
                var score = scores.ElementAt(roundResults.IndexOf(rou));
                Console.WriteLine($"Round {roundResults.IndexOf(rou) + 1} Result: {score[0].ToString()}, {score[1].ToString()}, {score[2].ToString()}, {score[3].ToString()}");
            };
        }

        public static void DisplayEmptyBoard()
        {
            int[,] rounds = new int[10, 4];
            for (int i = 0; i < rounds.GetLongLength(0); i++)
            {
                Console.WriteLine("-------------------------");

                if (i == rounds.GetLongLength(0) - 1)
                {
                    Console.WriteLine($" {i + 1}  | {rounds[i, 0]}  | {rounds[i, 1]}  | {rounds[i, 2]}  | {rounds[i, 3]} | ");
                    Console.WriteLine("-------------------------");
                }
                else
                    Console.WriteLine($" {i + 1}   | {rounds[i, 0]}  | {rounds[i, 1]}  | {rounds[i, 2]}  | {rounds[i, 3]} | ");
            }
        }
    }
}
