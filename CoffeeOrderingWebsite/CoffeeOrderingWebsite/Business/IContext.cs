using CoffeeOrderingWebsite.Models;
using System.Collections.Generic;

namespace CoffeeOrderingWebsite.Business
{
    public interface IContext
    {
        List<Drink> GetCachedDrinks();
        List<OrderHistory> GetCachedOrderHistory();
        List<Stock> GetCachedStocks();

        void AddOrUpdateDrink(Drink drink);
        void AddOrderHistory(OrderHistory history);
        void AddOrUpdateStock(Stock stock);
     
        void Clear();
    }
}
