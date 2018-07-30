using System;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Play();         
            Console.Read();
        }
    }
}
