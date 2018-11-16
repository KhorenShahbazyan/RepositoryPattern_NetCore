using System;
using System.Collections.Generic;
using System.Text;
using Test.Core.Domein;

namespace Test.Core
{
    public interface IWebClientService : IDisposable
    {
        IEnumerable<CategoryModel> GetCategories();
        IEnumerable<ProductModel> GetProductsByCategory(long categoryId);
        long AddOrder(IEnumerable<ProductOrderModel> selectedproducts);
        IEnumerable<ShoppingModel> GetOrderedProducts();
        IEnumerable<ShoppingModel> GetOrderedProducts(long orderId);
        decimal? GetOrderTotalPrice(long orderId);
        bool DeleteProductOreder(int ProductOrederId);
        bool AddPayment(Payment payment);
    }
}
