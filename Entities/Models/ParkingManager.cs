using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class ParkingManager
    {
        public ParkingManager()
        {
            ParkingLot = new HashSet<ParkingLot>();
        }

        public int ManagerId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<ParkingLot> ParkingLot { get; set; }
    }
}
