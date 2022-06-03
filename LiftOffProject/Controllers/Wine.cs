using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiftOffProject.Models;


namespace LiftOffProject.Controllers
{
    public class Wine : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
