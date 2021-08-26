using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoClaims_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddClaimTest1()
        {
            KomodoClaimsDepartment_Repository _claim = new KomodoClaimsDepartment_Repository();
            Claim one = new Claim("1", "Car", "Car accident on 465", 400, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            _claim.AddClaim(one);                       
        }
        public void ClaimAdded()
        {
            KomodoClaimsDepartment_Repository _claim = new KomodoClaimsDepartment_Repository();
            _claim.Equals(("1", "Car", "Car accident on 465", 400, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27)));
        }

        [TestMethod]
        public void ReadClaim1()
        {
            KomodoClaimsDepartment_Repository _claim = new KomodoClaimsDepartment_Repository();
            Claim one = new Claim("1", "Car", "Car accident on 465", 400, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            _claim.AddClaim(one);
        }
        public void ClaimPeek()
        {
            KomodoClaimsDepartment_Repository _claim = new KomodoClaimsDepartment_Repository();
            _claim.GetNextClaim();
            //Assert assert = ("1", "Car", "Car accident on 465", 400, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
        }
    }
}
