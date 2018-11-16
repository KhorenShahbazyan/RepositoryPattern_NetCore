using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Core;
using Test.Core.Domein;
using Test.Web.Api.Controllers;

namespace Test.API.UnitTest
{
    [TestClass]
    public class ProductsUnitTest
    {
        private readonly TestApiController testApi;
        //public ProductsUnitTest()
        //{
        //    testApi = new TestApiController(new WebClientService(new TestDbContext()));
        //}

        [TestMethod]
        public void GetCategories()
        {             
            Assert.IsNotNull(testApi.GetCategories());
        }

        [TestMethod]
        public void GetProducts()
        {
            Assert.IsNotNull(testApi.GetProducts(-1));
        }

        [TestMethod]
        public void GetOrderedProducts()
        {
            List<ShoppingModel> res = new List<ShoppingModel>(testApi.GetOrderedProducts(36));
            Assert.IsNotNull(res != null && res.Count > 0);
        }
    }
}
