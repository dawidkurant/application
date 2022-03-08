using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Papu.Entities;
using Papu.Models;
using System.Collections.Generic;
using System.Linq;

namespace Papu.Services
{
    public class ProductService : IProductService
    {
        private readonly PapuDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductService(PapuDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

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

        public int CreateProduct(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);

            Category category = _dbContext.Categories
                .FirstOrDefault(c => c.CategoryName == dto.CategoryName);

            Unit unit = _dbContext.Units
               .FirstOrDefault(c => c.UnitName == dto.UnitName);

            product.Category = category;
            product.Unit = unit;

            Product product2 = _dbContext.Products
                    .Include(c => c.ProductGroups).ThenInclude(cs => cs.Group)
                    .FirstOrDefault(c => c.ProductId == product.ProductId);

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

        public bool DeleteProduct(int id)
        {
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
