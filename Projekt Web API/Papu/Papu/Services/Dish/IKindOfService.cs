using Papu.Models.Dish;
using System.Collections.Generic;

namespace Papu.Services
{
    public interface IKindOfService
    {
        IEnumerable<KindOfDto> GetAllKindsOf();
        KindOfDto GetByIdKindOf(int id);
    }
}
