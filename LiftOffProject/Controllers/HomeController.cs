using LiftOffProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LiftOffProject.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LiftOffProject.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace LiftOffProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
       
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private ApplicationDbContext context;

        public HomeController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Wine> wines = context.Wines.Include(j => j.WineNotes).ToList();
            return View(wines);
        }

        [HttpGet("/Add")]
        public IActionResult AddWine()
        {
            AddWineViewModel addWineViewModel = new AddWineViewModel(context.WineCategories.ToList(), context.Notes.ToList());

            return View(addWineViewModel);
        }

        [HttpPost]
        public IActionResult ProcessAddWineForm(AddWineViewModel addWineViewModel, string[] selectedNotes)
        {

            Wine newwine = new Wine
            {
                Name = addWineViewModel.Name,
                CategoryId = addWineViewModel.CategoryId


            };


            foreach (string notesId in selectedNotes)
            {
                WineNote wineNotes = new WineNote
                {
                    Wine = newwine,
                    WineId = newwine.Id,
                    NotesId = Int32.Parse(notesId)
                };


                context.WineNotes.Add(wineNotes);

            }

            context.Wines.Add(newwine);
            context.SaveChanges();
            return Redirect("/List");
        }
        public IActionResult Detail(int id)
        {
            Wine theWine = context.Wines
                .Include(j => j.Category)
                .Single(j => j.Id == id);

            List<WineNote> wineNotes = context.WineNotes
                .Where(js => js.WineId == id)
                .Include(js => js.Notes)
                .ToList();

            WineDetailViewModel viewModel = new WineDetailViewModel(theWine, wineNotes);
            return View(viewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.wines = context.Wines.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] wineIds)
        {
            foreach (int wineId in wineIds)
            {
                Wine theWine = context.Wines.Find(wineId);
                context.Wines.Remove(theWine);
            }

            context.SaveChanges();

            return Redirect("/List");
        }
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}