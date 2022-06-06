using AutoMapper;
using Papu.Entities;
using Papu.Models;
using Papu.Models.Dish;
using Papu.Models.Product;
using Papu.Models.Update;
using Papu.Models.Update.DayOfTheWeek;
using Papu.Models.Update.TimesOfDay;
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

            CreateMap<Category, CategoryDto>();
            CreateMap<Unit, UnitDto>();
            CreateMap<Group, GroupDto>();

            CreateMap<Dish, DishDto>()
                .ForMember(dto => dto.KindsOf, c => c.MapFrom(dto => dto.DishKindsOf.Select(cs => cs.KindOf)))
                .ForMember(dto => dto.Types, c => c.MapFrom(dto => dto.DishTypes.Select(cs => cs.Type)))
                .ForMember(dto => dto.Products, c => c.MapFrom(dto => dto.DishProducts.Select(cs => cs.Product)));

            CreateMap<KindOf, KindOfDto>();
            CreateMap<Type, TypeDto>();

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

            CreateMap<Tuesday, TuesdayDto>()
                .ForMember(dto => dto.BreakfastTuesdayId, c => c.MapFrom(dto => dto.Breakfast.BreakfastId))
                .ForMember(x => x.BreakfastProducts, c => c.MapFrom(x => x.Breakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.BreakfastDishes, c => c.MapFrom(x => x.Breakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SecondBreakfastTuesdayId, c => c.MapFrom(dto => dto.SecondBreakfast.SecondBreakfastId))
                .ForMember(x => x.SecondBreakfastProducts, c => c.MapFrom(x => x.SecondBreakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.SecondBreakfastDishes, c => c.MapFrom(x => x.SecondBreakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.LunchTuesdayId, c => c.MapFrom(dto => dto.Lunch.LunchId))
                .ForMember(x => x.LunchProducts, c => c.MapFrom(x => x.Lunch.Products.Select(cs => cs.Product)))
                .ForMember(x => x.LunchDishes, c => c.MapFrom(x => x.Lunch.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SnackTuesdayId, c => c.MapFrom(dto => dto.Snack.SnackId))
                .ForMember(x => x.SnackProducts, c => c.MapFrom(x => x.Snack.Products.Select(cs => cs.Product)))
                .ForMember(x => x.SnackDishes, c => c.MapFrom(x => x.Snack.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.DinnerTuesdayId, c => c.MapFrom(dto => dto.Dinner.DinnerId))
                .ForMember(x => x.DinnerProducts, c => c.MapFrom(x => x.Dinner.Products.Select(cs => cs.Product)))
                .ForMember(x => x.DinnerDishes, c => c.MapFrom(x => x.Dinner.Dishes.Select(cs => cs.Dish)));

            CreateMap<Wednesday, WednesdayDto>()
                .ForMember(dto => dto.BreakfastWednesdayId, c => c.MapFrom(dto => dto.Breakfast.BreakfastId))
                .ForMember(x => x.BreakfastProducts, c => c.MapFrom(x => x.Breakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.BreakfastDishes, c => c.MapFrom(x => x.Breakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SecondBreakfastWednesdayId, c => c.MapFrom(dto => dto.SecondBreakfast.SecondBreakfastId))
                .ForMember(x => x.SecondBreakfastProducts, c => c.MapFrom(x => x.SecondBreakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.SecondBreakfastDishes, c => c.MapFrom(x => x.SecondBreakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.LunchWednesdayId, c => c.MapFrom(dto => dto.Lunch.LunchId))
                .ForMember(x => x.LunchProducts, c => c.MapFrom(x => x.Lunch.Products.Select(cs => cs.Product)))
                .ForMember(x => x.LunchDishes, c => c.MapFrom(x => x.Lunch.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SnackWednesdayId, c => c.MapFrom(dto => dto.Snack.SnackId))
                .ForMember(x => x.SnackProducts, c => c.MapFrom(x => x.Snack.Products.Select(cs => cs.Product)))
                .ForMember(x => x.SnackDishes, c => c.MapFrom(x => x.Snack.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.DinnerWednesdayId, c => c.MapFrom(dto => dto.Dinner.DinnerId))
                .ForMember(x => x.DinnerProducts, c => c.MapFrom(x => x.Dinner.Products.Select(cs => cs.Product)))
                .ForMember(x => x.DinnerDishes, c => c.MapFrom(x => x.Dinner.Dishes.Select(cs => cs.Dish)));

            CreateMap<Thursday, ThursdayDto>()
                .ForMember(dto => dto.BreakfastThursdayId, c => c.MapFrom(dto => dto.Breakfast.BreakfastId))
                .ForMember(x => x.BreakfastProducts, c => c.MapFrom(x => x.Breakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.BreakfastDishes, c => c.MapFrom(x => x.Breakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SecondBreakfastThursdayId, c => c.MapFrom(dto => dto.SecondBreakfast.SecondBreakfastId))
                .ForMember(x => x.SecondBreakfastProducts, c => c.MapFrom(x => x.SecondBreakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.SecondBreakfastDishes, c => c.MapFrom(x => x.SecondBreakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.LunchThursdayId, c => c.MapFrom(dto => dto.Lunch.LunchId))
                .ForMember(x => x.LunchProducts, c => c.MapFrom(x => x.Lunch.Products.Select(cs => cs.Product)))
                .ForMember(x => x.LunchDishes, c => c.MapFrom(x => x.Lunch.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SnackThursdayId, c => c.MapFrom(dto => dto.Snack.SnackId))
                .ForMember(x => x.SnackProducts, c => c.MapFrom(x => x.Snack.Products.Select(cs => cs.Product)))
                .ForMember(x => x.SnackDishes, c => c.MapFrom(x => x.Snack.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.DinnerThursdayId, c => c.MapFrom(dto => dto.Dinner.DinnerId))
                .ForMember(x => x.DinnerProducts, c => c.MapFrom(x => x.Dinner.Products.Select(cs => cs.Product)))
                .ForMember(x => x.DinnerDishes, c => c.MapFrom(x => x.Dinner.Dishes.Select(cs => cs.Dish)));

            CreateMap<Friday, FridayDto>()
                .ForMember(dto => dto.BreakfastFridayId, c => c.MapFrom(dto => dto.Breakfast.BreakfastId))
                .ForMember(x => x.BreakfastProducts, c => c.MapFrom(x => x.Breakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.BreakfastDishes, c => c.MapFrom(x => x.Breakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SecondBreakfastFridayId, c => c.MapFrom(dto => dto.SecondBreakfast.SecondBreakfastId))
                .ForMember(x => x.SecondBreakfastProducts, c => c.MapFrom(x => x.SecondBreakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.SecondBreakfastDishes, c => c.MapFrom(x => x.SecondBreakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.LunchFridayId, c => c.MapFrom(dto => dto.Lunch.LunchId))
                .ForMember(x => x.LunchProducts, c => c.MapFrom(x => x.Lunch.Products.Select(cs => cs.Product)))
                .ForMember(x => x.LunchDishes, c => c.MapFrom(x => x.Lunch.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SnackFridayId, c => c.MapFrom(dto => dto.Snack.SnackId))
                .ForMember(x => x.SnackProducts, c => c.MapFrom(x => x.Snack.Products.Select(cs => cs.Product)))
                .ForMember(x => x.SnackDishes, c => c.MapFrom(x => x.Snack.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.DinnerFridayId, c => c.MapFrom(dto => dto.Dinner.DinnerId))
                .ForMember(x => x.DinnerProducts, c => c.MapFrom(x => x.Dinner.Products.Select(cs => cs.Product)))
                .ForMember(x => x.DinnerDishes, c => c.MapFrom(x => x.Dinner.Dishes.Select(cs => cs.Dish)));

            CreateMap<Saturday, SaturdayDto>()
                .ForMember(dto => dto.BreakfastSaturdayId, c => c.MapFrom(dto => dto.Breakfast.BreakfastId))
                .ForMember(x => x.BreakfastProducts, c => c.MapFrom(x => x.Breakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.BreakfastDishes, c => c.MapFrom(x => x.Breakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SecondBreakfastSaturdayId, c => c.MapFrom(dto => dto.SecondBreakfast.SecondBreakfastId))
                .ForMember(x => x.SecondBreakfastProducts, c => c.MapFrom(x => x.SecondBreakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.SecondBreakfastDishes, c => c.MapFrom(x => x.SecondBreakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.LunchSaturdayId, c => c.MapFrom(dto => dto.Lunch.LunchId))
                .ForMember(x => x.LunchProducts, c => c.MapFrom(x => x.Lunch.Products.Select(cs => cs.Product)))
                .ForMember(x => x.LunchDishes, c => c.MapFrom(x => x.Lunch.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SnackSaturdayId, c => c.MapFrom(dto => dto.Snack.SnackId))
                .ForMember(x => x.SnackProducts, c => c.MapFrom(x => x.Snack.Products.Select(cs => cs.Product)))
                .ForMember(x => x.SnackDishes, c => c.MapFrom(x => x.Snack.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.DinnerSaturdayId, c => c.MapFrom(dto => dto.Dinner.DinnerId))
                .ForMember(x => x.DinnerProducts, c => c.MapFrom(x => x.Dinner.Products.Select(cs => cs.Product)))
                .ForMember(x => x.DinnerDishes, c => c.MapFrom(x => x.Dinner.Dishes.Select(cs => cs.Dish)));

            CreateMap<Sunday, SundayDto>()
                .ForMember(dto => dto.BreakfastSundayId, c => c.MapFrom(dto => dto.Breakfast.BreakfastId))
                .ForMember(x => x.BreakfastProducts, c => c.MapFrom(x => x.Breakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.BreakfastDishes, c => c.MapFrom(x => x.Breakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SecondBreakfastSundayId, c => c.MapFrom(dto => dto.SecondBreakfast.SecondBreakfastId))
                .ForMember(x => x.SecondBreakfastProducts, c => c.MapFrom(x => x.SecondBreakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.SecondBreakfastDishes, c => c.MapFrom(x => x.SecondBreakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.LunchSundayId, c => c.MapFrom(dto => dto.Lunch.LunchId))
                .ForMember(x => x.LunchProducts, c => c.MapFrom(x => x.Lunch.Products.Select(cs => cs.Product)))
                .ForMember(x => x.LunchDishes, c => c.MapFrom(x => x.Lunch.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SnackSundayId, c => c.MapFrom(dto => dto.Snack.SnackId))
                .ForMember(x => x.SnackProducts, c => c.MapFrom(x => x.Snack.Products.Select(cs => cs.Product)))
                .ForMember(x => x.SnackDishes, c => c.MapFrom(x => x.Snack.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.DinnerSundayId, c => c.MapFrom(dto => dto.Dinner.DinnerId))
                .ForMember(x => x.DinnerProducts, c => c.MapFrom(x => x.Dinner.Products.Select(cs => cs.Product)))
                .ForMember(x => x.DinnerDishes, c => c.MapFrom(x => x.Dinner.Dishes.Select(cs => cs.Dish)));

            CreateMap<Menu, MenuDto>()
                .ForMember(dto => dto.BreakfastMondayId, c => c.MapFrom(dto => dto.Monday.Breakfast.BreakfastId))
                .ForMember(x => x.MondayBreakfastProducts, c => c.MapFrom(x => x.Monday.Breakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.MondayBreakfastDishes, c => c.MapFrom(x => x.Monday.Breakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SecondBreakfastMondayId, c => c.MapFrom(dto => dto.Monday.SecondBreakfast.SecondBreakfastId))
                .ForMember(x => x.MondaySecondBreakfastProducts, c => c.MapFrom(x => x.Monday.SecondBreakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.MondaySecondBreakfastDishes, c => c.MapFrom(x => x.Monday.SecondBreakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.LunchMondayId, c => c.MapFrom(dto => dto.Monday.Lunch.LunchId))
                .ForMember(x => x.MondayLunchProducts, c => c.MapFrom(x => x.Monday.Lunch.Products.Select(cs => cs.Product)))
                .ForMember(x => x.MondayLunchDishes, c => c.MapFrom(x => x.Monday.Lunch.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SnackMondayId, c => c.MapFrom(dto => dto.Monday.Snack.SnackId))
                .ForMember(x => x.MondaySnackProducts, c => c.MapFrom(x => x.Monday.Snack.Products.Select(cs => cs.Product)))
                .ForMember(x => x.MondaySnackDishes, c => c.MapFrom(x => x.Monday.Snack.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.DinnerMondayId, c => c.MapFrom(dto => dto.Monday.Dinner.DinnerId))
                .ForMember(x => x.MondayDinnerProducts, c => c.MapFrom(x => x.Monday.Dinner.Products.Select(cs => cs.Product)))
                .ForMember(x => x.MondayDinnerDishes, c => c.MapFrom(x => x.Monday.Dinner.Dishes.Select(cs => cs.Dish)))

                .ForMember(dto => dto.BreakfastTuesdayId, c => c.MapFrom(dto => dto.Tuesday.Breakfast.BreakfastId))
                .ForMember(x => x.TuesdayBreakfastProducts, c => c.MapFrom(x => x.Tuesday.Breakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.TuesdayBreakfastDishes, c => c.MapFrom(x => x.Tuesday.Breakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SecondBreakfastTuesdayId, c => c.MapFrom(dto => dto.Tuesday.SecondBreakfast.SecondBreakfastId))
                .ForMember(x => x.TuesdaySecondBreakfastProducts, c => c.MapFrom(x => x.Tuesday.SecondBreakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.TuesdaySecondBreakfastDishes, c => c.MapFrom(x => x.Tuesday.SecondBreakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.LunchTuesdayId, c => c.MapFrom(dto => dto.Tuesday.Lunch.LunchId))
                .ForMember(x => x.TuesdayLunchProducts, c => c.MapFrom(x => x.Tuesday.Lunch.Products.Select(cs => cs.Product)))
                .ForMember(x => x.TuesdayLunchDishes, c => c.MapFrom(x => x.Tuesday.Lunch.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SnackTuesdayId, c => c.MapFrom(dto => dto.Tuesday.Snack.SnackId))
                .ForMember(x => x.TuesdaySnackProducts, c => c.MapFrom(x => x.Tuesday.Snack.Products.Select(cs => cs.Product)))
                .ForMember(x => x.TuesdaySnackDishes, c => c.MapFrom(x => x.Tuesday.Snack.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.DinnerTuesdayId, c => c.MapFrom(dto => dto.Tuesday.Dinner.DinnerId))
                .ForMember(x => x.TuesdayDinnerProducts, c => c.MapFrom(x => x.Tuesday.Dinner.Products.Select(cs => cs.Product)))
                .ForMember(x => x.TuesdayDinnerDishes, c => c.MapFrom(x => x.Tuesday.Dinner.Dishes.Select(cs => cs.Dish)))

                .ForMember(dto => dto.BreakfastWednesdayId, c => c.MapFrom(dto => dto.Wednesday.Breakfast.BreakfastId))
                .ForMember(x => x.WednesdayBreakfastProducts, c => c.MapFrom(x => x.Wednesday.Breakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.WednesdayBreakfastDishes, c => c.MapFrom(x => x.Wednesday.Breakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SecondBreakfastWednesdayId, c => c.MapFrom(dto => dto.Wednesday.SecondBreakfast.SecondBreakfastId))
                .ForMember(x => x.WednesdaySecondBreakfastProducts, c => c.MapFrom(x => x.Wednesday.SecondBreakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.WednesdaySecondBreakfastDishes, c => c.MapFrom(x => x.Wednesday.SecondBreakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.LunchWednesdayId, c => c.MapFrom(dto => dto.Wednesday.Lunch.LunchId))
                .ForMember(x => x.WednesdayLunchProducts, c => c.MapFrom(x => x.Wednesday.Lunch.Products.Select(cs => cs.Product)))
                .ForMember(x => x.WednesdayLunchDishes, c => c.MapFrom(x => x.Wednesday.Lunch.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SnackWednesdayId, c => c.MapFrom(dto => dto.Wednesday.Snack.SnackId))
                .ForMember(x => x.WednesdaySnackProducts, c => c.MapFrom(x => x.Wednesday.Snack.Products.Select(cs => cs.Product)))
                .ForMember(x => x.WednesdaySnackDishes, c => c.MapFrom(x => x.Wednesday.Snack.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.DinnerWednesdayId, c => c.MapFrom(dto => dto.Wednesday.Dinner.DinnerId))
                .ForMember(x => x.WednesdayDinnerProducts, c => c.MapFrom(x => x.Wednesday.Dinner.Products.Select(cs => cs.Product)))
                .ForMember(x => x.WednesdayDinnerDishes, c => c.MapFrom(x => x.Wednesday.Dinner.Dishes.Select(cs => cs.Dish)))

                .ForMember(dto => dto.BreakfastThursdayId, c => c.MapFrom(dto => dto.Thursday.Breakfast.BreakfastId))
                .ForMember(x => x.ThursdayBreakfastProducts, c => c.MapFrom(x => x.Thursday.Breakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.ThursdayBreakfastDishes, c => c.MapFrom(x => x.Thursday.Breakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SecondBreakfastThursdayId, c => c.MapFrom(dto => dto.Thursday.SecondBreakfast.SecondBreakfastId))
                .ForMember(x => x.ThursdaySecondBreakfastProducts, c => c.MapFrom(x => x.Thursday.SecondBreakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.ThursdaySecondBreakfastDishes, c => c.MapFrom(x => x.Thursday.SecondBreakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.LunchThursdayId, c => c.MapFrom(dto => dto.Thursday.Lunch.LunchId))
                .ForMember(x => x.ThursdayLunchProducts, c => c.MapFrom(x => x.Thursday.Lunch.Products.Select(cs => cs.Product)))
                .ForMember(x => x.ThursdayLunchDishes, c => c.MapFrom(x => x.Thursday.Lunch.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SnackThursdayId, c => c.MapFrom(dto => dto.Thursday.Snack.SnackId))
                .ForMember(x => x.ThursdaySnackProducts, c => c.MapFrom(x => x.Thursday.Snack.Products.Select(cs => cs.Product)))
                .ForMember(x => x.ThursdaySnackDishes, c => c.MapFrom(x => x.Thursday.Snack.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.DinnerThursdayId, c => c.MapFrom(dto => dto.Thursday.Dinner.DinnerId))
                .ForMember(x => x.ThursdayDinnerProducts, c => c.MapFrom(x => x.Thursday.Dinner.Products.Select(cs => cs.Product)))
                .ForMember(x => x.ThursdayDinnerDishes, c => c.MapFrom(x => x.Thursday.Dinner.Dishes.Select(cs => cs.Dish)))

                .ForMember(dto => dto.BreakfastFridayId, c => c.MapFrom(dto => dto.Friday.Breakfast.BreakfastId))
                .ForMember(x => x.FridayBreakfastProducts, c => c.MapFrom(x => x.Friday.Breakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.FridayBreakfastDishes, c => c.MapFrom(x => x.Friday.Breakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SecondBreakfastFridayId, c => c.MapFrom(dto => dto.Friday.SecondBreakfast.SecondBreakfastId))
                .ForMember(x => x.FridaySecondBreakfastProducts, c => c.MapFrom(x => x.Friday.SecondBreakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.FridaySecondBreakfastDishes, c => c.MapFrom(x => x.Friday.SecondBreakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.LunchFridayId, c => c.MapFrom(dto => dto.Friday.Lunch.LunchId))
                .ForMember(x => x.FridayLunchProducts, c => c.MapFrom(x => x.Friday.Lunch.Products.Select(cs => cs.Product)))
                .ForMember(x => x.FridayLunchDishes, c => c.MapFrom(x => x.Friday.Lunch.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SnackFridayId, c => c.MapFrom(dto => dto.Friday.Snack.SnackId))
                .ForMember(x => x.FridaySnackProducts, c => c.MapFrom(x => x.Friday.Snack.Products.Select(cs => cs.Product)))
                .ForMember(x => x.FridaySnackDishes, c => c.MapFrom(x => x.Friday.Snack.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.DinnerFridayId, c => c.MapFrom(dto => dto.Friday.Dinner.DinnerId))
                .ForMember(x => x.FridayDinnerProducts, c => c.MapFrom(x => x.Friday.Dinner.Products.Select(cs => cs.Product)))
                .ForMember(x => x.FridayDinnerDishes, c => c.MapFrom(x => x.Friday.Dinner.Dishes.Select(cs => cs.Dish)))

                .ForMember(dto => dto.BreakfastSaturdayId, c => c.MapFrom(dto => dto.Saturday.Breakfast.BreakfastId))
                .ForMember(x => x.SaturdayBreakfastProducts, c => c.MapFrom(x => x.Saturday.Breakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.SaturdayBreakfastDishes, c => c.MapFrom(x => x.Saturday.Breakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SecondBreakfastSaturdayId, c => c.MapFrom(dto => dto.Saturday.SecondBreakfast.SecondBreakfastId))
                .ForMember(x => x.SaturdaySecondBreakfastProducts, c => c.MapFrom(x => x.Saturday.SecondBreakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.SaturdaySecondBreakfastDishes, c => c.MapFrom(x => x.Saturday.SecondBreakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.LunchSaturdayId, c => c.MapFrom(dto => dto.Saturday.Lunch.LunchId))
                .ForMember(x => x.SaturdayLunchProducts, c => c.MapFrom(x => x.Saturday.Lunch.Products.Select(cs => cs.Product)))
                .ForMember(x => x.SaturdayLunchDishes, c => c.MapFrom(x => x.Saturday.Lunch.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SnackSaturdayId, c => c.MapFrom(dto => dto.Saturday.Snack.SnackId))
                .ForMember(x => x.SaturdaySnackProducts, c => c.MapFrom(x => x.Saturday.Snack.Products.Select(cs => cs.Product)))
                .ForMember(x => x.SaturdaySnackDishes, c => c.MapFrom(x => x.Saturday.Snack.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.DinnerSaturdayId, c => c.MapFrom(dto => dto.Saturday.Dinner.DinnerId))
                .ForMember(x => x.SaturdayDinnerProducts, c => c.MapFrom(x => x.Saturday.Dinner.Products.Select(cs => cs.Product)))
                .ForMember(x => x.SaturdayDinnerDishes, c => c.MapFrom(x => x.Saturday.Dinner.Dishes.Select(cs => cs.Dish)))

                .ForMember(dto => dto.BreakfastSundayId, c => c.MapFrom(dto => dto.Sunday.Breakfast.BreakfastId))
                .ForMember(x => x.SundayBreakfastProducts, c => c.MapFrom(x => x.Sunday.Breakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.SundayBreakfastDishes, c => c.MapFrom(x => x.Sunday.Breakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SecondBreakfastSundayId, c => c.MapFrom(dto => dto.Sunday.SecondBreakfast.SecondBreakfastId))
                .ForMember(x => x.SundaySecondBreakfastProducts, c => c.MapFrom(x => x.Sunday.SecondBreakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.SundaySecondBreakfastDishes, c => c.MapFrom(x => x.Sunday.SecondBreakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.LunchSundayId, c => c.MapFrom(dto => dto.Sunday.Lunch.LunchId))
                .ForMember(x => x.SundayLunchProducts, c => c.MapFrom(x => x.Sunday.Lunch.Products.Select(cs => cs.Product)))
                .ForMember(x => x.SundayLunchDishes, c => c.MapFrom(x => x.Sunday.Lunch.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SnackSundayId, c => c.MapFrom(dto => dto.Sunday.Snack.SnackId))
                .ForMember(x => x.SundaySnackProducts, c => c.MapFrom(x => x.Sunday.Snack.Products.Select(cs => cs.Product)))
                .ForMember(x => x.SundaySnackDishes, c => c.MapFrom(x => x.Sunday.Snack.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.DinnerSundayId, c => c.MapFrom(dto => dto.Sunday.Dinner.DinnerId))
                .ForMember(x => x.SundayDinnerProducts, c => c.MapFrom(x => x.Sunday.Dinner.Products.Select(cs => cs.Product)))
                .ForMember(x => x.SundayDinnerDishes, c => c.MapFrom(x => x.Sunday.Dinner.Dishes.Select(cs => cs.Dish)));


            CreateMap<UpdateProductDto, Product>();
            CreateMap<UpdateDishDto, Dish>();
            CreateMap<UpdateMenuDto, Menu>();

            CreateMap<UpdateMondayDto, Monday>();
            CreateMap<UpdateTuesdayDto, Tuesday>();
            CreateMap<UpdateWednesdayDto, Wednesday>();
            CreateMap<UpdateThursdayDto, Thursday>();
            CreateMap<UpdateFridayDto, Friday>();
            CreateMap<UpdateSaturdayDto, Saturday>();
            CreateMap<UpdateSundayDto, Sunday>();

            CreateMap<UpdateBreakfastDto, Breakfast>();
            CreateMap<UpdateSecondBreakfastDto, SecondBreakfast>();
            CreateMap<UpdateLunchDto, Lunch>();
            CreateMap<UpdateSnackDto, Snack>();
            CreateMap<UpdateDinnerDto, Dinner>();

            CreateMap<CreateProductDto, Product>();
            CreateMap<CreateDishDto, Dish>();

            CreateMap<CreateBreakfastDto, Breakfast>();
            CreateMap<CreateSecondBreakfastDto, SecondBreakfast>();
            CreateMap<CreateLunchDto, Lunch>();
            CreateMap<CreateSnackDto, Snack>();
            CreateMap<CreateDinnerDto, Dinner>();

            CreateMap<CreateMondayDto, Monday>();
            CreateMap<CreateTuesdayDto, Tuesday>();
            CreateMap<CreateWednesdayDto, Wednesday>();
            CreateMap<CreateThursdayDto, Thursday>();
            CreateMap<CreateFridayDto, Friday>();
            CreateMap<CreateSaturdayDto, Saturday>();
            CreateMap<CreateSundayDto, Sunday>();

            CreateMap<CreateMenuDto, Menu>();
        }
    }
}
