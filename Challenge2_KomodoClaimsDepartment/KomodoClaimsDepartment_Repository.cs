using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2_KomodoClaimsDepartment
{
    class KomodoClaimsDepartment_Repository
    {
        readonly Queue<Claim> _claim = new Queue<Claim>();
        // C           
        public void AddClaim(Claim claim)
        {
            _claim.Enqueue(claim);
        }
        // R
        public Queue<Claim> GetAllClaims()
        {
            return _claim;
        }
        // U

        // D
        public bool RemoveClaim(string claimID)
        {
            Claim claimsID = GetClaimByClaimID(claimID);
            if (claimID == null)
            {
                return false;
            }
            else
            {
                _claim.Dequeue();
                return false;
            }
        }

        public Claim GetClaimByClaimID(string claimsID)
        {
            foreach (Claim claimID in _claim)
            {
                if (claimID.ClaimID == claimsID)
                {
                    return claimID;
                }
            }
            return null;
        }

    }
}
