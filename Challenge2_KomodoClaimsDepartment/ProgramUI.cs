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
        readonly Queue<Claim> _claim = new Queue<Claim>();
        readonly Claim claims = new Claim();
        public void Run()
        {
            SeedContent();
            Menu();
        }

        public void SeedContent()
        {
            Claim firstItem = new Claim(claims.ClaimID, ClaimType.Car, "Car accident on 465", 400, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), claims.IsValid);

            Claim secondtItem = new Claim(claims.ClaimID, ClaimType.Home, "House fire in kitchen.", 4000, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12), claims.IsValid);

            Claim thirdItem = new Claim(claims.ClaimID, ClaimType.Theft, "Car accident on 465", 400, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1), claims.IsValid);

            _claim.Enqueue(firstItem);
            _claim.Enqueue(secondtItem);
            _claim.Enqueue(thirdItem);
        }

        public void Menu()
        {
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
                

                Console.WriteLine("What is claim type \n1 = Car \n2 = Home \n3 = Theft");
                string claimType = Console.ReadLine();
                while (claimType != "1" && claimType != "2" && claimType != "3")
                {
                    InvalidSelection();
                    Console.WriteLine("What is claim type \n1 = Car \n2 = Home \n3 = Theft");
                    claimType = Console.ReadLine();
                }
                int claimsType = int.Parse(claimType);
                claims.ClaimType = (ClaimType)claimsType;
                Console.Clear();

                Console.WriteLine("What is the description");
                claims.Description = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("What is claim amount");
                claims.ClaimAmount = Convert.ToDouble(Console.ReadLine());
                Console.Clear();

                Console.WriteLine("What is date of incident");                
                claims.DateOfIncident = Convert.ToDateTime(Console.ReadLine());
                Console.Clear();

                Console.WriteLine("What is date of claim");
                claims.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

                _claim.Enqueue(claims);

            }
            void NextClaim()
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
                IsItValid(claim);
                ClaimIdNumber();
                Console.WriteLine($"{claim.ClaimID} \t{claim.ClaimType} \t{claim.Description} \t\t${claim.ClaimAmount} \t\t{incidentDate} \t\t{claimDate} \t\t{claim.IsValid}");
            }

            void SeeAllClaims()
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
               claims.ClaimID = _claim.Count;
            }
        }

    }
}
