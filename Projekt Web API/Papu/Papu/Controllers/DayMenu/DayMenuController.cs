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
    public class DayMenuController : ControllerBase
    {
        private readonly IDayMenuService _daysMenuService;

        public DayMenuController(IDayMenuService daysMenu)
        {
            _daysMenuService = daysMenu;
        }

        // Pobranie konkretnego dnia 
        [HttpGet("daymenu/{id}")]
        // Ta akcja nie wymaga autoryzacji
        [AllowAnonymous]
        public ActionResult<DayMenuDto> GetOneDayMenu([FromRoute] int id)
        {
            var dayMenu = _daysMenuService.GetByIdDayMenu(id);

            return Ok(dayMenu);
        }

        // Pobranie wszystkich dni z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet("daymenu")]
        public ActionResult<IEnumerable<DayMenuDto>> GetAllDaysMenu()
        {
            var daysMenuDtos = _daysMenuService.GetAllDayMenu();

            return Ok(daysMenuDtos);
        }

        // Tworzenie nowego dnia
        [HttpPost("createdaymenu")]
        public ActionResult CreateDayMenu([FromBody] CreateDayMenuDto dtoDayMenu)
        {
            var newDayMenuId = _daysMenuService.CreateDayMenu(dtoDayMenu);

            // Jako pierwszy parametr ścieżka, a jako drugi
            // możemy zwrócić ciało odpowiedzi, ale w tym wypadku zwracamy null
            return Created($"api/daymenu/{newDayMenuId}", null);
        }

        // Edycja dnia
        [HttpPut("daymenu/{id}")]
        public ActionResult UpdateDayMenu([FromBody] UpdateDayMenuDto dto, [FromRoute] int id)
        {
            _daysMenuService.UpdateDayMenu(id, dto);

            return Ok();
        }

        // Usuwanie konkretnego dnia
        [HttpDelete("daymenu/{id}")]
        public ActionResult DeleteDayMenu([FromRoute] int id)
        {
            _daysMenuService.DeleteDayMenu(id);

            // operacja zakończona sukcesem
            return NoContent();
        }
    }
}
