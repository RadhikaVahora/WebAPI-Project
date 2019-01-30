using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using System.Data.Entity;
using System.Web.Http.Results;


namespace Vidly.Controllers.Api
{
    public class SaleController : ApiController
    {
        private DbEntities Db = new DbEntities();

        [HttpGet]
        public IHttpActionResult GetSaleRecord(int id)
        {
            SalesViewModel salerecord = new SalesViewModel();
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var sale = Db.Sales.SingleOrDefault(c => c.SaleId == id);
            if (sale == null)
                NotFound();
            salerecord.Date = sale.Date;
            salerecord.SaleId = sale.SaleId;
            salerecord.CustomerId = sale.CustomerId;
            salerecord.ProductId = sale.ProductId;
            salerecord.StoreId = sale.StoreId;

            return Ok(salerecord);

        }
        [HttpPost]
        public IHttpActionResult Create(Sales sale)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }
            Db.Sales.Add(sale);
            Db.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + sale.SaleId), sale);
        }
        [HttpPut]
        public IHttpActionResult Edit(Sales sale)
        {
            var id = sale.SaleId;
            Sales salerecord = sale;

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var SaleObj = Db.Sales.SingleOrDefault(c => c.SaleId == id);
            if (SaleObj == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            SaleObj.CustomerId = salerecord.CustomerId;
            SaleObj.ProductId = salerecord.ProductId;
            SaleObj.StoreId = salerecord.StoreId;
            SaleObj.Date = salerecord.Date;
            Db.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
    
            var SaleObj = Db.Sales.SingleOrDefault(c => c.SaleId == id) ;
            if (SaleObj == null)
                NotFound();
            Db.Sales.Remove(SaleObj);
            Db.SaveChanges();
            return Ok();

        }

        public IHttpActionResult GetSalesRecord()
        {
            List<SalesViewModel> List = Db.Sales.Select(x => new SalesViewModel
            {
                SaleId = x.SaleId,
                CustomerId = x.CustomerId,
                CustomerName = x.Customer.Name,
                ProductName = x.Product.Name,
                StoreName = x.Store.Name,
                ProductId = x.Product.ProductId,
                StoreId = x.Store.StoreId,
                Date = x.Date
                
            }).ToList();

            return Ok(List);
        }

    }
}
