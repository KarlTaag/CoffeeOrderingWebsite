using CoffeeOrderingWebsite.Business;
using CoffeeOrderingWebsite.Models.ViewModels;
using CoffeeOrderingWebsite.Business.Utilities;
using System.Web.Mvc;

namespace CoffeeOrderingWebsite.Controllers
{
    public class ViewStocksController : BaseController
    {
        public ViewStocksController(IContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var stocksViewModel = new StocksViewModel()
            {
                AvailableStocks = _context.GetCachedStocks()
            };

            stocksViewModel.CreateDataPoints();

            return View(stocksViewModel);
        }

        public ActionResult Refresh()
        {
            var defaultStocks = DefaultContentUtilities.GetDefaultStocks();

            foreach (var stock in defaultStocks)
            {
                _context.AddOrUpdateStock(stock);
            }

            return RedirectToAction("Index");
        }
    }
}