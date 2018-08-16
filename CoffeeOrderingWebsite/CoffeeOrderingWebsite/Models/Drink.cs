using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeOrderingWebsite.Models
{
    public class Drink
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int CoffeeBeanUnit { get; set; }

        public int SugarUnit { get; set; }

        public int MilkUnit { get; set; }
    }
}