using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Papu.Authorization;
using Papu.Entities;
using Papu.Exceptions;
using Papu.Models;
using System.Collections.Generic;
using System.Linq;

namespace Papu.Services
{
    public class MealService : IMealService
    {
        private readonly PapuDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<MealService> _logger;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;

        public MealService(PapuDbContext dbContext, IMapper mapper, ILogger<MealService> logger,
            IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }

        // Wyświetlanie jednego posiłku
        public MealDto GetByIdMeal(int id)
        {
            Meal meal = _dbContext
                .Meals
                .Include(c => c.ProductMeals).ThenInclude(cs => cs.Product)
                .Include(c => c.DishMeals).ThenInclude(cs => cs.Dish).ThenInclude(css => css.DishProducts).ThenInclude(csss => csss.Product)
                .FirstOrDefault(c => c.MealId == id) ?? throw new NotFoundException("Meal not found");
               
            var result = _mapper.Map<MealDto>(meal);

            return result;
        }

        // Wyświetlanie wszystkich posiłków
        public IEnumerable<MealDto> GetAllMeal()
        {
            var meals = _dbContext
                .Meals
                .Include(c => c.DishMeals).ThenInclude(cs => cs.Dish).ThenInclude(css => css.DishProducts).ThenInclude(csss => csss.Product)
                .Include(c => c.ProductMeals).ThenInclude(cs => cs.Product)
                .ToList();

            var mealsDto = _mapper.Map<List<MealDto>>(meals);

            return mealsDto;
        }

        // Tworzenie nowego posiłku 
        public int CreateMeal(CreateMealDto dtoMeal)
        {
            var meal = _mapper.Map<Meal>(dtoMeal);

            // Dostaniemy informację jaki użytkownik stworzył konkretny posiłek w bazie danych
            meal.CreatedById = _userContextService.GetUserId;

            if (dtoMeal.ProductId is null)
            {
                dtoMeal.ProductId = new int[] { 1 };
            }

            foreach (var addProduct in dtoMeal.ProductId)
            {

                Product product = _dbContext.Products
                    .FirstOrDefault(s => s.ProductId == addProduct);

                ProductMeal productMeal = new()
                {
                    Meal = meal,
                    Product = product
                };

                _dbContext.ProductMeals.Add(productMeal);

            }

            if (dtoMeal.DishId is null)
            {
                dtoMeal.DishId = new int[] { 1 };
            }

            foreach (var addDish in dtoMeal.DishId)
            {

                Dish dish = _dbContext.Dishes
                    .FirstOrDefault(s => s.DishId == addDish);

                DishMeal dishMeal = new()
                {
                    Dish = dish,
                    Meal = meal
                };

                _dbContext.DishMeals.Add(dishMeal);
            }


            _dbContext.SaveChanges();

            return meal.MealId;
        }

        // Edycja posiłku
        public void UpdateMeal(int id, UpdateMealDto dtoMeal)
        {
            var meal = _dbContext
                .Meals
                .Include(c => c.ProductMeals).ThenInclude(cs => cs.Product)
                .Include(c => c.DishMeals).ThenInclude(cs => cs.Dish).ThenInclude(css => css.DishProducts).ThenInclude(csss => csss.Product)
                .FirstOrDefault(c => c.MealId == id) ?? throw new NotFoundException("Meal not found");

            // Sprawdzamy czy to użytkownik który stworzył dany posiłek chce go zmodyfikować
            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User,
                meal, new ResourceOperationRequirement(ResourceOperation.Update)).Result;

            // Sprawdzamy czy autoryzacja użytkownika nie powiodła się
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("This meal is not your");
            }

            foreach (var old in meal.ProductMeals)
            {
                _dbContext.ProductMeals.Remove(old);
            }

            meal.ProductMeals.Clear();

            foreach (var addProduct in dtoMeal.ProductId)
            {

                Product product = _dbContext.Products
                    .FirstOrDefault(s => s.ProductId == addProduct);

                ProductMeal productMeal = new()
                {
                    Meal = meal,
                    Product = product
                };

                _dbContext.ProductMeals.Add(productMeal);

            }

            foreach (var old in meal.DishMeals)
            {
                _dbContext.DishMeals.Remove(old);
            }

            meal.ProductMeals.Clear();

            foreach (var addDish in dtoMeal.DishId)
            {

                Dish dish = _dbContext.Dishes
                    .FirstOrDefault(s => s.DishId == addDish);

                DishMeal dishMeal = new()
                {
                    Dish = dish,
                    Meal = meal
                };

                _dbContext.DishMeals.Add(dishMeal);
            }

            _dbContext.SaveChanges();
        }

        // Usuwanie posiłku
        public void DeleteMeal(int id)
        {
            _logger.LogError($"Meal with id: {id} DELETE action invoked");

            var meal =
                _dbContext
                .Meals
                .Include(c => c.ProductMeals).ThenInclude(cs => cs.Product)
                .Include(c => c.DishMeals).ThenInclude(cs => cs.Dish).ThenInclude(css => css.DishProducts).ThenInclude(csss => csss.Product)
                .FirstOrDefault(c => c.MealId == id) ?? throw new NotFoundException("Meal not found");

            // Sprawdzamy czy to użytkownik który stworzył dany posiłek chce go zmodyfikować
            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User,
                meal, new ResourceOperationRequirement(ResourceOperation.Delete)).Result;

            // Sprawdzamy czy autoryzacja użytkownika nie powiodła się
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("This meal is not your");
            }

            _dbContext.Meals.Remove(meal);
            _dbContext.SaveChanges();
        }
    }
}
