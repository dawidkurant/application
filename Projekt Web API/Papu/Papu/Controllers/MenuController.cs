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

        //Pobranie wszystkich jadłospisów z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet("menu")]
        public ActionResult<IEnumerable<MenuDto>> GetAllMenus()
        {
            var menusDtos = _menuService.GetAllMenus();

            return Ok(menusDtos);
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

        //Tworzenie nowego jadłospisu
        [HttpPost("createmenu")]
        public ActionResult CreateMenu([FromBody] CreateMenuDto dto)
        {
            var newMenuId = _menuService.CreateMenu(dto);

            //Jako pierwszy parametr ścieżka, a jako drugi
            //możemy zwrócić ciało odpowiedzi, ale w tym wypadku zwracamy null
            return Created($"api/menu/{newMenuId}", null);
        }
    }
}
