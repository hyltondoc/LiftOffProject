using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using LiftOffProject.Models;

namespace LiftOffProject.ViewModels
{
    public class AddWineCategoryViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Flavor is required")]
        public string Flavors { get; set; }




        public AddWineCategoryViewModel(string name, string flavors)
        {
            Name = name;
            Flavors = flavors;
        }

        public AddWineCategoryViewModel()
        {
        }
    }
}
