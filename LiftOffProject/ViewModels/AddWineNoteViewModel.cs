using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using LiftOffProject.Models;


namespace LiftOffProject.ViewModels
{
    public class AddWineNoteViewModel
    {
        [Required(ErrorMessage = "Wine is required")]
        public int WineId { get; set; }

        [Required(ErrorMessage = "Note is required")]
        public int NotesId { get; set; }

        public Wine Wine { get; set; }

        public List<SelectListItem> Notes { get; set; }

        public AddWineNoteViewModel(Wine theWine, List<Notes> possibleNotes)
        {
            Notes = new List<SelectListItem>();

            foreach (var note in possibleNotes)
            {
                Notes.Add(new SelectListItem
                {
                    Value = note.Id.ToString(),
                    Text = note.Name
                });
            }

            Wine= theWine;
        }

        public AddWineNoteViewModel()
        {
        }
    }
}
