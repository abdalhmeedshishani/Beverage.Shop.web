using AutoMapper;
using Beverage.Shop.web.Models.Drinks;
using Shop.entites;

namespace Beverage.Shop.web.AutoMapper
{
    public class DrinkAutoMapper: Profile
    {

        public DrinkAutoMapper()
        {
            CreateMap<DrinkViewModel, Drink >().ReverseMap();

            CreateMap<Drink, DrinkDetailsViewModel>().ReverseMap();

            CreateMap<Drink, DrinkListViewModel>().ReverseMap();




        }


    }
}
