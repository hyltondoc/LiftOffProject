using System;

namespace LiftOffProject.Models
{
    public class WineNote
    {
        public int WineId { get; set; }
        public Wine Wine { get; set; }
        public int NotesId { get; set; }
        public Notes Notes { get; set; }    

        public WineNote()
        { 
        }

    }
}
