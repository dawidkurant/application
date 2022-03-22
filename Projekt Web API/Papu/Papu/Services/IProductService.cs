using Papu.Entities;
using Papu.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace Papu.Services
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAllProducts();
        ProductDto GetByIdProduct(int id);
        int CreateProduct(CreateProductDto dto, int userId);
        void UpdateProduct(int id, UpdateProductDto dto, ClaimsPrincipal user);
        void DeleteProduct(int id, ClaimsPrincipal user);
    }
}