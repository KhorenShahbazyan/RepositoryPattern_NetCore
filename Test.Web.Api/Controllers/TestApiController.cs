using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Core;
using Test.Core.Domein;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test.Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class TestApiController : Controller
    {
        private readonly IWebClientService _webClinetService;
        public TestApiController(IWebClientService webClinetService)
        {
            _webClinetService = webClinetService;
        }

        [HttpGet("Categories")]
        public IEnumerable<CategoryModel> GetCategories()
        {
            return _webClinetService.GetCategories();
        }


        [HttpGet("Products")]
        public IEnumerable<ProductModel> GetProducts(long categoryid)
        {
            return _webClinetService.GetProductsByCategory(categoryid);
        }

        [HttpPost("AddOrder")]
        public long AddOrder([FromBody] IEnumerable<ProductOrderModel> order)
        {
           return _webClinetService.AddOrder(order);
        }

        [HttpGet("OrderedProducts")]
        public IEnumerable<ShoppingModel> GetOrderedProducts()
        {
            return _webClinetService.GetOrderedProducts();
        }

        [HttpGet("Orderes")]
        public IEnumerable<ShoppingModel> GetOrderedProducts(long orderId)
        {
            return _webClinetService.GetOrderedProducts(orderId);
        }

        [HttpGet("GetOrderTotalPrice")]
        public decimal? GetOrderTotalPrice(long orderId)
        {
            return _webClinetService.GetOrderTotalPrice(orderId);
        }

        [HttpPost("DeleteProductOreder")]
        public bool DeleteProductOreder(int productOrderId)
        {
           return _webClinetService.DeleteProductOreder(productOrderId);
        }

        [HttpPost("AddPayment")]
        public bool AddPayment(Payment payment)
        {
            return _webClinetService.AddPayment(payment);
        }
    }
}
