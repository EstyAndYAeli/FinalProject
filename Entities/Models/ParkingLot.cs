using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class ParkingLot
    {
        public ParkingLot()
        {
            ParkingHistory = new HashSet<ParkingHistory>();
            Rate = new HashSet<Rate>();
        }

        public int ParkingId { get; set; }
        public string Adress { get; set; }
        public int NumOfRegular { get; set; }
        public int NumOfDisabled { get; set; }
        public int ManagerId { get; set; }
        public string Name { get; set; }

        public virtual ParkingManager Manager { get; set; }
        public virtual ICollection<ParkingHistory> ParkingHistory { get; set; }
        public virtual ICollection<Rate> Rate { get; set; }
    }
}
