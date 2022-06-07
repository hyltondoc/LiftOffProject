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
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        [Authorize]
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
            return Redirect("Index");
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


    }
}
