using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LiftOffProject.Models;
using LiftOffProject.ViewModels;
using LiftOffProject.Data;

namespace LiftOffProject.Controllers
{
    public class NotesController : Controller
    {
        private ApplicationDbContext context;

        public NotesController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            List<Notes> notes = context.Notes.ToList();
            return View(notes);
           
        }

        [HttpPost]
        public IActionResult Add(Notes notes)
        {
            if (ModelState.IsValid)
            {
                context.Notes.Add(notes);
                context.SaveChanges();
                return Redirect("/Notes/");
            }

            return View("Add", notes);
        }

        public IActionResult AddWine(int id)
        {
            Wine theWine = context.Wines.Find(id);
            List<Notes> possibleNotes = context.Notes.ToList();
            AddWineNoteViewModel viewModel = new AddWineNoteViewModel(theWine, possibleNotes);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddWine(AddWineNoteViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                int wineId = viewModel.WineId;
                int noteId = viewModel.NotesId;

                List<WineNote> existingItems = context.WineNotes
                    .Where(js => js.WineId == wineId)
                    .Where(js => js.NotesId == noteId)
                    .ToList();

                if (existingItems.Count == 0)
                {
                    WineNote wineNote = new WineNote
                    {
                        WineId = wineId,
                        NotesId = noteId
                    };
                    context.WineNotes.Add(wineNote);
                    context.SaveChanges();
                }

                return Redirect("/Home/Detail/" + wineId);
            }

            return View(viewModel);
        }

        public IActionResult About(int id)
        {
            List<WineNote> wineNotes = context.WineNotes
                .Where(js => js.NotesId == id)
                .Include(js => js.Wine)
                .Include(js => js.Notes)
                .ToList();

            return View(wineNotes);
        }
    }
}
