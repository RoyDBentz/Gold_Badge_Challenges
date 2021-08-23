using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_KomodoCafe
{
    public class MenuItem   
    {             
            
        public string Calories { get; set; }
        public string MealName { get; set; }            
        public Double Price { get; set; }
        public string Description { get; set; }
        public string MealNumber { get; set; }
        public string Ingredients { get; set; }
        public MenuItem() { }
        public MenuItem(string mealNumber, string mealName, string description, string ingredients, double price, string calories)
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
