using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Core
{
    public interface IDataAccess : IDisposable
    {
        CustomerRepository Customers { get; }
        CategoryRepository Categories { get; }
        OrderRepository Orders { get; }
        ProductOrderRepository ProductOrders { get; }
        IProductRepository Products { get; }
        PaymentRepository Payments { get; }
        int Complete();
    }
     
}
