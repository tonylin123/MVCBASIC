using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCBasic.Models;

namespace MVCBasic.Controllers
{
    public class GuessingGameController : Controller
    {
        Random rnd = new Random();
        int guesses = 0;

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GuessingGame()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetInt32("Guesses").ToString()))
            {

                int Guesses = 0;

                HttpContext.Session.SetInt32("number", rnd.Next(1, 100));
                HttpContext.Session.SetInt32("Guesses", Guesses);
            }
            else
            {
                ViewBag.Guesses= HttpContext.Session.GetInt32("Guesses");
            }
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
                Restart();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Restart()
        {

            int Guesses = 0;
            HttpContext.Session.SetInt32("number", rnd.Next(1, 100));
            HttpContext.Session.SetInt32("Guesses", Guesses);
            return View("GuessingGame");
        }
    }
}