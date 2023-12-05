using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papu.Models;
using Papu.Services;
using System.Collections.Generic;

namespace Papu.Controllers
{
    [Route("api/dish")]
    [ApiController]
    // Atrybut potrzebny aby dane akcje były zablokowane przed niezalogowanymi użytkownikami
    // [Authorize]
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }

        // Pobranie konkretnej potrawy
        [HttpGet("{id}")]
        // Ta akcja nie wymaga autoryzacji
        [AllowAnonymous]
        public ActionResult<DishDto> GetDish([FromRoute] int id)
        {
            var dish = _dishService.GetByIdDish(id);

            return Ok(dish);
        }

        // Pobranie wszystkich produktów z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet]
        public ActionResult<IEnumerable<DishDto>> GetAllDishes()
        {
            var dishesDtos = _dishService.GetAllDishes();

            return Ok(dishesDtos);
        }

        // Tworzenie nowej potrawy
        [HttpPost]
        public ActionResult CreateDish([FromBody] CreateDishDto dto)
        {
            var newDishId = _dishService.CreateDish(dto);

            // Jako pierwszy parametr ścieżka, a jako drugi
            // możemy zwrócić ciało odpowiedzi, ale w tym wypadku zwracamy null
            return Created($"api/dish/{newDishId}", null);
        }

        // Edycja potrawy
        [HttpPut("{id}")]
        public ActionResult UpdateDish([FromBody] UpdateDishDto dto, [FromRoute] int id)
        {
            _dishService.UpdateDish(id, dto);

            return Ok();
        }

        // Usuwanie potrawy
        [HttpDelete("{id}")]
        public ActionResult DeleteDish([FromRoute] int id)
        {
            _dishService.DeleteDish(id);

            // operacja zakończona sukcesem
            return NoContent();
        }
    }
}
