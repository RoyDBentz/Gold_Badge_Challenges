using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_KomodoInsuranceBadges
{
    class BadgeRepository
    {
        readonly Dictionary<string, string> _badgeID = new Dictionary<string, string>();

        // Create
        public void NewBadgeNumber(Badge badge)
        {
            _badgeID.Add(badge.BadgeID, badge.Door);
        }
        // Read
        public void ReadBadges(Badge badge)
        {
            return ToString._badgeID[badge];
        }
        // Update
        public void UpdateBadges(Badge badge)
        {

        }
        // Delete
        public bool DeleteBadges(Badge badge)
        {
            _badgeID.Remove(Badge);
        }
    }
}
