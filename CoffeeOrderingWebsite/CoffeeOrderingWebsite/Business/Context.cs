using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoffeeOrderingWebsite.Models;

namespace CoffeeOrderingWebsite.Business
{
    public class Context : IContext
    {
        protected volatile IDataLayer _datalayer;

        #region Properties

        private List<Drink> CachedDrinks
        {
            get
            {
                var response = HttpContext.Current.Session["CachedDrinks"];
                if (response == null)
                {
                    CachedDrinks = new List<Drink>();
                    return HttpContext.Current.Session["CachedDrinks"] as List<Drink>;
                }

                return response as List<Drink>;
            }

            set
            {
                HttpContext.Current.Session["CachedDrinks"] = value;
            }
        }

        private List<OrderHistory> CachedOrderHistory
        {
            get
            {
                var response = HttpContext.Current.Session["CachedOrderHistory"];
                if (response == null)
                {
                    CachedOrderHistory = new List<OrderHistory>();
                    return HttpContext.Current.Session["CachedOrderHistory"] as List<OrderHistory>;
                }

                return response as List<OrderHistory>;
            }

            set
            {
                HttpContext.Current.Session["CachedOrderHistory"] = value;
            }
        }

        private List<Stock> CachedStocks
        {
            get
            {
                var response = HttpContext.Current.Session["CachedStocks"];
                if (response == null)
                {
                    CachedStocks = new List<Stock>();
                    return HttpContext.Current.Session["CachedStocks"] as List<Stock>;
                }

                return response as List<Stock>;
            }

            set
            {
                HttpContext.Current.Session["CachedStocks"] = value;
            }
        }

        #endregion

        #region Constructor

        public Context(IDataLayer datalayer)
        {
            _datalayer = datalayer;
        }

        #endregion

        #region IContext Members

        public void AddOrderHistory(OrderHistory history)
        {
            _datalayer.AddOrderHistory(history);
            CachedOrderHistory = _datalayer.GetAllOrderHistory();
        }

        public void AddOrUpdateDrink(Drink drink)
        {
            _datalayer.AddOrUpdateDrink(drink);
            CachedDrinks = _datalayer.GetAllDrinks();
        }

        public void AddOrUpdateStock(Stock stock)
        {
            _datalayer.AddOrUpdateStock(stock);
            CachedStocks = _datalayer.GetAllStocks();
        }

        public void Clear()
        {
            HttpContext.Current.Session.Clear();
            _datalayer.ClearContext();
        }

        public List<Drink> GetCachedDrinks()
        {
            if (CachedDrinks == null || CachedDrinks.Count <= 0)
            {
                CachedDrinks = _datalayer.GetAllDrinks();                
            }

            return CachedDrinks;
        }

        public List<OrderHistory> GetCachedOrderHistory()
        {
            if (CachedOrderHistory == null || CachedOrderHistory.Count <= 0)
            {
                CachedOrderHistory = _datalayer.GetAllOrderHistory();
            }

            return CachedOrderHistory;
        }

        public List<Stock> GetCachedStocks()
        {
            if (CachedStocks == null || CachedStocks.Count <= 0)
            {
                CachedStocks = _datalayer.GetAllStocks();
            }

            return CachedStocks;
        }

        #endregion
    }
}