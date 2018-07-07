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
        [Route("customers/Detail/{Id}")]
        public ActionResult Detail(int Id)
        {
            var customers = new List<Customer>
            {
                new Customer {Name="Jamal" ,Id=1},
                new Customer {Name="Bilal" ,Id=2}
            };
            foreach(var cust in customers)
            {
                if (cust.Id == Id)
                {              
                    return View(cust);
                }
            }
            return HttpNotFound();
        }
    }
}