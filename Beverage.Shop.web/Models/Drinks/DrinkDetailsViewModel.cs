using Beverage.Shop.web.Models.FruitsAndSpices;
using Shop.Utils.Enum;
using System.ComponentModel.DataAnnotations;

namespace Beverage.Shop.web.Models.Drinks
{
    public class DrinkDetailsViewModel
    {
       public DrinkDetailsViewModel(){

            FruitAndSpice = new List<FruitAndSpiceViewModel>();
        }

        public int Id { get; set; }
        public string DrinkName { get; set; }
        [Display(Name = "Type.Of.Drink")]
        public TypeOfDrink TypeOfDrink { get; set; }
        public DateTime? ProductionDate { get; set; }
        public List<FruitAndSpiceViewModel> FruitAndSpice { get; set; }



    }
}
