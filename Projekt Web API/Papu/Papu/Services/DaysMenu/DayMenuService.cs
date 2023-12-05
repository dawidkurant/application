using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Papu.Authorization;
using Papu.Entities;
using Papu.Exceptions;
using Papu.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Papu.Services
{
    public class DayMenuService : IDayMenuService
    {
        private readonly PapuDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<DayMenuService> _logger;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;

        public DayMenuService(PapuDbContext dbContext, IMapper mapper, ILogger<DayMenuService> logger,
            IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }

        // Wyświetlanie jednego dnia
        public DayMenuDto GetByIdDayMenu(int id)
        {
            DayMenu dayMenu = _dbContext
                .DaysMenu
                .Include(c => c.Meals)
                    .ThenInclude(cs => cs.ProductMeals)
                        .ThenInclude(css => css.Product)
                .Include(c => c.Meals)
                    .ThenInclude(cs => cs.DishMeals)
                        .ThenInclude(css => css.Dish)
                            .ThenInclude(csss => csss.DishProducts)
                                .ThenInclude(cssss => cssss.Product)
                .FirstOrDefault(c => c.DayMenuId == id) ?? throw new NotFoundException("Day menu not found");

            var result = _mapper.Map<DayMenuDto>(dayMenu);
            return result;
        }

        // Wyświetlanie wszystkich dni
        public IEnumerable<DayMenuDto> GetAllDayMenu()
        {
            var daysMenu = _dbContext
                .DaysMenu
                .Include(c => c.Meals)
                    .ThenInclude(cs => cs.ProductMeals)
                        .ThenInclude(css => css.Product)
                .Include(c => c.Meals)
                    .ThenInclude(cs => cs.DishMeals)
                        .ThenInclude(css => css.Dish)
                            .ThenInclude(csss => csss.DishProducts)
                                .ThenInclude(cssss => cssss.Product)
                .ToList();

            var daysMenuDto = _mapper.Map<List<DayMenuDto>>(daysMenu);

            return daysMenuDto;
        }

        // Tworzenie nowego dnia 
        public int CreateDayMenu(CreateDayMenuDto dtoDayMenu)
        {
            var dayMenu = _mapper.Map<DayMenu>(dtoDayMenu);
            dayMenu.Meals = new List<Meal>(); // Inicjalizacja listy posiłków dla danego dnia 

            // Dostaniemy informację jaki użytkownik stworzył konkretny dzień w bazie danych
            dayMenu.CreatedById = 1;

            if (dtoDayMenu.MealId is null)
            {
                dtoDayMenu.MealId = new int[] { 1 };
            }

            foreach (var addMeal in dtoDayMenu.MealId)
            {
                Meal meal = _dbContext.Meals
                    .FirstOrDefault(s => s.MealId == addMeal);

                //ProductMeal productMeal = _dbContext.ProductMeals
                //    .FirstOrDefault(s => s.MealId == meal.MealId);

                //DishMeal dishMeal = _dbContext.DishMeals
                //    .FirstOrDefault(s => s.MealId == meal.MealId);

                dayMenu.Meals.Add(meal);

                var productMeals = _dbContext.ProductMeals.FirstOrDefault(p => p.MealId == meal.MealId);
                var dishMeals = _dbContext.DishMeals.FirstOrDefault(d => d.MealId == meal.MealId);

                if (productMeals is null)
                {
                    Product rescueProduct = _dbContext.Products.FirstOrDefault(s => s.ProductId == 1);

                    ProductMeal rescueProductMeal = new ProductMeal()
                    {
                        Meal = meal,
                        Product = rescueProduct
                    };

                    _dbContext.ProductMeals.Add(rescueProductMeal);
                }

                if (dishMeals is null)
                {
                    Dish rescueDish = _dbContext.Dishes.FirstOrDefault(s => s.DishId == 1);

                    DishMeal rescueDishMeal = new DishMeal()
                    {
                        Meal = meal,
                        Dish = rescueDish
                    };

                    _dbContext.DishMeals.Add(rescueDishMeal);
                }

                meal.DayMenu = dayMenu;

                _dbContext.DaysMenu.Add(dayMenu);
            }

            _dbContext.SaveChanges();

            return dayMenu.DayMenuId;
        }

        // Edycja dnia
        public void UpdateDayMenu(int id, UpdateDayMenuDto dtoDayMenu)
        {
            var dayMenu = _dbContext
                .DaysMenu
                .Include(c => c.Meals)
                    .ThenInclude(cs => cs.ProductMeals)
                        .ThenInclude(css => css.Product)
                .Include(c => c.Meals)
                    .ThenInclude(cs => cs.DishMeals)
                        .ThenInclude(css => css.Dish)
                            .ThenInclude(csss => csss.DishProducts)
                                .ThenInclude(cssss => cssss.Product)
                .FirstOrDefault(c => c.DayMenuId == id) ?? throw new NotFoundException("Day menu not found");

            // Sprawdzamy czy to użytkownik który stworzył dany dzień chce go zmodyfikować
            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User,
                dayMenu, new ResourceOperationRequirement(ResourceOperation.Update)).Result;

            // Sprawdzamy czy autoryzacja użytkownika nie powiodła się
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("This day menu is not your");
            }

            foreach (var old in dayMenu.Meals)
            {
                _dbContext.Meals.Remove(old);
            }

            dayMenu.Meals.Clear();

            foreach (var addMeal in dtoDayMenu.MealId)
            {
                Meal meal = _dbContext.Meals
                    .FirstOrDefault(s => s.MealId == addMeal);

                foreach (var addProduct in meal.ProductMeals)
                {
                    Product product = _dbContext.Products
                        .FirstOrDefault(s => s.ProductId == addProduct.ProductId);

                    ProductMeal productMeal = new()
                    {
                        Meal = meal,
                        Product = product
                    };

                    _dbContext.ProductMeals.Add(productMeal);

                }

                foreach (var addDish in meal.DishMeals)
                {

                    Dish dish = _dbContext.Dishes
                        .FirstOrDefault(s => s.DishId == addDish.DishId);

                    DishMeal dishMeal = new()
                    {
                        Dish = dish,
                        Meal = meal
                    };

                    _dbContext.DishMeals.Add(dishMeal);
                }

                _dbContext.DaysMenu.Add(dayMenu);
            }

            _dbContext.SaveChanges();
        }

        // Usuwanie dnia
        public void DeleteDayMenu(int id)
        {
            _logger.LogError($"Day menu with id: {id} DELETE action invoked");

            var dayMenu = _dbContext
                .DaysMenu
                .Include(c => c.Meals)
                .FirstOrDefault(c => c.DayMenuId == id) ?? throw new NotFoundException("Day menu not found");

            // Sprawdzamy czy to użytkownik który stworzył dany dzień chce go zmodyfikować
            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User,
                dayMenu, new ResourceOperationRequirement(ResourceOperation.Delete)).Result;

            // Sprawdzamy czy autoryzacja użytkownika nie powiodła się
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("This day menu is not your");
            }

            _dbContext.DaysMenu.Remove(dayMenu);
            _dbContext.SaveChanges();
        }
    }
}
