using System;
using System.Collections.Generic;

namespace LiftOffProject.Models
{
    public class Quiz
    {
        public Quiz()
        {
        }

        public static List<Wine> Wines = new List<Wine>
        {
            new Wine("Riesling", new Range(1,4),"zdfc"),
            new Wine("Chardonnay", new Range(5,6), "zdfc"),
            new Wine("Pinot Gris", new Range(7,8), "asd"),
            new Wine("Sauvignon Blanc", new Range(9,10), "asd"),
            new Wine("Merlot", new Range(10,11), "asd"),
            new Wine("Pinot Noir", new Range(12,13), "asd"),
            new Wine("Cabernet Sauvignon", new Range(14,15), "asd"),
            new Wine("Zinfinael", new Range(16,17), "asd"),
            new Wine("Rose", new Range(18,19), "asd"),
            new Wine("Champagne", new Range(20,21), "asd"),
        };

        public Dictionary<string, int> Chocolates = new Dictionary<string, int>
        {
            {"Milk Chocolate", 1 },
            {"Dark Chocolate", 2 },
            {"White Chocolate", 3 },
            {"I HATE Chocolate", 4 }
        };
        public int Chocolate { get; set; }

        public Dictionary<string, int> Cocktails = new Dictionary<string, int>
        {
            {"Margarita", 1 },
            {"Gin & Tonic", 2 },
            {"Old Fashioned", 3 },
            {"Vodka Cranberry", 4 }
        };
        public int Cocktail { get; set; }

        public Dictionary<string, int> Fruits = new Dictionary<string, int>
        {
            {"Cherries", 1 },
            {"Apples", 2 },
            {"Peaches", 3 },
            {"Dark Plums", 4 }
        };
        public int Fruit { get; set; }

        public Dictionary<string, int> Vacations = new Dictionary<string, int>
        {
            {"Paris, France", 1 },
            {"Turks & Caicos", 2 },
            {"Sydney, Australia", 3 },
            {"Victoria Falls, Zambia", 4 }
        };
        public int Vacation { get; set; }
    }
}
