using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Core;

namespace Test.Web.Api
{
    public class DbInitializer
    {
        private TestDbContext _context;

        public DbInitializer(TestDbContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            if (!_context.Category.Any())
            {
                _context.AddRange(_Category);
                await _context.SaveChangesAsync();
            }

            if (!_context.Customer.Any())
            {
                _context.Customer.AddRange(_Customer);
                await _context.SaveChangesAsync();
            }

            if (!_context.Product.Any())
            {
                _context.Product.AddRange(_Product);
                await _context.SaveChangesAsync();
            }
        }

        List<Category> _Category = new List<Category>
        {
            new Category()
            {
                Name = "Organic",                
            },
            new Category()
            {
                Name = "Meat",
            },
            new Category()
            {
                Name = "Fish and Seafood",
            },
            new Category()
            {
                Name = "Frozen",
            },
            new Category()
            {
                Name = "Sweets",
            }
        };

        List<Product> _Product = new List<Product>
        {
            new Product()
            {
                CategoryId = 1,
                Name = "Product 1",
                Description = "Description 1.1",
                Price = 1000
            },
            new Product()
            {
                CategoryId = 1,
                Name = "Product 1.1",
                Description = "Description 1.2",
                Price = 1200
            },
            new Product()
            {
                CategoryId = 2,
                Name = "Product 2",
                Description = "Description 2.1",
                Price = 25000
            },
            new Product()
            {
                CategoryId = 2,
                Name = "Product 2.1",
                Description = "Description 2.2",
                Price = 12000
            },
            new Product()
            {
                CategoryId = 2,
                Name = "Product 2.2",
                Description = "Description 2.3",
                Price = 1000
            },
            new Product()
            {
                CategoryId = 3,
                Name = "Product 3.1",
                Description = "Description 3.1",
                Price = 31000
            },
            new Product()
            {
                CategoryId = 3,
                Name = "Product 3.2",
                Description = "Description 3.21",
                Price = 231000
            },
            new Product()
            {
                CategoryId = 4,
                Name = "Product 4.1",
                Description = "Description 4.1",
                Price = 14000
            },
            new Product()
            {
                CategoryId = 5,
                Name = "Product 5.1",
                Description = "Description 5.1",
                Price = 51000
            }

        };

        List<Customer> _Customer = new List<Customer>
        {
            new Customer()
            {
                Name = "Customer-1",
            }
        };
    }


}
