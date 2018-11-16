using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Core
{
    public class PaymentRepository : Repository<Payment>
    {
        public PaymentRepository(TestDbContext context) 
            : base(context)
        {
        }

        public TestDbContext TestDbContext
        {
            get { return Context as TestDbContext; }
        }
    }
}
