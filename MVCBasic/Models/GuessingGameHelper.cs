using Microsoft.AspNetCore.Mvc;

namespace MVCBasic.Models
{
    public class GuessingGameHelper
    {
        
        public static string checkGuess(int number, int guess)
        { //
            if (number > guess)
            {
                return $"Too low, guessed number: {guess}.";
            }
            else if (number < guess)
            {
                return $"Too high, guessed number: {guess}.";
            }
            return $"Congratulation! Right guessed nubmer: {guess}!";
        }

    }
}

       

