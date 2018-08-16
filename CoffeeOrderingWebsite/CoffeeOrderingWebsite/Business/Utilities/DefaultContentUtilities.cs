using CoffeeOrderingWebsite.Common;
using CoffeeOrderingWebsite.Models;
using System.Collections.Generic;

namespace CoffeeOrderingWebsite.Business.Utilities
{
    public static class DefaultContentUtilities
    {
        public static List<Drink> GetDefaultDrinks()
        {
            return new List<Drink>()
            {
                new Drink() { Name = Constants.DoubleAmericanoDrink, CoffeeBeanUnit = 3, MilkUnit = 0, SugarUnit = 0 },
                new Drink() { Name = Constants.SweetLatteDrink, CoffeeBeanUnit = 2, MilkUnit = 3, SugarUnit = 5 },
                new Drink() { Name = Constants.FlatWhiteDrink, CoffeeBeanUnit = 2, MilkUnit = 4, SugarUnit = 1 }
            };
        }

        public static List<Stock> GetDefaultStocks()
        {
            return new List<Stock>()
            {
                new Stock() { Name = Constants.CoffeeBeansIngredient, RemainingUnits = 45 },
                new Stock() { Name = Constants.SugarIngredient, RemainingUnits = 45 },
                new Stock() { Name = Constants.MilkIngredient, RemainingUnits = 45 }
            };
        }
    }
}