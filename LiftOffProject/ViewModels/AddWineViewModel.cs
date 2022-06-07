using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LiftOffProject.Models;

namespace LiftOffProject.ViewModels
{
    public class AddWineViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }

        public List<SelectListItem> AllWineCategories { get; set; }
        public List<Notes> Notes { get; set; }
        public AddWineViewModel(List<WineCategory> allWineCategories, List<Notes> allNotes)
        {
            AllWineCategories = new List<SelectListItem>();

            foreach (var wineCategories in allWineCategories)
            {
                AllWineCategories.Add(new SelectListItem

                {
                    Value = wineCategories.Id.ToString(),
                    Text = wineCategories.Name
                });
            }

            Notes = allNotes;
        }

        public AddWineViewModel()
        {
        }
    }
}
