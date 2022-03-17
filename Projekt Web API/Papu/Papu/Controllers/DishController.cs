using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Papu.Entities;
using Papu.Models;
using Papu.Models.Update;
using Papu.Services;
using System.Collections.Generic;
using System.Linq;

namespace Papu.Controllers
{
    [Route("api/dish")]
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }

        //Pobranie konkretnej potrawy
        [HttpGet("{id}")]
        public ActionResult<DishDto> GetDish([FromRoute] int id)
        {
            var dish = _dishService.GetByIdDish(id);

            return Ok(dish);
        }

        //Pobranie wszystkich produktów z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet]
        public ActionResult<IEnumerable<DishDto>> GetAllDishes()
        {
            var dishesDtos = _dishService.GetAllDishes();

            return Ok(dishesDtos);
        }

        //Tworzenie nowej potrawy
        [HttpPost]
        public ActionResult CreateDish([FromBody] CreateDishDto dto)
        {
            var newDishId = _dishService.CreateDish(dto);

            //Jako pierwszy parametr ścieżka, a jako drugi
            //możemy zwrócić ciało odpowiedzi, ale w tym wypadku zwracamy null
            return Created($"api/dish/{newDishId}", null);
        }

        //Edycja potrawy
        [HttpPut("{id}")]
        public ActionResult UpdateDish([FromBody] UpdateDishDto dto, [FromRoute] int id)
        {
            _dishService.UpdateDish(id, dto);

            return Ok();
        }

        //Usuwanie potrawy
        [HttpDelete("{id}")]
        public ActionResult DeleteDish([FromRoute] int id)
        {
            _dishService.DeleteDish(id);

            //operacja zakończona sukcesem
            return NoContent();
        }
    }
}
