using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class SalesViewModel
    {
        [Key]
        public int SaleId { get; set; }
       
        //Relationship
//        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
 //       public Product Product { get; set; }
        public int ProductId { get; set; }
//        public Store Store { get; set; }
        public int StoreId { get; set; }


        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        //Custom Attribute
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public string StoreName { get; set; }



    }
}