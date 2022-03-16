using Microsoft.AspNetCore.Mvc;
using Papu.Models;
using Papu.Models.Update;
using Papu.Services;
using System.Collections.Generic;

namespace Papu.Controllers
{
    [Route("api/menu")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        //Pobranie konkretnego jadłospisu
        [HttpGet("{id}")]
        public ActionResult<MenuDto> GetMenu([FromRoute] int id)
        {
            var menu = _menuService.GetByIdMenu(id);

            return Ok(menu);
        }

        //Pobranie wszystkich jadłospisów z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet]
        public ActionResult<IEnumerable<MenuDto>> GetAllMenus()
        {
            var menusDtos = _menuService.GetAllMenus();

            return Ok(menusDtos);
        }

        //Tworzenie nowego jadłospisu
        [HttpPost]
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

        //Edycja jadłospisu
        [HttpPut("{id}")]
        public ActionResult UpdateMenu([FromBody] UpdateMenuDto dto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _menuService.UpdateMenu(id, dto);

            return Ok();
        }

        //Usuwanie jadłospisu
        [HttpDelete("{id}")]
        public ActionResult DeleteMenu([FromRoute] int id)
        {
            _menuService.DeleteMenu(id);

            //operacja zakończona sukcesem
            return NoContent();
        }
    }
}
