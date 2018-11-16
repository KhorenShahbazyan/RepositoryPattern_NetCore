using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Core
{
    public class DataAccess : IDataAccess
    {
        private readonly TestDbContext _context;

        public DataAccess(TestDbContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
            Categories = new CategoryRepository(_context);
            Products = new ProductRepository(_context);
            Orders = new OrderRepository(_context);
            ProductOrders = new ProductOrderRepository(_context);
            Payments = new PaymentRepository(_context);
        }

        public CustomerRepository Customers { get; private set; }
        public CategoryRepository Categories { get; private set; }
        public IProductRepository Products { get; private set; }
        public OrderRepository Orders { get; private set; }
        public PaymentRepository Payments { get; private set; }
        public ProductOrderRepository ProductOrders { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
