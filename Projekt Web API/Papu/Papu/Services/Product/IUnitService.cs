using Papu.Models.Product;
using System.Collections.Generic;

namespace Papu.Services
{
    public interface IUnitService
    {
        IEnumerable<UnitDto> GetAllUnits();
        UnitDto GetByIdUnit(int id);
    }
}
