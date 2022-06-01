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
using System.Security.Claims;

namespace Papu.Services
{
    public class ProductService : IProductService
    {
        private readonly PapuDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;

        //Dzięki IAuthorization (serwisowi) Asp.Net Core na podstawie wymagania
        //będzie wstanie wywołać odpowiedni handler
        public ProductService(PapuDbContext dbContext, IMapper mapper, ILogger<ProductService> logger, 
            IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
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
                throw new NotFoundException("Product not found");
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
            //Dostaniemy informację jaki użytkownik stworzył konkretny produkt w bazie danych
            product.CreatedById = _userContextService.GetUserId;

            Category category = _dbContext.Categories
                .FirstOrDefault(c => c.CategoryName == dto.CategoryName);

            Unit unit = _dbContext.Units
               .FirstOrDefault(c => c.UnitName == dto.UnitName);

            product.Category = category;
            product.Unit = unit;

            if (dto.GroupId is null)
            {
                dto.GroupId = new int[] { 1 };
            }

            foreach (var addGroup in dto.GroupId)
            {

                Group group = _dbContext.Groups
                    .FirstOrDefault(s => s.GroupId == addGroup);

                ProductGroup productGroup = new()
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
        //Tylko ten kto utworzył dany zasób, będzie mógł go modyfikować lub usuwać
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

            //Sprawdzamy czy to użytkownik który stworzył dany produkt chce go zmodyfikować
            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, 
                product, new ResourceOperationRequirement(ResourceOperation.Update)).Result;

            //Sprawdzamy czy autoryzacja użytkownika nie powiodła się
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("This product is not your");
            }

            Category category = _dbContext.Categories
                .FirstOrDefault(c => c.CategoryName == dto.CategoryName);

            Unit unit = _dbContext.Units
               .FirstOrDefault(c => c.UnitName == dto.UnitName);

            product.ProductName = dto.ProductName;
            product.Category = category;
            product.Unit = unit;
            product.Weight = dto.Weight;
            product.Iron = dto.Iron;
            product.VitaminB12 = dto.VitaminB12;
            product.Folate = dto.Folate;
            product.VitaminD = dto.VitaminD;
            product.Calcium = dto.Calcium;
            product.Magnesium = dto.Magnesium;
            product.ProductImagePath = dto.ProductImagePath;

            foreach (var old in product.ProductGroups)
            {
                _dbContext.ProductGroups.Remove(old);
            }

            product.ProductGroups.Clear();

            if (dto.GroupId is null)
            {
                dto.GroupId = new int[] { 1 };
            }

            foreach (var addGroup in dto.GroupId)
            {

                Group group = _dbContext.Groups
                    .FirstOrDefault(s => s.GroupId == addGroup);

                ProductGroup productGroup = new()
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
        public void DeleteProduct(int id)
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
                throw new NotFoundException("Product not found");
            }

            //Sprawdzamy czy to użytkownik który stworzył dany produkt chce go usunąć
            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User,
                product, new ResourceOperationRequirement(ResourceOperation.Delete)).Result;

            //Sprawdzamy czy autoryzacja użytkownika nie powiodła się
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("This product is not your");
            }

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }
    }
}