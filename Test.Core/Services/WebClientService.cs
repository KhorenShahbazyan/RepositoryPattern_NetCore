using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Core.Domein;

namespace Test.Core
{
    public class WebClientService : IWebClientService
    {
        private readonly IDataAccess _dataAccess;
        private readonly int _customerId = 1;
        public WebClientService(TestDbContext context) 
        {
           //_dataAccess = dataAccess;
           _dataAccess = new DataAccess(context);
        }

        public IEnumerable<CategoryModel> GetCategories()
        {
            var categories = _dataAccess.Categories.GetAll();
            List<CategoryModel> result = new List<CategoryModel>();
            if (categories != null)
            {
                foreach (Category category in categories)
                {
                    result.Add(new CategoryModel { Id = category.Id, Name = category.Name });
                }
            }
            
            return result;
        }

        public IEnumerable<ProductModel> GetProductsByCategory(long categoryId)
        {
            List<ProductModel> result = new List<ProductModel>();
            var products = categoryId > 0 ? _dataAccess.Products.GetProductsByCategory(categoryId) : _dataAccess.Products.GetAll();

            foreach(Product product in products)
            {
                result.Add(new ProductModel
                {
                    Id = product.Id,
                    Description = product.Description,
                    Name = product.Name,
                    Price = product.Price,
                    Url = product.Url
                });
            }

            return result;           

        }

        public long AddOrder(IEnumerable<ProductOrderModel> selectedproducts)
        {
           
            if (selectedproducts == null || !selectedproducts.GetEnumerator().MoveNext()) return 0;
            try
            {
                var order = new Order { CustomerId = _customerId, OrderDate = DateTime.Now };
                _dataAccess.Orders.Add(order);
                _dataAccess.Complete();
                var orderId = order.Id;

                List<ProductOrder> productorders = new List<ProductOrder>();
                foreach (ProductOrderModel product in selectedproducts)
                {
                    productorders.Add(new ProductOrder { OrderId = orderId, ProductId = product.ProductId, Count = product.OrderCount });
                }
                _dataAccess.ProductOrders.AddRange(productorders);
                _dataAccess.Complete();

                return orderId;
            }
            catch
            {
                return 0;
            }
        }


        public IEnumerable<ShoppingModel> GetOrderedProducts()
        {
            var _unpayedOrders = _dataAccess.Orders.Find(o => o.PaymentId == null);
            var _productOrders = _dataAccess.ProductOrders.GetAll().ToList();
            var _products = _dataAccess.Products.GetAll().ToList();

 
            //test
            var r = from product in _products
                    join order in _productOrders on product.Id equals order.ProductId
                    where product.Id == 1
                          & order.Id == _productOrders.Where(x => x.ProductId == 1).Select(x => x.Id).Min()
                    select new Product()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        ProductOrder = new List<ProductOrder> { order }
                    };
            //test end

            var result =
                from order in _unpayedOrders
                join productOrder in _productOrders on order.Id equals productOrder.OrderId
                join product in _products on productOrder.ProductId equals product.Id
                where order.CustomerId == _customerId
                select new ShoppingModel
                {
                    OrderId = order.Id,
                    ProductOrederId = productOrder.Id,
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Count = productOrder.Count,
                    Price = productOrder.Count * product.Price
                };
            return result;
        }

        public IEnumerable<ShoppingModel> GetOrderedProducts(long orderId)
        {
            var _orders = _dataAccess.Orders.GetAll();
            var _productOrders = _dataAccess.ProductOrders.GetAll().ToList();
            var _products = _dataAccess.Products.GetAll().ToList();

            //test
            var r = from product in _products
                    join order in _productOrders on product.Id equals order.ProductId
                    where product.Id == 1
                          & order.Id == _productOrders.Where(x => x.ProductId == 1).Select(x => x.Id).Max()
                    select new Product()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        ProductOrder = new List<ProductOrder> { order }
                    };
            //test end


            var result =
                from order in _orders
                join productOrder in _productOrders on order.Id equals productOrder.OrderId
                join product in _products on productOrder.ProductId equals product.Id
                where order.Id == orderId
                select new ShoppingModel
                {
                    OrderId = order.Id,
                    ProductOrederId = productOrder.Id,
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Count = productOrder.Count,
                    Price = productOrder.Count * product.Price
                };
            return result;
        }

        public decimal? GetOrderTotalPrice(long orderId)
        {
            var _orders = GetOrderedProducts(orderId);
            return _orders.Sum(order => order.Price);
        }

        public bool DeleteProductOreder(int ProductOrederId)
        {
            try
            {
                var _productOrder = _dataAccess.ProductOrders.Get(ProductOrederId);
                _dataAccess.ProductOrders.Remove(_productOrder);
                var _productOrderByOrderId = _dataAccess.ProductOrders.Find(p => p.OrderId == _productOrder.OrderId && p.Id != ProductOrederId);
                if (_productOrderByOrderId != null && _productOrderByOrderId.Count() == 0)
                {
                    var _order = _dataAccess.Orders.Get(_productOrder.OrderId);
                    _dataAccess.Orders.Remove(_order);
                }
                _dataAccess.Complete();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool AddPayment(Payment payment)
        {
            if (payment == null) return false;

            try
            {
                var _payment = new Payment
                {
                    Address = payment.Address,
                    City = payment.City,
                    Country = payment.Country,
                    Email = payment.Email,
                    FirstName = payment.FirstName,
                    LastName = payment.LastName,
                    Phone = payment.Phone,
                    PostalCode = payment.PostalCode,
                    State = payment.State,
                    PaymentDate = DateTime.Now

                };
                _dataAccess.Payments.Add(_payment);
                _dataAccess.Complete();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public void Dispose()
        {
            if(_dataAccess != null)
            {
                _dataAccess.Dispose();
            }
        }

        
    }
}
