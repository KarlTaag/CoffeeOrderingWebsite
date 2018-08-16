using CoffeeOrderingWebsite.Business;
using CoffeeOrderingWebsite.Business.Utilities;
using CoffeeOrderingWebsite.Models;
using CoffeeOrderingWebsite.Models.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CoffeeOrderingWebsite.Controllers
{
    public class CoffeeSelectionController : BaseController
    {
        public CoffeeSelectionController(IContext context)
        {
            _context = context;           
        }

        public ActionResult Index()
        { 
            var availableDrinks = BusinessUtilities.FilterDrinksByStocks(_context.GetCachedDrinks(), _context.GetCachedStocks());

            var drinksViewModel = new DrinksViewModel()
            {
                AvailableDrinks = availableDrinks,
                IsSubmitSuccessful = false
            };

            return View(drinksViewModel);
        }

        [HttpPost]
        public ActionResult Index(DrinksViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.SelectedDrink != null)
                {
                    var selectedDrink = _context.GetCachedDrinks().FirstOrDefault(x => x.ID == model.SelectedDrink);
                    var updatedStocks = BusinessUtilities.UpdateStocksByDrinkPurchased(_context.GetCachedStocks(), selectedDrink);

                    foreach (var stock in updatedStocks)
                    {
                        _context.AddOrUpdateStock(stock);
                    }
                  
                    model.IsSubmitSuccessful = true;

                    _context.AddOrderHistory
                    (
                        new OrderHistory()
                        {
                            DrinkName = selectedDrink.Name,
                            OrderTime = DateTime.Now
                        }
                    );
                }

                model.AvailableDrinks = BusinessUtilities.FilterDrinksByStocks(_context.GetCachedDrinks(), _context.GetCachedStocks());
            }

            return View(model);
        }
    }
}