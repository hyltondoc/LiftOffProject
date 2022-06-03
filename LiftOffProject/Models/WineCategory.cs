using System;
using System.Collections.Generic;
namespace LiftOffProject.Models
{
    public class WineCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public WineCategory(string name)
        {
            Name = name;
        }

        public WineCategory()
        {
        }
    }
}
