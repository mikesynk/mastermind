namespace Mastermind
{
    public class Messages
    {
        public static string CrackedTheCode(int[] code)
        {
            return $"\nThe code was:  {code[0]} | {code[1]} | {code[2]} | {code[3]}";
        }

        public static string EnterNumber(int number)
        {
            return $"\nPlease enter a number for spot {number}: ";
        }
                
        public static string MasterMind = "*********Mastermind**********";

        public static string NotANumber = "\nYour input is not a number.";

        public static string NotWithinRange(int guess)
        {
            return $"\n\n** The number {guess} is not within the range of 1- 6.";
        }

        public static string NumberOfGuesses(int guesses)
        {
            return $"You cracked the code in {guesses} guesses!";
        }

        public static string PressEnter = "\nPress 'enter' to continue.";

        public static string UnsuccessfulGame = "\nYou were unsuccessful in tried to break the code.";
    }
}
