using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.Core
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(TestDbContext context) 
            : base(context)
        {
        }

        public IEnumerable<Product> GetProductsByCategory(long catId)
        {
            return TestDbContext.Product.Where(p => p.CategoryId == catId).ToList();
        }

        public TestDbContext TestDbContext
        {
            get { return Context as TestDbContext; }
        }

        
    }
}
