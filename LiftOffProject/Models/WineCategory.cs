using System;


namespace LiftOffProject.Models
{
    public class WineCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Flavors { get; set; }
        public WineCategory()
        {
        }
        public WineCategory(string name, string flavors)
        {
            Name = name;
            Flavors = flavors;
        }
    }
}
