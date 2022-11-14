using Microsoft.AspNetCore.Mvc;

namespace MVCBasic.Controllers
{
    public class GuessingGameController : Controller
    {
        [HttpGet]
        public IActionResult GuessingGame()
        {

            int Guesses = 0;
            Random random = new Random();
            HttpContext.Session.SetInt32("Number", random.Next(1, 100));
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
            int number = (int)HttpContext.Session.GetInt32("Number");
            if (guess > number)
            {
                ViewBag.Msg = "Too high!";
                return View();
            }
            else if (guess < number)
            {
                ViewBag.Msg = "Too low!";
                return View();
            }
            else
            {
                return View("Win");
            }
        }

    }
}