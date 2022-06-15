using Beverage.Shop.web.Models.FruitsAndSpices;
using Shop.Utils.Enum;
using System.ComponentModel.DataAnnotations;

namespace Beverage.Shop.web.Models.Drinks
{
    public class DrinkViewModel
    {
        public DrinkViewModel()
        {
            FruitAndSpice = new List<FruitAndSpiceListViewModel>();
        }
        public int Id { get; set; }
        public string DrinkName { get; set; }
        [Display(Name ="Type.Of.Drink")]
        public TypeOfDrink TypeOfDrink { get; set; }
        public DateTime? ProductionDate { get; set; }
        public List<FruitAndSpiceListViewModel> FruitAndSpice { get; set; }



    }
}
