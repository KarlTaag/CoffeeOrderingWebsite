using CoffeeOrderingWebsite.Common;
using CoffeeOrderingWebsite.Models;
using System.Collections.Generic;

namespace CoffeeOrderingWebsite.Business.Utilities
{
    public static class BusinessUtilities
    {
        public static List<Drink> FilterDrinksByStocks(List<Drink> drinks, List<Stock> stocks)
        {
            var availableDrinks = new List<Drink>();

            var coffeeStock = stocks.Find(x => x.Name == Constants.CoffeeBeansIngredient);
            var milkStock = stocks.Find(x => x.Name == Constants.MilkIngredient);
            var sugarStock = stocks.Find(x => x.Name == Constants.SugarIngredient);

            foreach (var drink in drinks)
            {
                if (drink.CoffeeBeanUnit <= coffeeStock.RemainingUnits &&
                    drink.MilkUnit <= milkStock.RemainingUnits &&
                    drink.SugarUnit <= sugarStock.RemainingUnits)
                {
                    availableDrinks.Add(drink);
                }
            }

            return availableDrinks;
        }

        public static List<Stock> UpdateStocksByDrinkPurchased(List<Stock> stocks, Drink drink)
        {
            var updatedCoffeeStock = new Stock();
            updatedCoffeeStock.Name = Constants.CoffeeBeansIngredient;
            updatedCoffeeStock.RemainingUnits = stocks.Find(x => x.Name == Constants.CoffeeBeansIngredient).RemainingUnits - drink.CoffeeBeanUnit;
            
            var updatedSugarStock = new Stock();
            updatedSugarStock.Name = Constants.SugarIngredient;
            updatedSugarStock.RemainingUnits = stocks.Find(x => x.Name == Constants.SugarIngredient).RemainingUnits - drink.SugarUnit;
            
            var updatedMilkStock = new Stock();
            updatedMilkStock.Name = Constants.MilkIngredient;
            updatedMilkStock.RemainingUnits = stocks.Find(x => x.Name == Constants.MilkIngredient).RemainingUnits - drink.MilkUnit;
            
            return new List<Stock>()
            {
                updatedCoffeeStock,
                updatedMilkStock,
                updatedSugarStock
            };
        }
        
    }
}