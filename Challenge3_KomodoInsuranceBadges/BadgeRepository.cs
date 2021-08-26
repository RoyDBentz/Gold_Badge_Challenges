using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_KomodoInsuranceBadges
{
    class BadgeRepository
    {
        readonly Dictionary<string, List<string>> _badgeID = new Dictionary<string, List<string>>();

        // Create
        public bool NewBadgeNumber(string badgeNumber)
        {
            if (!_badgeID.ContainsKey(badgeNumber))
            {
                _badgeID.Add(badgeNumber, new List<string>());
                return true;
            }
            else
            {
                _badgeID[badgeNumber] = new List<string>();
                return false;
            }
        }
        // Read
        public Dictionary<string, List<string>> GetBadges()
        {
            return _badgeID;
        }
        // Update
        public bool UpdateBadge()
        {

        }
        // Delete
        public bool DeleteBadges(Badge badge)
        {
            _badgeID.Remove(Badge);
        }

        public void GetBadgeValue<T>(string badgeNumber)
        {
            string door;
            T retType;

            _badgeID.TryGetValue(badgeNumber, out door);
            try
            {
                retType = (T)badgeNumber;
            }

        }
    }
}
