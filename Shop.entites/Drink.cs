using Shop.Utils.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.entites
{
    public class Drink
    {
        public Drink()
        {
            FruitAndSpices = new List<FruitAndSpice>();
        }
        public int Id { get; set; }
        public string DrinkName { get; set; }
        public TypeOfDrink TypeOfDrink { get; set; }
        public DateTime? ProductionDate { get; set; }

        public List<FruitAndSpice> FruitAndSpices { get; set; }


    }
}
