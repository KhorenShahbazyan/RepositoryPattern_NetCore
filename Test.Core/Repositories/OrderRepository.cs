using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Core
{
    public class OrderRepository : Repository<Order>
    {
        public OrderRepository(TestDbContext context) 
            : base(context)
        {
        }

        public TestDbContext TestDbContext
        {
            get { return Context as TestDbContext; }
        }
        
    }
}
