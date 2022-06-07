using System;

namespace LiftOffProject.Models
{
    public class Notes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Notes()
        {
        }

        public Notes(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
