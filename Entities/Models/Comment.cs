using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int CostumerId { get; set; }
        public string Recommendation { get; set; }
        public bool ExposeCostumerName { get; set; }
        public bool ForManager { get; set; }

        public virtual Costumer Costumer { get; set; }
    }
}
