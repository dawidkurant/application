using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papu.Models;
using Papu.Services;
using System.Collections.Generic;

namespace Papu.Controllers
{
    [Route("api")]
    [ApiController]
    // Atrybut potrzebny aby dane akcje były zablokowane przed niezalogowanymi użytkownikami
    // [Authorize]
    public class MealController : ControllerBase
    {
        private readonly IMealService _mealsService;

        public MealController(IMealService meals)
        {
            _mealsService = meals;
        }

        // Pobranie konkretnego posiłku 
        [HttpGet("meal/{id}")]
        // Ta akcja nie wymaga autoryzacji
        [AllowAnonymous]
        public ActionResult<MealDto> GetOneMeal([FromRoute] int id)
        {
            var meal = _mealsService.GetByIdMeal(id);

            return Ok(meal);
        }

        // Pobranie wszystkich posiłków z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet("meal")]
        public ActionResult<IEnumerable<MealDto>> GetAllMeals()
        {
            var mealsDtos = _mealsService.GetAllMeal();

            return Ok(mealsDtos);
        }

        // Tworzenie nowego posiłku
        [HttpPost("createmeal")]
        public ActionResult CreateMeal([FromBody] CreateMealDto dtoMeal)
        {
            var newMealId = _mealsService.CreateMeal(dtoMeal);

            // Jako pierwszy parametr ścieżka, a jako drugi
            // możemy zwrócić ciało odpowiedzi, ale w tym wypadku zwracamy null
            return Created($"api/meal/{newMealId}", null);
        }

        // Edycja posiłku
        [HttpPut("meal/{id}")]
        public ActionResult UpdateMeal([FromBody] UpdateMealDto dto, [FromRoute] int id)
        {
            _mealsService.UpdateMeal(id, dto);

            return Ok();
        }

        // Usuwanie konkretnego posiłku
        [HttpDelete("meal/{id}")]
        public ActionResult DeleteMeal([FromRoute] int id)
        {
            _mealsService.DeleteMeal(id);

            // operacja zakończona sukcesem
            return NoContent();
        }
    }
}
