using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiftOffProject.Models;
using LiftOffProject.Data;
using LiftOffProject.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LiftOffProject.Controllers
{
    public class WineCategoryController : Controller
    {
        private ApplicationDbContext context;

        public WineCategoryController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            List<WineCategory> wineCategories = context.WineCategories.ToList();
            return View(wineCategories);
        }
        public IActionResult Add()
        {
            AddWineCategoryViewModel wineCategoryViewModel = new AddWineCategoryViewModel();
            return View(wineCategoryViewModel);
        }

        [HttpPost]
        public IActionResult ProcessAddWineCategoryForm(AddWineCategoryViewModel wineCategoryViewModel)
        {
            if (ModelState.IsValid)
            {

                string wineCategoryName = wineCategoryViewModel.Name;
                string wineFlavors = wineCategoryViewModel.Flavors;

                List<WineCategory> existingWineCategories = context.WineCategories
                    .Where(wineCategory => wineCategory.Name == wineCategoryName)
                    .Where(wineCategory => wineCategory.Flavors == wineFlavors)
                    .ToList();

                if (existingWineCategories.Count == 0)
                {
                    WineCategory wineCategory = new WineCategory
                    {
                        Name = wineCategoryName,
                        Flavors = wineFlavors
                    };
                    context.WineCategories.Add(wineCategory);
                    context.SaveChanges();

                }

                return Redirect("Index");

            }
            return Redirect("Index");

        }

        public IActionResult About(int id)
        {
            List<WineCategory> wineCategories = context.WineCategories
                .Where(wineCategory => wineCategory.Id == id)
                .ToList();
     
            return View(wineCategories);
         
        }
    }
}
