using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Costumer
    {
        public Costumer()
        {
            Car = new HashSet<Car>();
            Comment = new HashSet<Comment>();
            CreditDetails = new HashSet<CreditDetails>();
        }

        public int CostumerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Car> Car { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<CreditDetails> CreditDetails { get; set; }
    }
}
