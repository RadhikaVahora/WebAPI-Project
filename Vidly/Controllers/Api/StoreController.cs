using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class StoreController : ApiController
    {
        private DbEntities Db = new DbEntities();

        //GET /api/Store
        public IHttpActionResult GetStore()
        {
            
            var StoreList = Db.Store.ToList();
            return Ok(StoreList);
        }
        [HttpGet]
        public IHttpActionResult GetStore(int id)
        {
            var store = Db.Store.SingleOrDefault(c => c.StoreId == id);
            if (store == null)
                NotFound();
            return Ok(store);
        }
        [HttpPost]
        public IHttpActionResult Create(Store store)
        {
            if (!ModelState.IsValid) { 
                BadRequest();
            }
            Db.Store.Add(store);
            Db.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + store.StoreId), store);
        }
        [HttpPut]
        public void Edit(Store store)
        {
            int id = store.StoreId;
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var StrObj = Db.Store.SingleOrDefault(c => c.StoreId == id);
            if(store == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            StrObj.Name = store.Name;
            StrObj.Address = store.Address;
            Db.SaveChanges();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var StrObj = Db.Store.SingleOrDefault(c => c.StoreId == id);
            if (StrObj == null)
                NotFound();
            Db.Store.Remove(StrObj);
            Db.SaveChanges();
            return Ok();

        }
    }
}
