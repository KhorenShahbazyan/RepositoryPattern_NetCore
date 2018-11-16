using System;
using System.Collections.Generic;
using System.Text;


namespace Test.Core
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetProductsByCategory(long catId);
    }
}
