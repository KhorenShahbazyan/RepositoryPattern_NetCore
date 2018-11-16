using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Core
{
    public class CustomerRepository : Repository<Customer> 
    {
        public CustomerRepository(TestDbContext context) 
            : base(context)
        {
        }

        public TestDbContext TestDbContext
        {
            get { return Context as TestDbContext; }
        }
    }
}
