using Papu.Entities;
using Papu.Models;
using System.Collections.Generic;

namespace Papu.Services
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAllProducts();
        ProductDto GetByIdProduct(int id);
        int CreateProduct(CreateProductDto dto);
        bool UpdateProduct(int id, UpdateProductDto dto);
        bool DeleteProduct(int id);
    }
}