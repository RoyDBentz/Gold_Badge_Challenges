using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_KomodoInsuranceBadges
{
    class BadgeClass
    {
        public string BadgeID { get; set; }
        public string ADoors { get; set; }
        public string BDoors { get; set; }

        public BadgeClass(string badgeID, string aDoors, string bDoors)
        {
            BadgeID = badgeID;
            ADoors = aDoors;
            BDoors = bDoors;
        }
    }   
}
public enum ADoors { A1=1, A2, A3, A4, A5, A6, A7, A8, A9}
public enum BDoors { B1=1, B2, B3, B4, B5, B6, B7, B8, B9}
