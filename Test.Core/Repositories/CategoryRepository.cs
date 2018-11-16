using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Core
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(TestDbContext context) 
            : base(context)
        {
        }

        public TestDbContext TestDbContext
        {
            get { return Context as TestDbContext; }
        }
    }
}
