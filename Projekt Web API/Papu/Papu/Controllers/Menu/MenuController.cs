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
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menusService;

        public MenuController(IMenuService menus)
        {
            _menusService = menus;
        }

        // Pobranie konkretnego jadłospisu 
        [HttpGet("menu/{id}")]
        // Ta akcja nie wymaga autoryzacji
        [AllowAnonymous]
        public ActionResult<MenuDto> GetOneMenu([FromRoute] int id)
        {
            var menu = _menusService.GetByIdMenu(id);

            return Ok(menu);
        }

        // Pobranie wszystkich jadłospisów z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet("menu")]
        public ActionResult<IEnumerable<MenuDto>> GetAllMenus()
        {
            var menusDtos = _menusService.GetAllMenu();

            return Ok(menusDtos);
        }

        // Tworzenie nowego jadłospisu
        [HttpPost("createmenu")]
        public ActionResult CreateMenu([FromBody] CreateMenuDto dtoMenu)
        {
            var newMenuId = _menusService.CreateMenu(dtoMenu);

            // Jako pierwszy parametr ścieżka, a jako drugi
            // możemy zwrócić ciało odpowiedzi, ale w tym wypadku zwracamy null
            return Created($"api/menu/{newMenuId}", null);
        }

        // Edycja jadłospisu
        [HttpPut("menu/{id}")]
        public ActionResult UpdateMenu([FromBody] UpdateMenuDto dto, [FromRoute] int id)
        {
            _menusService.UpdateMenu(id, dto);

            return Ok();
        }

        // Usuwanie konkretnego jadłospisu
        [HttpDelete("menu/{id}")]
        public ActionResult DeleteMenu([FromRoute] int id)
        {
            _menusService.DeleteMenu(id);

            // operacja zakończona sukcesem
            return NoContent();
        }
    }
}
