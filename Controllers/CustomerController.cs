using Activity3Part1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity3Part1.Controllers
{
    public class CustomerController : Controller
    {
        public List<CustomerModel> customer;

        // GET: Customer
        public ActionResult Index()
        {
            Tuple<List<CustomerModel>, CustomerModel> customerTuple;
            customerTuple = new Tuple<List<CustomerModel>, CustomerModel>(customer, customer[0]);
            return View("Customer", customerTuple);
        }

        [HttpPost]
        public ActionResult OnSelectCustomer(string _customer)
        {
            int selection = Int32.Parse(_customer);
            Tuple<List<CustomerModel>, CustomerModel> customerTuple;
            customerTuple = new Tuple<List<CustomerModel>, CustomerModel>(customer, customer[selection - 1]);
            return PartialView("_CustomerDetails", customerTuple);
        }

        [HttpPost]
        public ActionResult CustomerTest(string _customer)
        {
            return PartialView("_CustomerDetails", customer[Int32.Parse(_customer) - 1]);
        }

        [HttpPost]
        public String GetMoreInfo(string customerID)
        {
            return "TestReturn";
        }

        public CustomerController()
        {
            customer = new List<CustomerModel>();
            customer.Add(new CustomerModel(1, "John Doe", 25));
            customer.Add(new CustomerModel(2, "Jane Doe", 30));
            customer.Add(new CustomerModel(3, "Vito Corleone", 35));
            customer.Add(new CustomerModel(4, "Forrest Gump", 40));
            customer.Add(new CustomerModel(5, "Sarah Connor", 45));
        }
    }
}