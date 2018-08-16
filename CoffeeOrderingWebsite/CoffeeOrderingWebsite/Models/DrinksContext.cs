using System.Data.Entity;

namespace CoffeeOrderingWebsite.Models
{
    public class DrinksContext : DbContext
    {
        public DbSet<Drink> Drinks { get; set; }

        public DbSet<OrderHistory> OrderHistoryList { get; set; }

        public DbSet<Stock> Stocks { get; set; }
    }
}