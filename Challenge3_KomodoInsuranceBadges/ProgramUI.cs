using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2_KomodoClaimsDepartment
{
    class ProgramUI
    {        
        readonly Dictionary<Cl _claim = new Queue<Claim>();
        public void Run()
        {
            SeedContent();
            Menu();
        }

        public void SeedContent()
        {
            Claim firstItem = new Claim("1", "Car", "Car accident on 465", 400, new DateTime(2018, 4, 25) , new DateTime(2018, 4, 27), true);

            Claim secondtItem = new Claim("2", "Home", "House fire in kitchen.", 4000, new DateTime (2018,4,11), new DateTime (2018, 4, 12), true);

            Claim thirdItem = new Claim("3", "Car", "Car accident on 465", 400, new DateTime (2018, 4, 27), new DateTime(2018, 6, 1), false);

            _claim.Enqueue(firstItem);
            _claim.Enqueue(secondtItem);
            _claim.Enqueue(thirdItem);
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
                        Console.WriteLine("Invalid selection");
                        ContinueMessage();
                        break;


                }
            }
            void AddABadge()
            {
                Console.Clear();
                Claim claim = new Claim();
                Console.WriteLine("What is new claim ID");
                claim.ClaimID = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("What is claim type \n1 = Car \n2 = Home \n3 = Theft");
                
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
            void EditABadge()
            {
                Console.Clear();
                Queue<Claim> claims = new Queue<Claim>();                

                Console.WriteLine(claims.Peek());
                ContinueMessage();
            }           
                       
            void DisplayItems(Claim claim)
            {
                string incidentDate = claim.DateOfIncident.ToString("MM/dd/yy");                 
                string claimDate = claim.DateOfClaim.ToString("MM/dd/yy");                 
                Console.WriteLine($"{claim.ClaimID} \t{claim.ClaimType} \t{claim.Description} \t\t${claim.ClaimAmount} \t\t{incidentDate} \t\t{claimDate}");
            }

            void ListAllBadges()
            {
                Console.Clear();                
                ColumnNames();
                foreach (Claim claim in _claim)
                {
                    DisplayItems(claim);
                    Console.WriteLine();
                }
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
        }

    }
}
