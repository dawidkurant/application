using AutoMapper;
using Papu.Entities;
using Papu.Models;
using Papu.Models.Dish;
using Papu.Models.Product;
using System.Linq;

namespace Papu
{
    public class PapuMappingProfile : Profile
    {
        public PapuMappingProfile()
        {
            /// <summary>
            /// Mapowanie z jednego typu na drugi, czyli kopiowanie
            /// co na co mapujemy i określamy reguły
            /// dla jakich właściwości chcemy skonfigurować dane mapowanie 
            /// MapFrom() - np. z jakiego pola chcemy mapować do pola CategoryName
            /// </summary>
            CreateMap<Product, ProductDto>()
                .ForMember(dto => dto.Groups, c => c.MapFrom(dto => dto.ProductGroups.Select(cs => cs.Group)))
                .ForMember(dto => dto.CategoryName, c => c.MapFrom(dto => dto.Category.CategoryName))
                .ForMember(dto => dto.UnitName, c => c.MapFrom(dto => dto.Unit.UnitName));

            CreateMap<Category, CategoryDto>();
            CreateMap<Unit, UnitDto>();
            CreateMap<Group, GroupDto>();

            CreateMap<Dish, DishDto>()
                .ForMember(dto => dto.KindsOf, c => c.MapFrom(dto => dto.DishKindsOf.Select(cs => cs.KindOf)))
                .ForMember(dto => dto.Types, c => c.MapFrom(dto => dto.DishTypes.Select(cs => cs.Type)))
                .ForMember(dto => dto.Products, c => c.MapFrom(dto => dto.DishProducts.Select(cs => cs.Product)));

            CreateMap<KindOf, KindOfDto>();
            CreateMap<Type, TypeDto>();

            CreateMap<Meal, MealDto>()
                .ForMember(x => x.Products, c => c.MapFrom(x => x.ProductMeals.Select(cs => cs.Product)))
                .ForMember(x => x.Dishes, c => c.MapFrom(x => x.DishMeals.Select(cs => cs.Dish)));

            CreateMap<DayMenu, DayMenuDto>()
                .ForMember(dest => dest.Meals, opt => opt.MapFrom(src => src.Meals));

            CreateMap<UpdateProductDto, Product>();
            CreateMap<UpdateDishDto, Dish>();

            CreateMap<UpdateMealDto, Meal>();

            CreateMap<UpdateDayMenuDto, DayMenu>();

            CreateMap<CreateProductDto, Product>();

            CreateMap<CreateDishDto, Dish>();

            CreateMap<CreateMealDto, Meal>();

            CreateMap<CreateDayMenuDto, DayMenu>();
        }
    }
}
