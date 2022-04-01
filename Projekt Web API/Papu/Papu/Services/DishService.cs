using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Papu.Authorization;
using Papu.Entities;
using Papu.Exceptions;
using Papu.Models;
using Papu.Models.Update;
using System.Collections.Generic;
using System.Linq;

namespace Papu.Services
{
    public class DishService : IDishService
    {
        private readonly PapuDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<DishService> _logger;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;

        public DishService(PapuDbContext dbContext, IMapper mapper, ILogger<DishService> logger, 
            IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }

        //Pobranie jednej potrawy po id 
        public DishDto GetByIdDish(int id)
        {
            Dish dish = _dbContext
                .Dishes
                .Include(c => c.DishKindsOf).ThenInclude(cs => cs.KindOf)
                .Include(c => c.DishTypes).ThenInclude(cs => cs.Type)
                .Include(c => c.DishProducts).ThenInclude(cs => cs.Product)
                .FirstOrDefault(c => c.DishId == id);


            if (dish is null)
            {
                throw new NotFoundException("Dish not found");
            }

            var result = _mapper.Map<DishDto>(dish);

            return result;
        }

        //Pobieranie wszystkich potraw z bazy danych
        public IEnumerable<DishDto> GetAllDishes()
        {
            var dishes = _dbContext
                .Dishes
                .Include(c => c.DishKindsOf).ThenInclude(cs => cs.KindOf)
                .Include(c => c.DishTypes).ThenInclude(cs => cs.Type)
                .Include(c => c.DishProducts).ThenInclude(cs => cs.Product)
                .ToList();

            var dishesDtos = _mapper.Map<List<DishDto>>(dishes);

            return dishesDtos;
        }

        //Utworzenie jednej potrawy na podstawie obiektu dto 
        public int CreateDish(CreateDishDto dto)
        {
            var dish = _mapper.Map<Dish>(dto);
            //Dostaniemy informację jaki użytkownik stworzył konkretną potrawę w bazie danych
            dish.CreatedById = _userContextService.GetUserId;

            if (dto.TypeId is null)
            {
                dto.TypeId = new int[] { 1 };
            }

            foreach (var addType in dto.TypeId)
            {

                Type type = _dbContext.Types
                    .FirstOrDefault(s => s.TypeId == addType);

                DishType dishType = new()
                {
                    Dish = dish,
                    Type = type
                };

                _dbContext.DishTypes.Add(dishType);
            }

            if (dto.KindOfId is null)
            {
                dto.KindOfId = new int[] { 1 };
            }

            foreach (var addKindOf in dto.KindOfId)
            {

                KindOf kindOf = _dbContext.KindsOf
                    .FirstOrDefault(s => s.KindOfId == addKindOf);

                DishKindOf dishKindOf = new()
                {
                    Dish = dish,
                    KindOf = kindOf
                };

                _dbContext.DishKindsOf.Add(dishKindOf);
            }

            if (dto.ProductId is null)
            {
                dto.ProductId = new int[] { 1 };
            }

            foreach (var addProduct in dto.ProductId)
            {

                Product product = _dbContext.Products
                    .FirstOrDefault(s => s.ProductId == addProduct);

                ProductDish productDish = new()
                {
                    Dish = dish,
                    Product = product
                };

                _dbContext.DishProducts.Add(productDish);
            }
            if (dish is null)
            {

            }

            _dbContext.SaveChanges();

            return dish.DishId;
        }

        //Edycja jednej potrawy na podstawie id i obiektu dto
        //tylko ten kto utworzył dany zasób, będzie mógł go modyfikować lub usuwać
        public void UpdateDish(int id, UpdateDishDto dto)
        {
            var dish = _dbContext
                .Dishes
                .Include(c => c.DishKindsOf).ThenInclude(cs => cs.KindOf)
                .Include(c => c.DishTypes).ThenInclude(cs => cs.Type)
                .Include(c => c.DishProducts).ThenInclude(cs => cs.Product)
                .FirstOrDefault(c => c.DishId == id);

            //Jeśli jesteśmy pewni, że dana potrawa nie istnieje, zwracamy wyjątek
            if (dish is null)
            {
                throw new NotFoundException("Dish not found");
            }

            //Sprawdzamy czy to użytkownik który stworzył daną potrawę chce ją zmodyfikować
            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User,
                dish, new ResourceOperationRequirement(ResourceOperation.Update)).Result;

            //Sprawdzamy czy autoryzacja użytkownika nie powiodła się
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("This dish is not your");
            }

            dish.DishName = dto.DishName;
            dish.DishDescription = dto.DishDescription;
            dish.MethodOfPeparation = dto.MethodOfPeparation;
            dish.Portions = dto.Portions;
            dish.PreparationTime = dto.PreparationTime;
            dish.Size = dto.Size;
            dish.DishImagePath = dto.DishImagePath;

            foreach (var old in dish.DishTypes)
            {
                _dbContext.DishTypes.Remove(old);
            }

            dish.DishTypes.Clear();

            foreach (var addType in dto.TypeId)
            {

                Type type = _dbContext.Types
                    .FirstOrDefault(s => s.TypeId == addType);

                DishType dishType = new()
                {
                    Dish = dish,
                    Type = type
                };

                _dbContext.DishTypes.Add(dishType);
            }

            foreach (var old in dish.DishKindsOf)
            {
                _dbContext.DishKindsOf.Remove(old);
            }

            dish.DishKindsOf.Clear();

            foreach (var addKindOf in dto.KindOfId)
            {

                KindOf kindOf = _dbContext.KindsOf
                    .FirstOrDefault(s => s.KindOfId == addKindOf);

                DishKindOf dishKindOf = new()
                {
                    Dish = dish,
                    KindOf = kindOf
                };

                _dbContext.DishKindsOf.Add(dishKindOf);
            }

            foreach (var old in dish.DishProducts)
            {
                _dbContext.DishProducts.Remove(old);
            }

            dish.DishProducts.Clear();

            foreach (var addProduct in dto.ProductId)
            {

                Product product = _dbContext.Products
                    .FirstOrDefault(s => s.ProductId == addProduct);

                ProductDish productDish = new()
                {
                    Dish = dish,
                    Product = product
                };

                _dbContext.DishProducts.Add(productDish);
            }

            _dbContext.SaveChanges();
        }

        //Usunięcie jednej potrawy na podstawie id
        //tylko ten kto utworzył dany zasób, będzie mógł go modyfikować lub usuwać
        public void DeleteDish(int id)
        {
            _logger.LogError($"Dish with id: {id} DELETE action invoked");

            var dish = _dbContext
                .Dishes
                .Include(c => c.DishKindsOf).ThenInclude(cs => cs.KindOf)
                .Include(c => c.DishTypes).ThenInclude(cs => cs.Type)
                .Include(c => c.DishProducts).ThenInclude(cs => cs.Product)
                .FirstOrDefault(c => c.DishId == id);

            if (dish is null)
            {
                throw new NotFoundException("Dish not found");
            }

            //Sprawdzamy czy to użytkownik który stworzył daną potrawę chce ją zmodyfikować
            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User,
                dish, new ResourceOperationRequirement(ResourceOperation.Delete)).Result;

            //Sprawdzamy czy autoryzacja użytkownika nie powiodła się
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("This dish is not your");
            }

            _dbContext.Dishes.Remove(dish);
            _dbContext.SaveChanges();
        }
    }
}
