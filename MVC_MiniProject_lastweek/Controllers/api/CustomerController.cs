using AutoMapper;
using MVC_MiniProject_lastweek.dtos;
using MVC_MiniProject_lastweek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace MVC_MiniProject_lastweek.Controllers.api
{
    public class CustomerController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.Include(m=>m.MembershipType).ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }

        //get/api/customer/id
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(m => m.CustomerId == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //post
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerdto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var cust = Mapper.Map<CustomerDto, Customer>(customerdto);
            _context.Customers.Add(cust);
            _context.SaveChanges();
            customerdto.CustomerId = cust.CustomerId;
            return Created(new Uri(Request.RequestUri + "/" + cust.CustomerId), customerdto);
        }
        [HttpPut]
        public void UpateCustomer(int id,CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var CustInDb = _context.Customers.SingleOrDefault(c => c.CustomerId ==id);
            if(CustInDb==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            //CustInDb.CustomerName = customer.CustomerName;
            //CustInDb.DOB = customer.DOB;
            //CustInDb.IsSubsribedToNewsLetter = customer.IsSubsribedToNewsLetter;
            //CustInDb.MembershipTypeId = customer.MembershipTypeId;

            Mapper.Map(customerdto, CustInDb);
           
            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(m => m.CustomerId == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
