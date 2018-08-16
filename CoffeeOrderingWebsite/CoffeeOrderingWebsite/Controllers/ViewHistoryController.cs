using CoffeeOrderingWebsite.Business;
using CoffeeOrderingWebsite.Models.ViewModels;
using System.Web.Mvc;

namespace CoffeeOrderingWebsite.Controllers
{
    public class ViewHistoryController : BaseController
    {
        public ViewHistoryController(IContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var orderHistoryViewModel = new OrderHistoryViewModel()
            {
                OrderHistoryList = _context.GetCachedOrderHistory()
            };

            orderHistoryViewModel.CreateDataPoints();

            return View(orderHistoryViewModel);
        }
    }
}