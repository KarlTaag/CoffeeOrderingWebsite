using CoffeeOrderingWebsite.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeOrderingWebsite.Controllers
{
    public class BaseController : Controller
    {
        protected volatile IContext _context;       
    }
}