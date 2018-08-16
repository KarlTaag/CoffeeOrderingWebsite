using System.Collections.Generic;

namespace CoffeeOrderingWebsite.Models.ViewModels
{
    public class DrinksViewModel
    {
        public List<Drink> AvailableDrinks { get; set; }

        public int? SelectedDrink { get; set; }

        public bool IsSubmitSuccessful { get; set; }
    }
}