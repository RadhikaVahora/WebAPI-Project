using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        
        public ActionResult Index()
        {
            
            return View();
        }

        protected override void Dispose(bool disposing)
        {
           
        }
    }
}