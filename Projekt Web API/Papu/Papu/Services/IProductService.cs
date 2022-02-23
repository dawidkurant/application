using Papu.Entities;
using Papu.Models;
using System.Collections.Generic;

namespace Papu.Services
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAllProducts();
        ProductDto GetByIdProduct(int id);
/*        int CreateProductWithGroup(AddGroupToProductDto dto);
        int CreateProductWithCategoryAndUnit(AddCategoryAndUnitToProductDto dto);*/
        int CreateProduct(CreateProductDto dto);
    }
}