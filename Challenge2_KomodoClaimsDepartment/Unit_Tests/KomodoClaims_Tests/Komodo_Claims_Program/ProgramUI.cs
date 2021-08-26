using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Tests
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
            Claim one = new Claim("1", "Car", "Car accident on 465", 400, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));

            Claim two = new Claim("2", "Home", "House fire in kitchen.", 4000, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12));

            Claim three = new Claim("3", "Theft", "Car accident on 465", 400, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1));

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
                        InvalidSelection();
                        break;


                }
            }
            void EnterNewClaim()
            {
                Console.Clear();

                Claim newClaim = new Claim();

                Console.Write("Enter the claim id: ");
                newClaim.ClaimID = Console.ReadLine();


                Console.Write("Enter the claim type: ");
                newClaim.ClaimType = Console.ReadLine();                
                

                Console.Write("Enter a claim description: ");
                newClaim.Description = Console.ReadLine();
                

                Console.Write("Amount of Damage: $");
                newClaim.ClaimAmount = Convert.ToDouble(Console.ReadLine());
                

                Console.Write("Date Of Accident: ");
                newClaim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());
                

                Console.Write("Date of claim: ");
                newClaim.DateOfClaim = Convert.ToDateTime(Console.ReadLine());
                
                double day = (newClaim.DateOfClaim - newClaim.DateOfIncident).TotalDays;
                if (day > 30)
                {
                    Console.WriteLine("This claim is not valid.");                                     
                }
                else
                {
                    Console.WriteLine("This claim is valid.");                    
                }
                _claim.AddClaim(newClaim);
                ContinueMessage();

                

            }
            void NextClaim()
            {
                var claims = _claim.GetNextClaim();                
                Console.Clear();
                string incidentDate = claims.DateOfIncident.ToString("MM/dd/yy");
                string claimDate = claims.DateOfClaim.ToString("MM/dd/yy");
                Console.WriteLine("Here are the details for the next claim to be handled:\n");
                Console.WriteLine($"ClaimID: {claims.ClaimID}");
                Console.WriteLine($"Claim Type: {claims.ClaimType}");
                Console.WriteLine($"Claim Description: {claims.Description}");
                Console.WriteLine($"Claim Amount: {claims.ClaimAmount}");
                Console.WriteLine($"DateOfAccident: {incidentDate}");
                Console.WriteLine($"DateOfClaim: {claimDate}");
                Console.WriteLine($"IsValid: {claims.IsValid}");
                Console.Write("Do you want to deal with this claim now(y/n)?");
                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    _claim.RemoveClaim();
                    Console.WriteLine("\nYou have chosen y and will be reurned to main menu.");
                    ContinueMessage();
                }
                else
                {
                    Console.WriteLine("\nYou chose n and will be returned to main menu.");
                    ContinueMessage();
                }               
            }           
                       
            void DisplayItems()
            {
                Queue<Claim> claims = _claim.GetAllClaims();
                foreach (Claim _claim in claims)
                {
                    string incidentDate = _claim.DateOfIncident.ToString("MM/dd/yy");
                    string claimDate = _claim.DateOfClaim.ToString("MM/dd/yy");
                    IsItValid(_claim);
                    _claim.ClaimID = claims.Count.ToString();
                    Console.WriteLine($"{_claim.ClaimID} \t{_claim.ClaimType} \t{_claim.Description} \t\t${_claim.ClaimAmount} \t\t{incidentDate} \t\t{claimDate} \t\t{_claim.IsValid}");
                }
            }

            void SeeAllClaims()
            {
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
        }

    }
}
