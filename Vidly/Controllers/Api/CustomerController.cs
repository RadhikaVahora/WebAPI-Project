using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Vidly.Models;


namespace Vidly.Controllers.Api
{
    public class CustomerController : ApiController
    {
        private DbEntities Db = new DbEntities();
        //GET /api/Customers
        
        public IHttpActionResult GetCustomers()
        {
           var CustomerList = Db.Customer.ToList();
            return Ok(CustomerList);
        }

        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = Db.Customer.SingleOrDefault(c => c.CustomerId == id);
            if (customer == null)
                NotFound();
            return Ok(customer);
        }
        [HttpPost]
        public IHttpActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid) { 
                BadRequest();
            }
            Db.Customer.Add(customer);
            Db.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + customer.CustomerId), customer);
        }
        [HttpPut]
        public void Edit(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            int id = customer.CustomerId;
            var CusObj = Db.Customer.SingleOrDefault(c => c.CustomerId == id);
            if(customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            CusObj.Name = customer.Name;
            CusObj.Address = customer.Address;
            Db.SaveChanges();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var CusObj = Db.Customer.SingleOrDefault(c => c.CustomerId == id);
            if (CusObj == null)
                NotFound();
            Db.Customer.Remove(CusObj);
            Db.SaveChanges();
            return Ok();

        }
    }
}
