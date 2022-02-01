using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Car
    {
        public Car()
        {
            ParkingHistory = new HashSet<ParkingHistory>();
        }

        public string NumberLicensePlate { get; set; }
        public bool CarType { get; set; }
        public int CostumerId { get; set; }

        public virtual Costumer Costumer { get; set; }
        public virtual ICollection<ParkingHistory> ParkingHistory { get; set; }
    }
}
