using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer {Name="Jamal" },
                new Customer {Name="Bilal" }
            };
            var viewModel = new IndexCustomerViewModel
            {
                Customers = customers
            };
            return View(viewModel);
        }
    }
}