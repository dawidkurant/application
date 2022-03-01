using AutoMapper;
using Papu.Entities;
using Papu.Models;
using Papu.Models.Create;
using System.Linq;

namespace Papu
{
    public class PapuMappingProfile : Profile
    {
        public PapuMappingProfile()
        {
            //Mapowanie z jednego typu na drugi, czyli kopiowanie
            //co na co mapujemy i określamy reguły
            //dla jakich właściwości chcemy skonfigurować dane mapowanie 
            //MapFrom() - np. z jakiego pola chcemy mapować do pola CategoryName
            CreateMap<Product, ProductDto>()
                .ForMember(dto => dto.Groups, c => c.MapFrom(dto => dto.ProductGroups.Select(cs => cs.Group)))
                .ForMember(dto => dto.CategoryName, c => c.MapFrom(dto => dto.Category.CategoryName))
                .ForMember(dto => dto.UnitName, c => c.MapFrom(dto => dto.Unit.UnitName));

            CreateMap<Dish, DishDto>()
                .ForMember(dto => dto.KindsOf, c => c.MapFrom(dto => dto.DishKindsOf.Select(cs => cs.KindOf)))
                .ForMember(dto => dto.Types, c => c.MapFrom(dto => dto.DishTypes.Select(cs => cs.Type)))
                .ForMember(dto => dto.Products, c => c.MapFrom(dto => dto.DishProducts.Select(cs => cs.Product)));

            /*CreateMap<Menu, MenuDto>()
                .ForMember(x => x.FridayProducts, c => c.MapFrom(s => s.Friday.FridayProducts.Select(cs => cs.Product)))
                .ForMember(x => x.FridayDishes, c => c.MapFrom(s => s.Friday.FridayDishes.Select(cs => cs.Dish)))
                *//*.ForMember(x => x.MondayProducts, c => c.MapFrom(s => s.Monday.MondayProducts.Select(cs => cs.Product)))
                .ForMember(x => x.MondayDishes, c => c.MapFrom(s => s.Monday.MondayDishes.Select(cs => cs.Dish)))*//*
                .ForMember(x => x.TuesdayProducts, c => c.MapFrom(s => s.Tuesday.TuesdayProducts.Select(cs => cs.Product)))
                .ForMember(x => x.TuesdayDishes, c => c.MapFrom(s => s.Tuesday.TuesdayDishes.Select(cs => cs.Dish)))
                .ForMember(x => x.WednesdayProducts, c => c.MapFrom(s => s.Wednesday.WednesdayProducts.Select(cs => cs.Product)))
                .ForMember(x => x.WednesdayDishes, c => c.MapFrom(s => s.Wednesday.WednesdayDishes.Select(cs => cs.Dish)))
                .ForMember(x => x.ThursdayProducts, c => c.MapFrom(s => s.Thursday.ThursdayProducts.Select(cs => cs.Product)))
                .ForMember(x => x.ThursdayDishes, c => c.MapFrom(s => s.Thursday.ThursdayDishes.Select(cs => cs.Dish)))
                .ForMember(x => x.SaturdayProducts, c => c.MapFrom(s => s.Saturday.SaturdayProducts.Select(cs => cs.Product)))
                .ForMember(x => x.SaturdayDishes, c => c.MapFrom(s => s.Saturday.SaturdayDishes.Select(cs => cs.Dish)))
                .ForMember(x => x.SundayProducts, c => c.MapFrom(s => s.Sunday.SundayProducts.Select(cs => cs.Product)))
                .ForMember(x => x.SundayDishes, c => c.MapFrom(s => s.Sunday.SundayDishes.Select(cs => cs.Dish)));*/

            CreateMap<Breakfast, BreakfastDto>()
                .ForMember(x => x.Products, c => c.MapFrom(x => x.Products.Select(cs => cs.Product)))
                .ForMember(x => x.Dishes, c => c.MapFrom(x => x.Dishes.Select(cs => cs.Dish)));

            CreateMap<SecondBreakfast, SecondBreakfastDto>()
                .ForMember(x => x.Products, c => c.MapFrom(x => x.Products.Select(cs => cs.Product)))
                .ForMember(x => x.Dishes, c => c.MapFrom(x => x.Dishes.Select(cs => cs.Dish)));

            CreateMap<Lunch, LunchDto>()
                .ForMember(x => x.Products, c => c.MapFrom(x => x.Products.Select(cs => cs.Product)))
                .ForMember(x => x.Dishes, c => c.MapFrom(x => x.Dishes.Select(cs => cs.Dish)));

            CreateMap<Snack, SnackDto>()
                .ForMember(x => x.Products, c => c.MapFrom(x => x.Products.Select(cs => cs.Product)))
                .ForMember(x => x.Dishes, c => c.MapFrom(x => x.Dishes.Select(cs => cs.Dish)));

            CreateMap<Dinner, DinnerDto>()
                .ForMember(x => x.Products, c => c.MapFrom(x => x.Products.Select(cs => cs.Product)))
                .ForMember(x => x.Dishes, c => c.MapFrom(x => x.Dishes.Select(cs => cs.Dish)));

            CreateMap<Monday, MondayDto>();

            CreateMap<CreateProductDto, Product>();

            CreateMap<CreateDishDto, Dish>();

            CreateMap<CreateMenuDto, Menu>();

            CreateMap<CreateBreakfastDto, Breakfast>();
            CreateMap<CreateSecondBreakfastDto, SecondBreakfast>();
            CreateMap<CreateLunchDto, Lunch>();
            CreateMap<CreateSnackDto, Snack>();
            CreateMap<CreateDinnerDto, Dinner>();
        }
    }
}
