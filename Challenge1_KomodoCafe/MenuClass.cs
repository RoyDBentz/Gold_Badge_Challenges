using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_KomodoCafe
{
    class MenuClass
    {
        private int _calories;
        public int Calories
        {
            get { return _calories; }
            set { _calories = value; }
        }
        public string MealName { get; set; }
        private double _price;
        public Double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public string Description { get; set; }
        public string MealNumber { get; set; }
        public string Ingredients { get; set; }

        public MenuClass(string mealName, string description, string mealNumber, string ingredients, int calories, double price)
        {
            MealName = mealName;
            Calories = calories;
            Description = description;
            MealNumber = mealNumber;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
