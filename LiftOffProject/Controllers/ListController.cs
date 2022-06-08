using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiftOffProject.Models;
using LiftOffProject.Data;
using Microsoft.EntityFrameworkCore;
using LiftOffProject.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace LiftOffProject.Controllers
{
    [Authorize]
    public class ListController : Controller
    {
        internal static Dictionary<string, string> ColumnChoices = new Dictionary<string, string>()
        {
            {"all", "All" },
            {"category", "WineCategory" },
            {"note", "WineNote"}
        };

        internal static List<string> TableChoices = new List<string>()
        {
            "category",
            "note"
        };

        private ApplicationDbContext context;

        public ListController(ApplicationDbContext dbcontext)
        {
            context = dbcontext;
        }

        public IActionResult Index()
        {
            ViewBag.columns = ColumnChoices;
            ViewBag.tablechoices = TableChoices;
            ViewBag.winecategories = context.WineCategories.ToList();
            ViewBag.notes = context.Notes.ToList();

            return View();
        }

        public IActionResult Wine(string column, string value)
        {
            List<Wine> wines = new List<Wine>();
            List<WineDetailViewModel> displayWines = new List<WineDetailViewModel>();

            if (column.ToLower().Equals("all")) 
            {
                wines = context.Wines
                    .Include(j => j.Category)
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
                ViewBag.title = "All Availabe Wines";
            }
           
             else
            {
                if (column == "category")
                {
                    wines = context.Wines
                        .Include(j => j.Category)
                        .Where(j => j.Category.Name == value)
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
                else if (column == "note")
                {
                    List<WineNote> wineNotes = context.WineNotes
                        .Where(j => j.Notes.Name == value)
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
                ViewBag.title = "Wines with " + ColumnChoices[column] + ": " + value;
            }
             ViewBag.wines = displayWines;

            return View();
        }
        //public IActionResult Delete()
        //{
        //    ViewBag.wines = context.Wines.ToList();

        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Delete(int[] wineIds)
        //{
        //    foreach (int wineId in wineIds)
        //    {
        //        Wine theWine = context.Wines.Find(wineId);
        //        context.Wines.Remove(theWine);
        //    }

        //    context.SaveChanges();

        //    return Redirect("/List");
        //}
    }
}
