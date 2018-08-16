using System.Collections.Generic;
using System.Linq;
using CoffeeOrderingWebsite.Models;

namespace CoffeeOrderingWebsite.Business
{
    public class DataLayer : IDataLayer
    {
        public void AddOrderHistory(OrderHistory history)
        {
            using (var db = new DrinksContext())
            {
                var newId = 1;

                if (db.OrderHistoryList != null && db.OrderHistoryList.Count() > 0)
                {
                    newId = db.OrderHistoryList.Max(x => x.ID) + 1;
                }

                history.ID = newId;
                db.OrderHistoryList.Add(history);
                db.SaveChanges();
            }
        }

        public void AddOrUpdateDrink(Drink drink)
        {
            using (var db = new DrinksContext())
            {
                var existingDrink = db.Drinks.FirstOrDefault(x => x.Name == drink.Name);

                if (existingDrink != null)
                {
                    existingDrink.MilkUnit = drink.MilkUnit;
                    existingDrink.SugarUnit = drink.SugarUnit;
                    existingDrink.CoffeeBeanUnit = drink.CoffeeBeanUnit;
                }
                else
                {
                    var newId = 1;

                    if (db.Drinks != null && db.Drinks.Count() > 0)
                    {
                        newId = db.Drinks.Max(x => x.ID) + 1;
                    }

                    drink.ID = newId;
                    db.Drinks.Add(drink);
                }

                db.SaveChanges();
            }
        }

        public void AddOrUpdateStock(Stock stock)
        {
            using (var db = new DrinksContext())
            {
                var existingStock = db.Stocks.FirstOrDefault(x => x.Name == stock.Name);

                if (existingStock != null)
                {
                    existingStock.RemainingUnits = stock.RemainingUnits;
                }
                else
                {
                    var newId = 1;

                    if (db.Stocks != null && db.Stocks.Count() > 0)
                    {
                        newId = db.Stocks.Max(x => x.ID) + 1;
                    }

                    stock.ID = newId;
                    db.Stocks.Add(stock);
                }

                db.SaveChanges();
            }
        }

        public void ClearContext()
        {
            using (var db = new DrinksContext())
            {
                foreach (var drink in db.Drinks)
                {
                    db.Drinks.Remove(drink);
                }

                foreach (var history in db.OrderHistoryList)
                {
                    db.OrderHistoryList.Remove(history);
                }

                foreach (var stock in db.Stocks)
                {
                    db.Stocks.Remove(stock);
                }

                db.SaveChanges();
            }
        }

        public List<Drink> GetAllDrinks()
        {
            var drinks = new List<Drink>();

            using (var db = new DrinksContext())
            {
                var query = db.Drinks.Where(x => x.ID > 0 && !string.IsNullOrEmpty(x.Name));

                if (query != null)
                {
                    drinks = query.ToList();
                }
            }

            return drinks;
        }

        public List<OrderHistory> GetAllOrderHistory()
        {
            var orderHistoryList = new List<OrderHistory>();

            using (var db = new DrinksContext())
            {
                var query = db.OrderHistoryList.Where(x => x.ID > 0);

                if (query != null)
                {
                    orderHistoryList = query.OrderBy(x => x.OrderTime).ToList();
                }
            }

            return orderHistoryList;
        }

        public List<Stock> GetAllStocks()
        {
            var stocks = new List<Stock>();

            using (var db = new DrinksContext())
            {
                var query = db.Stocks.Where(x => x.ID > 0);

                if (query != null)
                {
                    stocks = query.ToList();
                }
            }

            return stocks;
        }

        public Drink GetDrinkById(int id)
        {
            Drink drink = null;

            using (var db = new DrinksContext())
            {
                var query = db.Drinks.FirstOrDefault(x => x.ID == id);

                if (query != null)
                {
                    drink = query;
                }
            }

            return drink;
        }
    }
}