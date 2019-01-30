using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required(ErrorMessage ="Please Enter Name")]
        public string Name { get; set; }
        public string Address { get; set; }

        //Relationship
        public ICollection<Sales> Sales { get; set; }

    }
}