using CoffeeOrderingWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderingWebsite.Business
{
    public interface IDataLayer
    {
        void AddOrUpdateDrink(Drink drink);

        void AddOrderHistory(OrderHistory history);

        void AddOrUpdateStock(Stock stock);

        Drink GetDrinkById(int id);

        List<Drink> GetAllDrinks();

        List<OrderHistory> GetAllOrderHistory();

        List<Stock> GetAllStocks();

        void ClearContext();
    }
}
