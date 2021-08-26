using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_KomodoInsuranceBadges
{
    class ProgramUI
    {
        readonly BadgeRepository badge = new BadgeRepository();
        public void Run()
        {
            SeedContent();
            Menu();
        }

        public void SeedContent()
        {            
            badge.NewBadgeNumber("12","5");
        }


        public void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit Program\n");
                string menuSelection = Console.ReadLine();

                switch (menuSelection)
                {
                    case "1":                        
                        AddABadge();
                        break;

                    case "2":
                        EditABadge();
                        break;

                    case "3":
                        ListAllBadges();
                        break;

                    case "4":
                        Console.WriteLine("Thanks for visiting.\n" +
                            "Enjoy the rest of your day!\n");
                        continueToRun = false;
                        ContinueMessage();                        
                        break;

                    default:
                        InvalidSelection();
                        break;


                }
            }
            void AddABadge()
            {
                Console.Clear();
                Console.Write("What is the number on the badge:");
                string badgeID = Console.ReadLine();                
                Console.Clear();

                Console.Write("List a door that it needs access to:");
                string door = Console.ReadLine();                
                Console.Clear();

                Console.WriteLine("Any other doors(y/n)");
                Console.ReadLine();
                Console.Clear();

                _badge.Add(badgeID, door);
            }
            void EditABadge()
            {
                Console.Clear();                    
                ContinueMessage();
            }           
                       
            void DisplayItems()
            {
            }

            void ListAllBadges()
            {
                ColumnNames();
            }
            void ContinueMessage()
            {
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
            void InvalidSelection()
            {
                Console.WriteLine("Invalid selection");
                ContinueMessage();
            }
            void ColumnNames()
            {
                Console.WriteLine($"\n\nKey");
                Console.WriteLine($"\n\nBadge # \t\tDoor Access");
            }
            void AddDoors()
            {
                
            }
        }

    }
}
