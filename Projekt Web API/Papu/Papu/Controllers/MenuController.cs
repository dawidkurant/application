using Microsoft.AspNetCore.Mvc;
using Papu.Models;
using Papu.Services;
using System.Collections.Generic;

namespace Papu.Controllers
{
    [Route("api")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        //Pobranie konkretnego jadłospisu
        [HttpGet("menu/{id}")]
        public ActionResult<MenuDto> GetMenu([FromRoute] int id)
        {
            var menu = _menuService.GetByIdMenu(id);

            if (menu is null)
            {
                return NotFound();
            }

            return Ok(menu);
        }

        //Pobranie wszystkich jadłospisów z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet("menu")]
        public ActionResult<IEnumerable<MenuDto>> GetAllMenus()
        {
            var menusDtos = _menuService.GetAllMenus();

            return Ok(menusDtos);
        }

        //Tworzenie nowego jadłospisu
        [HttpPost("createmenu")]
        public ActionResult CreateMenu([FromBody] CreateMenuDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newMenuId = _menuService.CreateMenu(dto);

            //Jako pierwszy parametr ścieżka, a jako drugi
            //możemy zwrócić ciało odpowiedzi, ale w tym wypadku zwracamy null
            return Created($"api/menu/{newMenuId}", null);
        }

        //Usuwanie jadłospisu
        [HttpDelete("{id}")]
        public ActionResult DeleteMenu([FromRoute] int id)
        {
            var isDeleted = _menuService.DeleteMenu(id);

            //operacja zakończona sukcesem
            if (isDeleted)
            {
                return NoContent();
            }

            //nie odnaleziono
            return NotFound();
        }
    }
}
