using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Rate
    {
        public int RateId { get; set; }
        public decimal PayPerHour { get; set; }
        public TimeSpan BeginsAt { get; set; }
        public TimeSpan EndsAt { get; set; }
        public int ParkingId { get; set; }

        public virtual ParkingLot Parking { get; set; }
    }
}
