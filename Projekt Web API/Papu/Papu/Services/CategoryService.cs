using AutoMapper;
using Microsoft.Extensions.Logging;
using Papu.Entities;
using Papu.Exceptions;
using Papu.Models.Product;
using System.Collections.Generic;
using System.Linq;

namespace Papu.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly PapuDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(PapuDbContext dbContext, IMapper mapper, ILogger<CategoryService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        //Pobranie jednej kategorii po id 
        public CategoryDto GetByIdCategory(int id)
        {
            Category category =
                _dbContext.Categories
                .FirstOrDefault(c => c.CategoryId == id);


            if (category is null)
            {
                throw new NotFoundException("Category not found");
            }

            var result = _mapper.Map<CategoryDto>(category);

            return result;
        }

        //Pobieranie wszystkich kategorii z bazy danych
        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var categories = _dbContext
                .Categories
                .ToList();

            var categoriesDtos = _mapper.Map<List<CategoryDto>>(categories);

            return categoriesDtos;
        }
    }
}
