using System;
using System.Collections.Generic;

namespace Test.Core
{
    public partial class Product
    {
        public Product()
        {
            ProductOrder = new HashSet<ProductOrder>();
        }

        public long Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<ProductOrder> ProductOrder { get; set; }
        public virtual Category Category { get; set; }
    }
}
