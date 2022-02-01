using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class CreditDetails
    {
        public int CreditId { get; set; }
        public string FrontDigits { get; set; }
        public string ExpiryDate { get; set; }
        public string BackDigits { get; set; }
        public int CostumerId { get; set; }

        public virtual Costumer Costumer { get; set; }
    }
}
