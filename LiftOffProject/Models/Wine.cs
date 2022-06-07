using System;
using System.Collections.Generic;

namespace LiftOffProject.Models
{
    public class Wine
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public WineCategory Category { get; set; }
        public int CategoryId { get; set; }

        public List<WineNote> WineNotes { get; set; }
        public Wine()
        {

        }

        public Wine(string name)
        {
            Name = name;
        }
    }
}
