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
        readonly KomodoClaimsDepartment_Repository _claim = new KomodoClaimsDepartment_Repository();  
        
        public void Run()
        {
            SeedContent();
            Menu();
        }

        public void SeedContent()
        {
            Claim one = new Claim(1, ClaimType.Car, "Car accident on 465", 400, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));

            Claim two = new Claim(2, ClaimType.Home, "House fire in kitchen.", 4000, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12));

            Claim three = new Claim(3, ClaimType.Theft, "Car accident on 465", 400, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1));

            _claim.AddClaim(one);
            _claim.AddClaim(two);
            _claim.AddClaim(three);
        }

        public void Menu()
        {
            SeedContent();
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("Komodo Claims Menu\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter new claim\n" +
                    "4. Exit Program\n");
                string menuSelection = Console.ReadLine();

                switch (menuSelection)
                {
                    case "1":
                        SeeAllClaims();
                        break;

                    case "2":
                        NextClaim();
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
                        Console.WriteLine("Invalid selection");
                        ContinueMessage();
                        break;


                }
            }
            void EnterNewClaim()
            {
                Console.Clear();

                Claim newClaim = new Claim();

                Console.WriteLine("What is claim type \n1 = Car \n2 = Home \n3 = Theft");
                string claimType = Console.ReadLine();
                while (claimType != "1" && claimType != "2" && claimType != "3")
                {
                    InvalidSelection();
                    Console.WriteLine("What is claim type \n1 = Car \n2 = Home \n3 = Theft");
                    claimType = Console.ReadLine();
                }
                int claimsType = int.Parse(claimType);
                newClaim.ClaimType = (ClaimType)claimsType;
                Console.Clear();

                Console.WriteLine("What is the description");
                newClaim.Description = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("What is claim amount");
                newClaim.ClaimAmount = Convert.ToDouble(Console.ReadLine());
                Console.Clear();

                Console.WriteLine("What is date of incident");
                newClaim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());
                Console.Clear();

                Console.WriteLine("What is date of claim");
                newClaim.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

                _claim.AddClaim(newClaim);

            }
            void NextClaim()
            {
                Console.Clear();   
                Console.WriteLine();
                ContinueMessage();
            }           
                       
            void DisplayItems()
            {
                Queue<Claim> claims = _claim.GetAllClaims();
                foreach (Claim _claim in claims)
                {
                    string incidentDate = _claim.DateOfIncident.ToString("MM/dd/yy");
                    string claimDate = _claim.DateOfClaim.ToString("MM/dd/yy");
                    IsItValid(_claim);
                    ClaimIdNumber();
                    Console.WriteLine($"{_claim.ClaimID} \t{_claim.ClaimType} \t{_claim.Description} \t\t${_claim.ClaimAmount} \t\t{incidentDate} \t\t{claimDate} \t\t{_claim.IsValid}");
                }
            }

            void SeeAllClaims()
            {
                Claim claim = new Claim();
                Console.Clear();                
                ColumnNames();                               
                DisplayItems();
                Console.WriteLine();     
            }
            void ContinueMessage()
            {
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
            void ColumnNames()
            {
                Console.WriteLine($"\n\nClaimID \tType \t\tDescription \tAmount \t\tDateOfAccident \t\tDateOfClaim \t\tIsValid");
            }
            void InvalidSelection()
            {
                Console.WriteLine("Invalid selection");
                ContinueMessage();
            }
            void IsItValid(Claim claim)
            {
                double day = (claim.DateOfClaim - claim.DateOfIncident).TotalDays;
                if (day > 30)
                {
                    claim.IsValid = false;
                }
                else
                {
                    claim.IsValid = true;
                }
            }
            void ClaimIdNumber()
            {
               
            }
        }

    }
}
