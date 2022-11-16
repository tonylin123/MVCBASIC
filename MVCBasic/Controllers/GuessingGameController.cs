using Microsoft.AspNetCore.Mvc;
using MVCBasic.Models;

namespace MVCBasic.Controllers
{
    public class GuessingGameController : Controller
    {
        Random rnd = new Random();
        
        [HttpGet]
        public IActionResult GuessingGame()
        {
            int Guesses = 0;
            HttpContext.Session.SetInt32("number", rnd.Next(1, 100));
            HttpContext.Session.SetInt32("Guesses", Guesses);
            return View();
        }

        [HttpPost]
        public IActionResult GuessingGame(int guess)
        {

            int guesses = (int)HttpContext.Session.GetInt32("Guesses");
            guesses++;
            HttpContext.Session.SetInt32("Guesses", guesses);
            ViewBag.Guesses = guesses;
            ViewBag.Msg = GuessingGameHelper.checkGuess((int)HttpContext.Session.GetInt32("number"), guess);
            if (guess == (int)HttpContext.Session.GetInt32("number"))
            {
                HttpContext.Session.SetInt32("number", rnd.Next(1, 100));
            }
            return View();
        }
        [HttpPost]
        public IActionResult Clear()
        {
            ViewBag.Guesses = string.Empty;
            ViewBag.Msg = string.Empty;

            return View("GuessingGame", GuessingGame());
        }
    }
}