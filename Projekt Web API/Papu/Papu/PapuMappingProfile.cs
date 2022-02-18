using AutoMapper;
using Papu.Entities;
using Papu.Models;

namespace Papu
{
    public class PapuMappingProfile : Profile
    {
        public PapuMappingProfile()
        {
            //mapowanie z jednego typu na drugi, czyli kopiowanie
            //co na co mapujemy i określamy reguły
            //dla jakich właściwości chcemy skonfigurować dane mapowanie 
            //MapFrom() - z jakiego pola chcemy mapować do pola CategoryName
            CreateMap<Product, ProductDto>()
                .ForMember(x => x.CategoryName, c => c.MapFrom(s => s.Category.CategoryName))
                .ForMember(x => x.UnitName, c => c.MapFrom(s => s.Unit.UnitName));

            CreateMap<Dish, DishDto>();

            CreateMap<Menu, MenuDto>()
                .ForMember(x => x.FridayProducts, c => c.MapFrom(s => s.Friday.FridayProducts))
                .ForMember(x => x.FridayDishes, c => c.MapFrom(s => s.Friday.FridayDishes))
                .ForMember(x => x.MondayProducts, c => c.MapFrom(s => s.Monday.MondayProducts))
                .ForMember(x => x.MondayDishes, c => c.MapFrom(s => s.Monday.MondayDishes))
                .ForMember(x => x.TuesdayProducts, c => c.MapFrom(s => s.Tuesday.TuesdayProducts))
                .ForMember(x => x.TuesdayDishes, c => c.MapFrom(s => s.Tuesday.TuesdayDishes))
                .ForMember(x => x.WednesdayProducts, c => c.MapFrom(s => s.Wednesday.WednesdayProducts))
                .ForMember(x => x.WednesdayDishes, c => c.MapFrom(s => s.Wednesday.WednesdayDishes))
                .ForMember(x => x.ThursdayProducts, c => c.MapFrom(s => s.Thursday.ThursdayProducts))
                .ForMember(x => x.ThursdayDishes, c => c.MapFrom(s => s.Thursday.ThursdayDishes))
                .ForMember(x => x.SaturdayProducts, c => c.MapFrom(s => s.Saturday.SaturdayProducts))
                .ForMember(x => x.SaturdayDishes, c => c.MapFrom(s => s.Saturday.SaturdayDishes))
                .ForMember(x => x.SundayProducts, c => c.MapFrom(s => s.Sunday.SundayProducts))
                .ForMember(x => x.SundayDishes, c => c.MapFrom(s => s.Sunday.SundayDishes));

        }
    }
}
