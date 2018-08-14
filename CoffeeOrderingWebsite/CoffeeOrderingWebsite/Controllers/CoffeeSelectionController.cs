using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeOrderingWebsite.Controllers
{
    public class CoffeeSelectionController : Controller
    {
        // GET: CoffeeSelection
        public ActionResult Index()
        {
            return View();
        }
    }
}