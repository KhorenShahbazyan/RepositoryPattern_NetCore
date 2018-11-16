using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; 
using Test.Web.Api.Controllers;
using Test.Web.Client.Models;

namespace Test.Web.Client.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Store()
        {         
            return View();
        }

        public IActionResult Shopping()
        {
            return View();
        }

        public IActionResult RedirectToShopping(long orderId)
        {
            var model = new RedirectIdModel();
            model.Id = orderId;
            return View("Shopping", model);
           
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Payment()
        {
            return View();
        }

        public IActionResult RedirectToPayment(long orderId)
        {
            var model = new RedirectIdModel();
            model.Id = orderId;
            return View("Payment", model);
        }

        public IActionResult ProductDetail()
        {
            return View();
        }


        public IActionResult Error()
        {
            return View();
        }
    }
}
