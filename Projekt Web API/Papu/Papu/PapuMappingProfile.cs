using AutoMapper;
using Papu.Entities;
using Papu.Models;
using Papu.Models.Dish;
using Papu.Models.Product;
using Papu.Models.TimesOfDay;
using Papu.Models.Update.DayOfTheWeek;
using Papu.Models.Update.TimesOfDay;
using System;
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
            CreateMap<Entities.Type, TypeDto>();

            // Mapowanie dla klas dziedziczących z DayOfTheWeek
            CreateMap<DayOfTheWeek, DaysOfTheWeekDto>()
                .ForMember(dto => dto.BreakfastId, c => c.MapFrom(dto => dto.Breakfast.BreakfastId))
                .ForMember(x => x.BreakfastProducts, c => c.MapFrom(x => x.Breakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.BreakfastDishes, c => c.MapFrom(x => x.Breakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SecondBreakfastId, c => c.MapFrom(dto => dto.SecondBreakfast.SecondBreakfastId))
                .ForMember(x => x.SecondBreakfastProducts, c => c.MapFrom(x => x.SecondBreakfast.Products.Select(cs => cs.Product)))
                .ForMember(x => x.SecondBreakfastDishes, c => c.MapFrom(x => x.SecondBreakfast.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.LunchId, c => c.MapFrom(dto => dto.Lunch.LunchId))
                .ForMember(x => x.LunchProducts, c => c.MapFrom(x => x.Lunch.Products.Select(cs => cs.Product)))
                .ForMember(x => x.LunchDishes, c => c.MapFrom(x => x.Lunch.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.SnackId, c => c.MapFrom(dto => dto.Snack.SnackId))
                .ForMember(x => x.SnackProducts, c => c.MapFrom(x => x.Snack.Products.Select(cs => cs.Product)))
                .ForMember(x => x.SnackDishes, c => c.MapFrom(x => x.Snack.Dishes.Select(cs => cs.Dish)))
                .ForMember(dto => dto.DinnerId, c => c.MapFrom(dto => dto.Dinner.DinnerId))
                .ForMember(x => x.DinnerProducts, c => c.MapFrom(x => x.Dinner.Products.Select(cs => cs.Product)))
                .ForMember(x => x.DinnerDishes, c => c.MapFrom(x => x.Dinner.Dishes.Select(cs => cs.Dish)))
                .IncludeAllDerived();

            // Mapowanie dla klas dziedziczących z TimesOfDay
            CreateMap<TimesOfDay, TimesOfDayDto>()
                .IncludeAllDerived();

            // Mapowanie dla klas dziedziczących z Breakfast
            CreateMap<Breakfast, BreakfastDto>()
                .ForMember(x => x.Products, c => c.MapFrom(x => x.Products.Select(cs => cs.Product)))
                .ForMember(x => x.Dishes, c => c.MapFrom(x => x.Dishes.Select(cs => cs.Dish)))
                .IncludeAllDerived();

            // Mapowanie dla klas dziedziczących z SecondBreakfast
            CreateMap<SecondBreakfast, SecondBreakfastDto>()
                .ForMember(x => x.Products, c => c.MapFrom(x => x.Products.Select(cs => cs.Product)))
                .ForMember(x => x.Dishes, c => c.MapFrom(x => x.Dishes.Select(cs => cs.Dish)))
                .IncludeAllDerived();

            // Mapowanie dla klas dziedziczących z Lunch
            CreateMap<Lunch, LunchDto>()
                .ForMember(x => x.Products, c => c.MapFrom(x => x.Products.Select(cs => cs.Product)))
                .ForMember(x => x.Dishes, c => c.MapFrom(x => x.Dishes.Select(cs => cs.Dish)))
                .IncludeAllDerived();

            // Mapowanie dla klas dziedziczących z Snack
            CreateMap<Snack, SnackDto>()
                .ForMember(x => x.Products, c => c.MapFrom(x => x.Products.Select(cs => cs.Product)))
                .ForMember(x => x.Dishes, c => c.MapFrom(x => x.Dishes.Select(cs => cs.Dish)))
                .IncludeAllDerived();

            // Mapowanie dla klas dziedziczących z Dinner
            CreateMap<Dinner, DinnerDto>()
                .ForMember(x => x.Products, c => c.MapFrom(x => x.Products.Select(cs => cs.Product)))
                .ForMember(x => x.Dishes, c => c.MapFrom(x => x.Dishes.Select(cs => cs.Dish)))
                .IncludeAllDerived();

            CreateMap<Monday, MondayDto>()
                .IncludeBase<DayOfTheWeek, DaysOfTheWeekDto>();

            CreateMap<Tuesday, TuesdayDto>()
                .IncludeBase<DayOfTheWeek, DaysOfTheWeekDto>();

            CreateMap<Wednesday, WednesdayDto>()
                .IncludeBase<DayOfTheWeek, DaysOfTheWeekDto>();

            CreateMap<Thursday, ThursdayDto>()
                .IncludeBase<DayOfTheWeek, DaysOfTheWeekDto>();

            CreateMap<Friday, FridayDto>()
                .IncludeBase<DayOfTheWeek, DaysOfTheWeekDto>();

            CreateMap<Saturday, SaturdayDto>()
                .IncludeBase<DayOfTheWeek, DaysOfTheWeekDto>();

            CreateMap<Sunday, SundayDto>()
                .IncludeBase<DayOfTheWeek, DaysOfTheWeekDto>();

            CreateMap<Menu, MenuDto>()
                .ForMember(dto => dto.MenuId, opt => opt.MapFrom(src => src.MenuId));

            // Tworzymy pętlę dla każdego dnia tygodnia
            for (DayOfWeek dayOfWeek = DayOfWeek.Monday; dayOfWeek <= DayOfWeek.Sunday; dayOfWeek++)
            {
                string dayOfWeekName = dayOfWeek.ToString();

                CreateMap<Menu, MenuDto>()
                    .ForMember(
                        dto => dto.GetType().GetProperty($"{dayOfWeekName}Id").GetValue(dto),
                        opt => opt.MapFrom(src => src.GetType().GetProperty($"{dayOfWeekName}Id").GetValue(src)))
                    .ForMember(
                        dto => dto.GetType().GetProperty($"Breakfast{dayOfWeekName}Id").GetValue(dto),
                        opt => opt.MapFrom(src => src.GetType().GetProperty($"{dayOfWeekName}.BreakfastId").GetValue(src)))
                    .ForMember(
                        dto => dto.GetType().GetProperty($"{dayOfWeekName}BreakfastProducts").GetValue(dto),
                        opt => opt.MapFrom(src => src.GetType().GetProperty($"{dayOfWeekName}.Breakfast.Products").GetValue(src)))
                    .ForMember(
                        dto => dto.GetType().GetProperty($"{dayOfWeekName}BreakfastDishes").GetValue(dto),
                        opt => opt.MapFrom(src => src.GetType().GetProperty($"{dayOfWeekName}.Breakfast.Dishes").GetValue(src)))
                    .ForMember(
                        dto => dto.GetType().GetProperty($"SecondBreakfast{dayOfWeekName}Id").GetValue(dto),
                        opt => opt.MapFrom(src => src.GetType().GetProperty($"{dayOfWeekName}.SecondBreakfastId").GetValue(src)))
                    .ForMember(
                        dto => dto.GetType().GetProperty($"{dayOfWeekName}SecondBreakfastProducts").GetValue(dto),
                        opt => opt.MapFrom(src => src.GetType().GetProperty($"{dayOfWeekName}.SecondBreakfast.Products").GetValue(src)))
                    .ForMember(
                        dto => dto.GetType().GetProperty($"{dayOfWeekName}SecondBreakfastDishes").GetValue(dto),
                        opt => opt.MapFrom(src => src.GetType().GetProperty($"{dayOfWeekName}.SecondBreakfast.Dishes").GetValue(src)))
                    .ForMember(
                        dto => dto.GetType().GetProperty($"Lunch{dayOfWeekName}Id").GetValue(dto),
                        opt => opt.MapFrom(src => src.GetType().GetProperty($"{dayOfWeekName}.LunchId").GetValue(src)))
                    .ForMember(
                        dto => dto.GetType().GetProperty($"{dayOfWeekName}LunchProducts").GetValue(dto),
                        opt => opt.MapFrom(src => src.GetType().GetProperty($"{dayOfWeekName}.Lunch.Products").GetValue(src)))
                    .ForMember(
                        dto => dto.GetType().GetProperty($"{dayOfWeekName}LunchDishes").GetValue(dto),
                        opt => opt.MapFrom(src => src.GetType().GetProperty($"{dayOfWeekName}.Lunch.Dishes").GetValue(src)))
                    .ForMember(
                        dto => dto.GetType().GetProperty($"Snack{dayOfWeekName}Id").GetValue(dto),
                        opt => opt.MapFrom(src => src.GetType().GetProperty($"{dayOfWeekName}.SnackId").GetValue(src)))
                    .ForMember(
                        dto => dto.GetType().GetProperty($"{dayOfWeekName}SnackProducts").GetValue(dto),
                        opt => opt.MapFrom(src => src.GetType().GetProperty($"{dayOfWeekName}.Snack.Products").GetValue(src)))
                    .ForMember(
                        dto => dto.GetType().GetProperty($"{dayOfWeekName}SnackDishes").GetValue(dto),
                        opt => opt.MapFrom(src => src.GetType().GetProperty($"{dayOfWeekName}.Snack.Dishes").GetValue(src)))
                    .ForMember(
                        dto => dto.GetType().GetProperty($"Dinner{dayOfWeekName}Id").GetValue(dto),
                        opt => opt.MapFrom(src => src.GetType().GetProperty($"{dayOfWeekName}.DinnerId").GetValue(src)))
                    .ForMember(
                        dto => dto.GetType().GetProperty($"{dayOfWeekName}DinnerProducts").GetValue(dto),
                        opt => opt.MapFrom(src => src.GetType().GetProperty($"{dayOfWeekName}.Dinner.Products").GetValue(src)))
                    .ForMember(
                        dto => dto.GetType().GetProperty($"{dayOfWeekName}DinnerDishes").GetValue(dto),
                        opt => opt.MapFrom(src => src.GetType().GetProperty($"{dayOfWeekName}.Dinner.Dishes").GetValue(src)));
            }

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
