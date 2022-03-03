using AutoMapper;
using Papu.Entities;
using Papu.Models;
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

            CreateMap<Monday, MondayDto>()
                .ForMember(dto => dto.BreakfastMondayId, c => c.MapFrom(dto => dto.Breakfast.BreakfastId))
                .ForMember(x => x.BreakfastProducts, c => c.MapFrom(x => x.Breakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.BreakfastDishes, c => c.MapFrom(x => x.Breakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SecondBreakfastMondayId, c => c.MapFrom(dto => dto.SecondBreakfast.SecondBreakfastId))
                .ForMember(x => x.SecondBreakfastProducts, c => c.MapFrom(x => x.SecondBreakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.SecondBreakfastDishes, c => c.MapFrom(x => x.SecondBreakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.LunchMondayId, c => c.MapFrom(dto => dto.Lunch.LunchId))
                .ForMember(x => x.LunchProducts, c => c.MapFrom(x => x.Lunch.Products.Select(cs => cs.Product)))
                .ForMember(x => x.LunchDishes, c => c.MapFrom(x => x.Lunch.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SnackMondayId, c => c.MapFrom(dto => dto.Snack.SnackId))
                .ForMember(x => x.SnackProducts, c => c.MapFrom(x => x.Snack.Products.Select(cs => cs.Product)))
                .ForMember(x => x.SnackDishes, c => c.MapFrom(x => x.Snack.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.DinnerMondayId, c => c.MapFrom(dto => dto.Dinner.DinnerId))
                .ForMember(x => x.DinnerProducts, c => c.MapFrom(x => x.Dinner.Products.Select(cs => cs.Product)))
                .ForMember(x => x.DinnerDishes, c => c.MapFrom(x => x.Dinner.Dishes.Select(cs => cs.Dish)));

            //.ForMember(dto => dto.BreakfastMondayId, c => c.MapFrom(dto => dto.BreakfastId))


            CreateMap<CreateProductDto, Product>();

            CreateMap<CreateDishDto, Dish>();

            CreateMap<CreateBreakfastDto, Breakfast>();
            CreateMap<CreateSecondBreakfastDto, SecondBreakfast>();
            CreateMap<CreateLunchDto, Lunch>();
            CreateMap<CreateSnackDto, Snack>();
            CreateMap<CreateDinnerDto, Dinner>();

            CreateMap<CreateMondayDto, Monday>();
        }
    }
}
