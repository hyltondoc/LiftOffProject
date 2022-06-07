 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiftOffProject.Data;
using LiftOffProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LiftOffProject.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/Quiz")]
        public IActionResult QuizForm()
        {
            var quiz = new Quiz();
            return View(quiz);
        }

        [HttpPost("/Quiz")]
        public IActionResult QuizResultForm(Quiz quiz)
        {
            var sumOfAnswers = quiz.Chocolate + quiz.Cocktail + quiz.Fruit + quiz.Vacation;

            var winequiz = Quiz.Wines.FirstOrDefault(winequiz => sumOfAnswers >= winequiz.Range.Start.Value && sumOfAnswers <= winequiz.Range.End.Value);

            return View(winequiz);
        }
    }
}
