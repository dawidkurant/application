using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Papu.Entities;
using Papu.Exceptions;
using Papu.Models;
using System.Collections.Generic;
using System.Linq;

namespace Papu.Services
{
    public class ProductService : IProductService
    {
        private readonly PapuDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;

        public ProductService(PapuDbContext dbContext, IMapper mapper, ILogger<ProductService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        //Pobranie jednego produktu po id 
        public ProductDto GetByIdProduct(int id)
        {
            Product product =
                _dbContext.Products
                .Include(c => c.Category)
                .Include(c => c.Unit)
                .Include(c => c.ProductGroups).ThenInclude(cs => cs.Group)
                .FirstOrDefault(c => c.ProductId == id);


            if (product is null)
            {
                return null;
            }

            var result = _mapper.Map<ProductDto>(product);

            return result;
        }

        //Pobieranie wszystkich produktów z bazy danych
        public IEnumerable<ProductDto> GetAllProducts()
        {
            var products = _dbContext
                .Products
                .Include(c => c.Category)
                .Include(c => c.Unit)
                .Include(c => c.ProductGroups).ThenInclude(cs => cs.Group)
                .ToList();

            var productsDtos = _mapper.Map<List<ProductDto>>(products);

            return productsDtos;
        }

        //Utworzenie jednego produktu na podstawie obiektu dto 
        public int CreateProduct(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);

            Category category = _dbContext.Categories
                .FirstOrDefault(c => c.CategoryName == dto.CategoryName);

            Unit unit = _dbContext.Units
               .FirstOrDefault(c => c.UnitName == dto.UnitName);

            product.Category = category;
            product.Unit = unit;

            foreach (var addGroup in dto.GroupId)
            {

                Group group = _dbContext.Groups
                    .FirstOrDefault(s => s.GroupId == addGroup);

                ProductGroup productGroup = new ProductGroup
                {
                    Product = product,
                    Group = group
                };

                _dbContext.ProductGroups.Add(productGroup);
            }

            _dbContext.SaveChanges();

            return product.ProductId;
        }

        //Edycja jednego produktu na podstawie id i obiektu dto
        //tylko ten kto utworzył dany zasób, będzie mógł go modyfikować lub usuwać
        public void UpdateProduct(int id, UpdateProductDto dto)
        {
            var product =
                _dbContext.Products
                .Include(c => c.Category)
                .Include(c => c.Unit)
                .Include(c => c.ProductGroups).ThenInclude(cs => cs.Group)
                .FirstOrDefault(c => c.ProductId == id);

            //Jeśli jesteśmy pewni, że dany produkt nie istnieje, zwracamy wyjątek
            if (product is null)
            {
                throw new NotFoundException("Product not found");
            }

            Category category = _dbContext.Categories
                .FirstOrDefault(c => c.CategoryName == dto.CategoryName);

            Unit unit = _dbContext.Units
               .FirstOrDefault(c => c.UnitName == dto.UnitName);

            product.ProductName = dto.ProductName;
            product.Category = category;
            product.Unit = unit;
            product.Weight = dto.Weight;
            product.ProductImagePath = dto.ProductImagePath;

            foreach (var old in product.ProductGroups)
            {
                _dbContext.ProductGroups.Remove(old);
            }

            product.ProductGroups.Clear();

            foreach (var addGroup in dto.GroupId)
            {

                Group group = _dbContext.Groups
                    .FirstOrDefault(s => s.GroupId == addGroup);

                ProductGroup productGroup = new ProductGroup
                {
                    Product = product,
                    Group = group
                };

                _dbContext.ProductGroups.Add(productGroup);
            }

            _dbContext.SaveChanges();
        }


        //Usunięcie jednego produktu na podstawie id
        //tylko ten kto utworzył dany zasób, będzie mógł go modyfikować lub usuwać
        public bool DeleteProduct(int id)
        {
            _logger.LogError($"Product with id: {id} DELETE action invoked");

            var product = 
                _dbContext.Products
                .Include(c => c.Category)
                .Include(c => c.Unit)
                .Include(c => c.ProductGroups).ThenInclude(cs => cs.Group)
                .FirstOrDefault(c => c.ProductId == id);

            if (product is null)
            {
                return false;
            }

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();

            return true;
        }
    }
}