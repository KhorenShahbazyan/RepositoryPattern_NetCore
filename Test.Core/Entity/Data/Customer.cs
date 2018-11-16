using System;
using System.Collections.Generic;

namespace Test.Core
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? AccountId { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
