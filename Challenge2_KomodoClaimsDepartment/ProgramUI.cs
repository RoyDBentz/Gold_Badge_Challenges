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
            Claim firstItem = new Claim("1", "Car", "Car accident on 465", 400, Convert.ToDateTime(4/25/18) , Convert.ToDateTime(4 / 27 / 18), true );

            Claim secondtItem = new Claim("2", "Home", "House fire in kitchen.", 4000, Convert.ToDateTime(4 / 11 / 18), Convert.ToDateTime(4 / 12 / 18), true);

            Claim thirdItem = new Claim("1", "Car", "Car accident on 465", 400, Convert.ToDateTime(4 / 27 / 18), Convert.ToDateTime(6/1/18), false);

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
                Claim claim = new Claim();
                Console.WriteLine("What is new claim ID");
                claim.ClaimID = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("What is claim type 'Car, Home, Theft'");
                claim.ClaimType = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("What is the description");
                claim.Description = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("What is claim amount");
                claim.ClaimAmount = Convert.ToDouble(Console.ReadLine());
                Console.Clear();

                Console.WriteLine("What is date of incident");                
                claim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());
                Console.Clear();

                Console.WriteLine("What is date of claim");
                claim.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

                _claim.Enqueue(claim);

            }
            void TakeCareOfNextClaim()
            {
                Console.Clear();
                SeeAllClaims();
                Console.WriteLine("Enter meal name of meal you would like to remove:");
                string name = Console.ReadLine();
                Claim claim = _claim.GetClaimByClaimID();
                if (claim == null)
                {
                    Console.WriteLine("Item name not found.");
                }
                else
                {
                    DisplayItems(claim);
                    Console.WriteLine("Are you sure you want to delete item? 1 = Yes, 2 = No");
                    string answer = Console.ReadLine();
                    while (answer != "1" || answer != "2")
                    {
                        if (answer == "1")
                        {
                            _claim.Dequeue();
                            break;
                        }
                        else if (answer == "2")
                        {
                            Console.WriteLine("You chose not to delete the claim.");                            
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
            void DisplayItems(Claim claim)
            {
                Console.WriteLine($"#{claim.ClaimID} -{claim.ClaimType}- \nDescription: {claim.Description} \nIngredients: {claim.ClaimAmount} \nCalories: {claim.DateOfIncident} \nPrice: {claim.DateOfClaim}");
            }

            void SeeAllClaims()
            {
                Console.Clear();
                Queue<Claim> claims = new Queue<Claim>();
                foreach (Claim claim in _claim)
                {
                    DisplayItems(claim);
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
