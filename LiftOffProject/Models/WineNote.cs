using System;

namespace LiftOffProject.Models
{
    public class WineNote
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public WineNote()
        { 
        }

        public WineNote(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
