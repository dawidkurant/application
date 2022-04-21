using Papu.Models.Product;
using System.Collections.Generic;

namespace Papu.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAllCategories();
        CategoryDto GetByIdCategory(int id);
    }
}
