﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiftOffProject.Models;
using LiftOffProject.Data;
using Microsoft.EntityFrameworkCore;
using LiftOffProject.ViewModels;


namespace LiftOffProject.Controllers
{
    public class ListController : Controller
    {
        internal static Dictionary<string, string> ColumnChoices = new Dictionary<string, string>()
        {
            {"all", "All" },
            {"red", "Red" },
            {"white", "White"}
        };

        internal static List<string> TableChoices = new List<string>()
        {
            "winecategory",
            "notes"
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
            ViewBag.winecategory = context.WineCategories.ToList();
            ViewBag.notes = context.Notes.ToList();

            return View();
        }

        public IActionResult Wine(string column, string value)
        {
            List<Wine> wines = new List<Wine>();
            List<WineDetailViewModel> detail = new List<WineDetailViewModel>();

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
                    detail.Add(newDisplayWine);
                }
                ViewBag.title = "All Availabe Wines";
            }
           
             else
            {
                if (column == "winecategories")
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
                        detail.Add(newDisplayWine);
                    }
                }
                else if (column == "notes")
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
                        detail.Add(newDisplayWine);
                    }
                }
                ViewBag.title = "Wines with " + ColumnChoices[column] + ": " + value;
            }
             ViewBag.wines = detail;

            return View();
        }
    }
}