using System;
using System.Collections.Generic;

namespace Test.Core
{
    public partial class Order
    {
        public Order()
        {
            ProductOrder = new HashSet<ProductOrder>();
        }

        public long Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public long? PaymentId { get; set; }

        public virtual ICollection<ProductOrder> ProductOrder { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
