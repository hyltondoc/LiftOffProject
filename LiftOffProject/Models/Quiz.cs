using System;
using System.Collections.Generic;

namespace LiftOffProject.Models
{
    public class Quiz
    {
        public Quiz()
        {
        }

        public static List<WineQuiz> Wines = new List<WineQuiz>
        {
            new WineQuiz("Riesling", new Range(1,4),"You like it SWEET! Riesling would be a great place to start! It's a deliciously refreshing white wine that is native to growing along the Rhine River in Germany. It boasts crisp flavors of apples, apricots, peaches, and pears along with varying levels of acidity."),
            new WineQuiz("Chardonnay", new Range(5,6), "You can't beat a nice glass of Chardonnay after a long day... Chardonnay is the most popular white wine on earth. It's flavors swing from lemon zest to baked apples or tropical fruits like pineapple."),
            new WineQuiz("Pinot Grigio", new Range(7,8), "Ahhhhh Pinot Grigio, a zesty white wine that is as refreshing as a cold glass of lemonade on a hot summer’s day. Pinot Grigio (aka Pinot Gris) is a dry white wine that has a punchy acidity with flavors of lemons, limes, green apples and honeysuckle."),
            new WineQuiz("Sauvignon Blanc", new Range(9,10), "Sauvignon Blanc is one of the most popular white wines in the U.S. Often referred to as “grassy”, it's known for its refreshing crispness, which is due to its high levels of acidity and low amounts of sugar."),
            new WineQuiz("Merlot", new Range(11,12), "Merlot is the second most popular red grape in America (after Cabernet Sauvignon). Known for being soft, ripe and elegant, most Merlots are easy drinking reds that go well both with food as well as on their own. This is a great recommended as the first red wine someone new to red wine should drink."),
            new WineQuiz("Pinot Noir", new Range(13,14), "The heart rejoices in a good Pinot Noir... Pinot Noir is the most romanticized red wine in the world. It’s loved for its red fruit, flower, and spice aromas that are accentuated by a long, smooth finish."),
            new WineQuiz("Cabernet Sauvignon", new Range(15,16), "The world’s most popular red wine grape is a natural cross between Cabernet Franc and Sauvignon Blanc from Bordeaux, France. Cabernet Sauvignon is loved for its high concentration and age worthiness."),
            new WineQuiz("Zinfandel", new Range(17,18), "Zinfandel is synonymous with California wine. The red variety is planted in more than 10 percent of all Californian vineyards and is an influential player in the state’s wine industry. California’s hot and dry climate creates big, bold flavors along with some of the highest alcohol content of any red wine on the market."),

        };

        public Dictionary<string, int> Chocolates = new Dictionary<string, int>
        {
            {"Milk Chocolate", 3 },
            {"Dark Chocolate", 4 },
            {"White Chocolate", 1 },
            {"I HATE Chocolate", 2 }
        };
        public int Chocolate { get; set; }

        public Dictionary<string, int> Cocktails = new Dictionary<string, int>
        {
            {"Margarita", 2 },
            {"Gin & Tonic", 3 },
            {"Old Fashioned", 5 },
            {"Vodka Cranberry", 1 },
            
        };
        public int Cocktail { get; set; }

        public Dictionary<string, int> Fruits = new Dictionary<string, int>
        {
            {"Cherries", 1 },
            {"Apples", 3 },
            {"Peaches", 2 },
            {"Dark Plums", 4 },
            
        };
        public int Fruit { get; set; }

        public Dictionary<string, int> Vacations = new Dictionary<string, int>
        {
            {"Paris, France", 4 },
            {"Turks & Caicos", 1 },
            {"Sydney, Australia", 3 },
            {"Victoria Falls, Zambia", 2 },
          
        };
        public int Vacation { get; set; }
    }
}
