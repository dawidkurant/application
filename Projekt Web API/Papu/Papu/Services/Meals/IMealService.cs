using Papu.Models;
using System.Collections.Generic;

namespace Papu.Services
{
    public interface IMealService
    {
        MealDto GetByIdMeal(int id);
        IEnumerable<MealDto> GetAllMeal();
        int CreateMeal(CreateMealDto dtoMeal);
        void UpdateMeal(int id, UpdateMealDto dtoMeal);
        void DeleteMeal(int id);
    }
}
