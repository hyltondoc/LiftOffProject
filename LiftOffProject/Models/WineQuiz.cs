using System;
using static System.Net.Mime.MediaTypeNames;

namespace LiftOffProject.Models
{
    public class WineQuiz
    {
        public string Name { get; set; }
        public Range Range { get; set; }
        public string Description { get; set; }
     
        public WineQuiz(string name, Range range, string description)
        {
            Name = name;
            Range = range;
            Description = description;
            
        }

      
    }
}
