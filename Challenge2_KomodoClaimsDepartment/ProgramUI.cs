using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2_KomodoClaimsDepartment
{
    class ProgramUI
    {        
        Queue<Claim> _claim = new Queue<Claim>();
        public void Run()
        {
            SeedContent();
            Menu();
        }

        public void SeedContent()
        {
            Claim firstItem = new Claim("1", "Car", "Car accident on 465", 400, 4,25,18 , 4,27,18, true );

            Claim secondtItem = new Claim("2", "Logistics", "Grilled chicken wrapped with lettuce, tomato, croutons, in a spinach wrap for eating on the go.", "Chicken, Lettuce, Tomato, Croutons, Spinach Wrap", 3.99, "325");

            Claim thirdItem = new Claim("3", "Shake it Up", "Enjoy the blue moo cookie dough milk shake topped with whip cream and 3 cherries.", "Ice Cream, cookie dough, NATURAL AND ARTIFICIAL FLAVOR, BLUE 1", 2.99, "575");

            _claim.Enqueue(firstItem);
            _claim.Enqueue(secondtItem);
            _claim.Enqueue(thirdItem);
        }

        public void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
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
                        SeeAllClaims();
                        break;

                    case "2":
                        TakeCareOfNextClaim();
                        break;

                    case "3":
                        EnterNewClaim();
                        break;

                    case "4":
                        Console.WriteLine("Thanks for visiting.\n" +
                            "Enjoy the rest of your day!\n");
                        continueToRun = false;
                        ContinueMessage();                        
                        break;

                    default:                        
                        Console.WriteLine("Please make a valid selction.\n" +
                            "Press any key to continue.");
                        Console.ReadLine();
                        break;


                }
            }
            void EnterNewClaim()
            {
                Console.Clear();
                MenuItem item = new MenuItem();
                Console.WriteLine("What number for people to say when ordering would you like to assign?");
                item.MealNumber = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("What is the name of the meal?");
                item.MealName = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("What is the description of the meal?");
                item.Description = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("What are the ingredients?");
                item.Ingredients = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("What is the price?");
                string priceName = Console.ReadLine();
                item.Price = Convert.ToDouble(priceName);
                Console.Clear();

                Console.WriteLine("How many calories does this meal have?");
                item.Calories = Console.ReadLine();

                _repo.AddMenuItem(item);

            }
            void TakeCareOfNextClaim()
            {
                Console.Clear();
                ShowAllMenuItems();
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
                    while (answer != "1" || answer != "2")
                    {
                        if (answer == "1")
                        {
                            _repo.RemoveMenuItem(name);
                            break;
                        }
                        else if (answer == "2")
                        {
                            Console.WriteLine("You chose not to delete the item.");                            
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection.");
                            Console.WriteLine("Are you sure you want to delete item? 1 = Yes, 2 = No");
                            answer = Console.ReadLine();
                        }
                    }
                }

            }
            void DisplayItems(MenuItem item)
            {
                Console.WriteLine($"#{item.MealNumber} -{item.MealName}- \nDescription: {item.Description} \nIngredients: {item.Ingredients} \nCalories: {item.Calories} \nPrice: {item.Price}");
            }

            void SeeAllClaims()
            {
                Console.Clear();
                List<MenuItem> items = _repo.GetAllMenuItems();
                foreach (MenuItem content in items)
                {
                    DisplayItems(content);
                    Console.WriteLine();
                }
            }
            void ContinueMessage()
            {
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
            }

        }
    }
}
