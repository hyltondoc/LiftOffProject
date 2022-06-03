using System;
using System.Collections.Generic;

namespace LiftOffProject.Models
{
    public class Wine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public Wine()
        {

        }

        public Wine(string name)
        {
            Name = name;
        }
    }
}
