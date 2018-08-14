using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeOrderingWebsite.Controllers
{
    public class ViewStocksController : Controller
    {
        // GET: ViewStocks
        public ActionResult Index()
        {
            return View();
        }
    }
}