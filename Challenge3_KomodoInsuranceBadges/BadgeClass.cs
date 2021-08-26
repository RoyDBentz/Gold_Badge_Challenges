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
        public List<DoorID> DoorID { get; set; }
        public Badge(string badgeID, List<DoorID> doorID)
        {
            BadgeID = badgeID;
            DoorID = doorID;
        }
    }   
}
public enum DoorID { A1=1, A2, A3, A4, A5, A6, A7, A8, A9, B1, B2, B3, B4, B5, B6, B7, B8, B9 }

