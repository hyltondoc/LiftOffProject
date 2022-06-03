using Microsoft.AspNetCore.Mvc;

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
