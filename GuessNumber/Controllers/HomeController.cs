using GuessNumber.Logic;
using GuessNumber.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GuessNumber.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(NumberModel model)
        {
            if (model.Reset == "Reset")
            {
                RandomNumberLogic.GetRandomNumber();
                RandomNumberLogic.ClearGuessesList();
            }

            if(model.GuessedNumber != null && ModelState.IsValid)
            {
                if(model.GuessedNumber == RandomNumberLogic.RandomNumber)
                {
                    var numbers = new NumberModel
                    {
                        RandomNumber = RandomNumberLogic.RandomNumber,
                        GuessedNumber = model.GuessedNumber,
                        Guesses = RandomNumberLogic.SaveNumber(model.GuessedNumber),
                        NumberGuessed = true
                    };

                    return View(numbers);
                }
                else
                {
                    var numbers = new NumberModel
                    {
                        RandomNumber = RandomNumberLogic.RandomNumber,
                        GuessedNumber = model.GuessedNumber,
                        Guesses = RandomNumberLogic.SaveNumber(model.GuessedNumber),
                        NumberGuessed = false
                    };

                    return View(numbers);
                }
            }
            else
            {
                return View(new NumberModel { NumberGuessed = false });
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}