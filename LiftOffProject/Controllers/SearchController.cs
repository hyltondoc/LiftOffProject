using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiftOffProject.Models;
using LiftOffProject.Data;
using Microsoft.EntityFrameworkCore;



namespace LiftOffProject.Controllers
{
    public class SearchController : Controller
    {
        private ApplicationDbContext context;

        public SearchController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
