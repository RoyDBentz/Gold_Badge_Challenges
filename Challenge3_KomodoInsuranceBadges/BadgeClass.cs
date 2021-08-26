using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_KomodoInsuranceBadges
{
    public class Badge
    {
        public string BadgeID { get; set; }
        public List<string> DoorID { get; set; }
        public Badge(string badgeID, List<string> doorID)
        {
            BadgeID = badgeID;
            DoorID = doorID;
        }
    }   
}


