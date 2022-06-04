using System;
namespace LiftOffProject.Models
{
    public class Wine
    {
        public Wine(string name, Range range, string description)
        {
            Name = name;
            Range = range;
            Description = description;
        }

        public string Name { get; }
        public Range Range { get; }
        public string Description { get; }
    }
}
