using AutoMapper;
using Beverage.Shop.web.Models.FruitsAndSpices;
using Shop.entites;

namespace Beverage.Shop.web.AutoMapper
{
    public class FruitAndSpiceAutoMapper: Profile
    {
        public FruitAndSpiceAutoMapper() 
        { 
            
        CreateMap<FruitAndSpiceViewModel, FruitAndSpice>().ReverseMap();

        CreateMap<FruitAndSpice, FruitAndSpiceListViewModel>().ReverseMap();

        }
    }
}
