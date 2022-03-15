using Papu.Models;
using Papu.Models.Update;
using System.Collections.Generic;

namespace Papu.Services
{
    public interface IDishService
    {
        IEnumerable<DishDto> GetAllDishes();
        DishDto GetByIdDish(int id);
        int CreateDish(CreateDishDto dto);
        bool UpdateDish(int id, UpdateDishDto dto);
        bool DeleteDish(int id);
    }
}
