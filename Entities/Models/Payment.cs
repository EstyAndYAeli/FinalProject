using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Payment
    {
        public Payment()
        {
            ParkingHistory = new HashSet<ParkingHistory>();
        }

        public int PaymentId { get; set; }
        public double Amount { get; set; }

        public virtual ICollection<ParkingHistory> ParkingHistory { get; set; }
    }
}
