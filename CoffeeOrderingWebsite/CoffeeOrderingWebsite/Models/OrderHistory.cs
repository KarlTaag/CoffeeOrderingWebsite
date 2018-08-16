using System;

namespace CoffeeOrderingWebsite.Models
{
    public class OrderHistory
    {
        public int ID { get; set; }

        public string DrinkName { get; set; } 

        public DateTime OrderTime { get; set; }
    }
}