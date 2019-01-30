using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class ProductController : ApiController
    {
        private DbEntities Db = new DbEntities();
        
        //GET /api/Products  
        public IHttpActionResult GetProducts()
        {
            var ProductList = Db.Product.ToList();
            return Ok(ProductList);
        }
        [HttpGet]
        public IHttpActionResult GetProduct(int id)
        {
            var product = Db.Product.SingleOrDefault(c => c.ProductId == id);
            if (product == null)
                NotFound();
            return Ok(product);
        }
        [HttpPost]
        public IHttpActionResult Create(Product product)
        {
            if (!ModelState.IsValid) { 
                BadRequest();
            }
            Db.Product.Add(product);
            Db.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + product.ProductId), product);
        }
        [HttpPut]
        public void Edit(Product product)
        {
            int id = product.ProductId;
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var PdtObj = Db.Product.SingleOrDefault(c => c.ProductId == id);
            if(product == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            PdtObj.Name = product.Name;
            PdtObj.Price = product.Price;
            Db.SaveChanges();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var PdtObj = Db.Product.SingleOrDefault(c => c.ProductId == id);
            if (PdtObj == null)
                NotFound();
            Db.Product.Remove(PdtObj);
            Db.SaveChanges();
            return Ok();

        }
    }
}
