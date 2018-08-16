using CoffeeOrderingWebsite.Business;
using CoffeeOrderingWebsite.Business.Utilities;
using System.Web.Mvc;

namespace CoffeeOrderingWebsite.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IContext context)
        {
            _context = context;          
        }

        public ActionResult Index()
        {
            PopulateDefaultDrinks();
            PopulateDefaultStocks();
            
            return View();
        }

        public ActionResult Clear()
        {
            _context.Clear();
                     
            return RedirectToAction("Index");
        }

        private void PopulateDefaultDrinks()
        {
            if (_context.GetCachedDrinks() == null || _context.GetCachedDrinks().Count <= 0)
            {
                var defaultDrinks = DefaultContentUtilities.GetDefaultDrinks();

                foreach (var drink in defaultDrinks)
                {
                    _context.AddOrUpdateDrink(drink);
                }
            }          
        }

        private void PopulateDefaultStocks()
        {
            if (_context.GetCachedStocks() == null || _context.GetCachedStocks().Count <= 0)
            {
                var defaultStocks = DefaultContentUtilities.GetDefaultStocks();

                foreach (var stock in defaultStocks)
                {
                    _context.AddOrUpdateStock(stock);
                }
            }         
        }

    }
}