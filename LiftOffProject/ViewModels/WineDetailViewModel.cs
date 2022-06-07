using LiftOffProject.Models;
using System.Collections.Generic;
using System;

namespace LiftOffProject.ViewModels
{
    public class WineDetailViewModel
    {
        public int WineId { get; set; }
        public string Name { get; set; }
        public string WineCategoryName { get; set; }
        public string NotesText { get; set; }

        public WineDetailViewModel(Wine theWine, List<WineNote> wineNotes)
        {
            WineId = theWine.Id;
            Name = theWine.Name;
            WineCategoryName = theWine.Category.Name;


            NotesText = "";
            for (int i = 0; i < wineNotes.Count; i++)
            {
                NotesText += wineNotes[i].Notes.Name;
                if (i < wineNotes.Count - 1)
                {
                    NotesText += ", ";
                }
            }
        }
    }
}
