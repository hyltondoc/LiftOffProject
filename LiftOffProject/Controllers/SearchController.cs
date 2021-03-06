using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiftOffProject.Models;
using LiftOffProject.Data;
using Microsoft.EntityFrameworkCore;
using LiftOffProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System;

namespace LiftOffProject.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        private ApplicationDbContext context;

        public SearchController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }


        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Wine> wines;
            List<WineDetailViewModel> displayWines = new List<WineDetailViewModel>();

            if(string.IsNullOrEmpty(searchTerm))
            {
                wines = context.Wines
                   .Include(j => j.Category)
                   .ToList();

                foreach (var wine in wines)
                {
                    List<WineNote> wineNotes = context.WineNotes
                        .Where(js => js.WineId == wine.Id)
                        .Include(js => js.Notes)
                        .ToList();

                    WineDetailViewModel newDisplayWine = new WineDetailViewModel(wine, wineNotes);
                    displayWines.Add(newDisplayWine);
                }
            }
            else
            {
                if (searchType == "category")
                {
                    wines = context.Wines
                        .Include(j => j.Category)
                        .Where(j => j.Category.Name == searchTerm)
                        .ToList();

                    foreach (Wine wine in wines)
                    {
                        List<WineNote> wineNotes = context.WineNotes
                        .Where(js => js.WineId == wine.Id)
                        .Include(js => js.Notes)
                        .ToList();

                        WineDetailViewModel newDisplayWine = new WineDetailViewModel(wine, wineNotes);
                        displayWines.Add(newDisplayWine);
                    }

                }
                else if (searchType == "note")
                {
                    List<WineNote> wineNotes = context.WineNotes
                        .Where(j => j.Notes.Name == searchTerm)
                        .Include(j => j.Wine)
                        .ToList();

                    foreach (var wine in wineNotes)
                    {
                        Wine foundWine = context.Wines
                            .Include(j => j.Category)
                            .Single(j => j.Id == wine.WineId);

                        List<WineNote> displayNotes = context.WineNotes
                            .Where(js => js.WineId == foundWine.Id)
                            .Include(js => js.Notes)
                            .ToList();

                        WineDetailViewModel newDisplayWine = new WineDetailViewModel(foundWine, displayNotes);
                        displayWines.Add(newDisplayWine);
                    }
                }
            }

            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.title = "Wines with " + ListController.ColumnChoices[searchType] + ": " + searchTerm;
            ViewBag.wines = displayWines;

            return View("Index");

        }
    }
}
