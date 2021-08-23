using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_KomodoCafe
{
    class ProgramUI
    {
        readonly MenuRepository _repo = new MenuRepository();
        public void Run()
        {
            SeedContent();
            Menu();
        }

        public void SeedContent()
        {
            MenuItem firstItem = new MenuItem("#1", "Perfection", "1/3 lb. Burger with lettuce, tomato, bacon, onion, carmalized mushrooms, on a pretzel bun served with fries.", "Ingredients: Burger, Lettuce, Tomato, Bacon, Onion, Mushroom, Pretzel Bread, with potato.", 4.99, "Calories 653");

            MenuItem secondtItem = new MenuItem("#2", "Logistics", "Grilled chicken wrapped with lettuce, tomato, croutons, in a spinach wrap for eating on the go.", "Ingredients: Chicken, Lettuce, Tomato, Croutons, Spinach Wrap", 3.99, "Calories 325");

            MenuItem thirdItem = new MenuItem("#3", "Shake it Up", "Enjoy the blue moo cookie dough milk shake topped with whip cream and 3 cherries.", "Ingredients: SKIM MILK, CREAM, SUGAR, COOKIE DOUGH BITS (WHEAT FLOUR, SUGAR, MARGARINE [PARTIALLY HYDROGENATED SOYBEAN OIL, WATER, SALT, SOY LECITHIN, NATURAL FLAVOR, MONO & DIGLYCERIDES, ANNATTO AND TURMERIC (COLOR), VITAMIN A PALMITATE, WHEY], CANDY COATED CHOCOLATE CHIPS [SUGAR, CHOCOLATE, COCOA BUTTER, SOY LECITHIN, NATURAL FLAVOR, CORN STARCH, GUM ARABIC, CONFECTIONERS GLAZE, YELLOW 5 & 6 LAKE, RED 40 LAKE, RED 3, BLUE 1 &2 LAKE, CARNAUBA WAX], CREAM CHEESE [CREAM, SKIM MILK, SODIUM AND CALCIUM CASEINATE, SALT, CITRIC, PHOSPHORIC, LACTIC ACIDS AND ACETIC ACIDS, XANTHAN GUM, LOCUST BEAN GUM, GUAR GUM, NATURAL FLAVORS], CORN STARCH, VANILLA EXTRACT, TITANIUM DIOXIDE), CORN SYRUP, STABILIZER (MONO & DIGLYCERIDES, CELLULOSE GUM, LOCUST BEAN GUM, CARRAGEENAN), NATURAL AND ARTIFICIAL FLAVOR, BLUE 1", 2.99, "Calories 575");

            _repo.AddMenuItem(firstItem);
            _repo.AddMenuItem(thirdItem);
            _repo.AddMenuItem(thirdItem);
        }

        public void Menu()
        {
            Console.WriteLine("What would you like to do?\n" +
                "1. Add New Item\n" +
                "2. Remove existing item\n" +
                "3. View all items\n" +
                "4. Exit Program\n");
            string menuSelection = Console.ReadLine();

            switch (menuSelection)
            {
                case "1":
                    AddMenuItem();
                    break;

                case "2":
                    RemoveMenuItem();
                    break;

                case "3":
                    ShowAllMenuItems();
                    break;

                case "4":
                    Console.WriteLine("Thanks for visiting.\n" +
                        "Enjoy the rest of your day!\n" +
                        "Press any key to continue.");
                    Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("Please make a valid selction.\n" +
                        "Press any key to continue.");
                    break;


            }
            void AddMenuItem()
            {
                Console.Clear();
                MenuItem menuItem = new MenuItem();
                Console.WriteLine("What number for people to say when ordering would you like to assign?");
                menuItem.MealNumber = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("What is the name of the meal?");
                menuItem.MealName = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("What is the description of the meal?");
                menuItem.Description = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("What are the ingredients?");
                menuItem.Ingredients = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("What is the price?");
                string priceName = Console.ReadLine();
                menuItem.Price = Convert.ToDouble(priceName);
                Console.Clear();

                Console.WriteLine("How many calories does this meal have?");
                menuItem.Calories = Console.ReadLine();

            }
            void RemoveMenuItem()
            {
                Console.Clear();
                Console.WriteLine("Enter meal name of meal you would like to remove:");
                string name = Console.ReadLine();
                MenuItem item = _repo.GetMenuItemByName(name);
                if (item == null)
                {
                    Console.WriteLine("Item name not found.");
                }
                else
                {
                    DisplayItems(item);
                    Console.WriteLine("Are you sure you want to delete item? 1 = Yes, 2 = No");
                    string answer = Console.ReadLine();
                    if (answer == "1")
                    {
                        _repo.RemoveMenuItem(name);
                    }
                    else if (answer == "2")
                    {
                        Console.WriteLine("You chose not to delete the item.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection.");
                        Console.WriteLine("Are you sure you want to delete item? 1 = Yes, 2 = No");
                        answer = Console.ReadLine();
                    }
                }

            }
            void DisplayItems(MenuItem item)
            {
                Console.WriteLine($"{item.MealNumber},{item.MealName},{item.Description}, {item.Ingredients}, {item.Price}, {item.Calories}");
            }

            void ShowAllMenuItems()
            {
                Console.Clear();
                List<MenuItem> items = _repo.GetAllMenuItems();
                foreach (MenuItem content in items)
                {
                    DisplayItems(content);
                }
            }

        }
    }
}
