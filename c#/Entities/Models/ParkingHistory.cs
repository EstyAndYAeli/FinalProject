using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class ParkingHistory
    {
        public int ParkingLotId { get; set; }
        public string NumberLicensePlate { get; set; }
        public DateTime DateEntryParking { get; set; }
        public DateTime? DateExitParking { get; set; }
        public int ParkingId { get; set; }
        public bool? IsEntry { get; set; }
        public int PaymentId { get; set; }

        public virtual Car NumberLicensePlateNavigation { get; set; }
        public virtual ParkingLot Parking { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
