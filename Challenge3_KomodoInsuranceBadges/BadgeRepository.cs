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
                return false;
            }
        }
        public bool AddDoorToBadge(string badgeID,string door)
        {
           return _badgeID.Add(badgeID,door);
        }
        // Read
        public Dictionary<string, List<string>> GetBadges()
        {
            return _badgeID;
        }
        // Update
        public bool UpdateBadgeDoorsOnBadge(string badgeNumber)
        {
            GetBadgeListOfDoors(badgeNumber);            
            return _badgeID.Remove(badgeNumber);
            
        }
        // Delete
        public bool DeleteBadges(Badge badge)
        {
            return _badgeID.Remove(badge.BadgeID);
        }

        public List<string> GetBadgeListOfDoors(string badgeNumber)
        {
            foreach(KeyValuePair<string, List<string>> badge in _badgeID)
            {
                if(badgeNumber == badge.Key)
                {
                    return badge.Value;
                }
            }
            return null;
        }
    }
}
