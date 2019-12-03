using MVC_MiniProject_lastweek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVC_MiniProject_lastweek.ViewModel;

namespace MVC_MiniProject_lastweek.Controllers
{
    public class CustomerController : Controller
        
    {
        private ApplicationDbContext _dbContext;
        public CustomerController()
        {
            _dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var membership = _dbContext.membershipTypes.ToList();
            var viewmodel = new CustomerViewModel()
            {
                customer = new Customer(),
                MembershipTypes = membership
            };
            return View("Index",viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var viewmodel = new CustomerViewModel
                {
                    customer = customer,
                    MembershipTypes = _dbContext.membershipTypes.ToList(),
                };
                return View("Index", viewmodel);
               
            }
            if (customer.CustomerId == 0)
            {
                _dbContext.Customers.Add(customer);
            }
            else
            {
                var cust = _dbContext.Customers.SingleOrDefault(m => m.CustomerId == customer.CustomerId);
                cust.CustomerName = customer.CustomerName;
                cust.DOB = customer.DOB;
                cust.IsSubsribedToNewsLetter = customer.IsSubsribedToNewsLetter;
                cust.MembershipTypeId = customer.MembershipTypeId;
                
            }
            _dbContext.SaveChanges();
            return RedirectToAction("CustomersList", "Customer");
        }
        
        public ActionResult CustomersList()
        {
            //var cust = _dbContext.Customers.Include(c=>c.MembershipType).ToList();
            return View();
        }
       

        public ActionResult Details(int id)
        {
            var details =_dbContext.Customers.Include(c => c.MembershipType).FirstOrDefault(m => m.CustomerId == id);
            if (details == null)
            {
                return HttpNotFound();
            }
            else
                return View(details);
        }

        public ActionResult Edit(int id)
        {
            var details = _dbContext.Customers.FirstOrDefault(m => m.CustomerId == id);
            if (details == null)
            {
                return HttpNotFound();
            }
            var viewmodel = new CustomerViewModel()
            {
                customer=details,
                MembershipTypes=_dbContext.membershipTypes.ToList(),
            };
            return View("Index",viewmodel);

        }
        
    }
}







//[NonAction]
//public List<Customer> CustomerList()
//{
//    var customers = new List<Customer>
//    {
//        new Customer{CustomerName="Customer1",CustomerId=1},
//        new Customer{CustomerName="Customer2",CustomerId=2},
//        new Customer{CustomerName="Customer3",CustomerId=3},
//        new Customer{CustomerName="Customer4",CustomerId=4},
//        new Customer{CustomerName="Customer5",CustomerId=5},

//    };
//    return customers;
//}