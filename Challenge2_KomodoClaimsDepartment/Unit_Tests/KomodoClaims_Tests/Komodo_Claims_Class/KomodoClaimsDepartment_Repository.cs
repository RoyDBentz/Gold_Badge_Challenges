using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Tests
{
    class KomodoClaimsDepartment_Repository
    {
        private readonly Queue<Claim> _claim = new Queue<Claim>();
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

        public Claim GetNextClaim()
        {
            return _claim.Peek();
        }
        // U - unneeded at present time

        // D
        public bool RemoveClaim()
        {            
            if (_claim == null)
            {
                return false;
            }
            else
            {
                _claim.Dequeue();
                return true;
            }
        }
    }
}
