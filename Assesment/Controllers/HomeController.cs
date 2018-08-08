using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assesment.Helpers;
using Assesment.Models;

namespace Assesment.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            GuessModel model = new GuessModel();

            model.MinValue = 10; //hard coded
            model.MaxValue = 20; //hard coded

            model.randomNumber = RandomNumberGenertor.RandomNumber(model.MinValue, model.MaxValue);

            Session["random"] = model.randomNumber;

            model.Message = "Please, input your guess between " + model.MinValue + " and " + model.MaxValue + model.randomNumber;

            Session["attempts"] = 0;

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(GuessModel model)
        {
            if (model.Guess == (int)Session["random"])
            {
                return RedirectToAction("GameWin", "Home");
            }

            Session["attempts"] = ((int)Session["attempts"]) + 1;

            if ((int)Session["attempts"] == 3)
            {
                return RedirectToAction("GameLost", "Home");
            }

            model.Message = "Hi, you have " + (3 - (int)Session["attempts"]) + " attempts left.";

            return View(model);
        }

        public ActionResult GameLost()
        {
            GuessModel model = new GuessModel();

            model.Message = "You could not guess the number in 3 attempts. Sorry";

            return View(model);
        }

        public ActionResult GameWin()
        {
            GuessModel model = new GuessModel();

            model.Message = "Success! You guessed the random number!";

            return View(model);
        }
    }
}