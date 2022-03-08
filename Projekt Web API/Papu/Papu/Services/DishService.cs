using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Papu.Entities;
using Papu.Models;
using System.Collections.Generic;
using System.Linq;

namespace Papu.Services
{
    public class DishService : IDishService
    {
        private readonly PapuDbContext _dbContext;
        private readonly IMapper _mapper;

        public DishService(PapuDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

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
                return null;
            }

            var result = _mapper.Map<DishDto>(dish);

            return result;
        }

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

        public int CreateDish(CreateDishDto dto)
        {
            var dish = _mapper.Map<Dish>(dto);

            Dish dish2 = _dbContext.Dishes
                .Include(c => c.DishKindsOf).ThenInclude(cs => cs.KindOf)
                .Include(c => c.DishTypes).ThenInclude(cs => cs.Type)
                .Include(c => c.DishProducts).ThenInclude(cs => cs.Product)
                .FirstOrDefault(c => c.DishId == dish.DishId);

            foreach (var addType in dto.TypeId)
            {

                Type type = _dbContext.Types
                    .FirstOrDefault(s => s.TypeId == addType);

                DishType dishType = new DishType
                {
                    Dish = dish,
                    Type = type
                };

                _dbContext.DishTypes.Add(dishType);
            }

            foreach (var addKindOf in dto.KindOfId)
            {

                KindOf kindOf = _dbContext.KindsOf
                    .FirstOrDefault(s => s.KindOfId == addKindOf);

                DishKindOf dishKindOf = new DishKindOf
                {
                    Dish = dish,
                    KindOf = kindOf
                };

                _dbContext.DishKindsOf.Add(dishKindOf);
            }

            foreach (var addProduct in dto.ProductId)
            {

                Product product = _dbContext.Products
                    .FirstOrDefault(s => s.ProductId == addProduct);

                ProductDish productDish = new ProductDish
                {
                    Dish = dish,
                    Product = product
                };

                _dbContext.DishProducts.Add(productDish);
            }

            _dbContext.SaveChanges();

            return dish.DishId;
        }

        public bool DeleteDish(int id)
        {
            var dish = _dbContext
                .Dishes
                .Include(c => c.DishKindsOf).ThenInclude(cs => cs.KindOf)
                .Include(c => c.DishTypes).ThenInclude(cs => cs.Type)
                .Include(c => c.DishProducts).ThenInclude(cs => cs.Product)
                .FirstOrDefault(c => c.DishId == id);

            if (dish is null)
            {
                return false;
            }

            _dbContext.Dishes.Remove(dish);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
