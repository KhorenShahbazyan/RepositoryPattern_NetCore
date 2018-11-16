using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Core 
{
    public class ProductOrderRepository : Repository<ProductOrder>
    {
        public ProductOrderRepository(TestDbContext context) 
            : base(context)
        {
        }

        public TestDbContext TestDbContext
        {
            get { return Context as TestDbContext; }
        }
    }
}
