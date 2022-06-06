using Papu.Entities;
using Papu.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace Papu.Services
{
    public interface IDishService
    {
        IEnumerable<DishDto> GetAllDishes();
        DishDto GetByIdDish(int id);
        int CreateDish(CreateDishDto dto);
        void UpdateDish(int id, UpdateDishDto dto);
        void DeleteDish(int id);
    }
}
