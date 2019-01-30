using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        [Required (ErrorMessage = "Field can not be valid")]
        public string Address { get; set; }

        //Relationship
        public ICollection<Sales> Sales { get; set; }
    }
}