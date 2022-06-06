using Papu.Models.Dish;
using System.Collections.Generic;

namespace Papu.Services
{
    public interface ITypeService
    {
        IEnumerable<TypeDto> GetAllTypes();
        TypeDto GetByIdType(int id);
    }
}
