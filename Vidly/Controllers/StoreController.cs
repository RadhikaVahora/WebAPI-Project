using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class StoreController : Controller
    {
      
        // GET: Store
        public ActionResult Index()
        {
            return View();
        }

    }
}