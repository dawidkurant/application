using Microsoft.AspNetCore.Mvc;
using Papu.Models;
using Papu.Services;
using System.Collections.Generic;

namespace Papu.Controllers
{
    [Route("api/monday")]
    public class MondayController : ControllerBase
    {

        private readonly IMondayService _mondayService;
        public MondayController(IMondayService mondayService)
        {
            _mondayService = mondayService;
        }

        //Pobranie konkretnego poniedziałku 
        [HttpGet("{id}")]
        public ActionResult<MondayDto> GetMonday([FromRoute] int id)
        {
            var monday = _mondayService.GetByIdMonday(id);

            if (monday is null)
            {
                return NotFound();
            }

            return Ok(monday);
        }

        //Pobranie wszystkich poniedziałków z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet]
        public ActionResult<IEnumerable<MondayDto>> GetAllMondays()
        {
            var mondaysDtos = _mondayService.GetAllMondays();

            return Ok(mondaysDtos);
        }

        //Tworzenie nowego poniedziałku
        [HttpPost]
        public ActionResult CreateMonday([FromBody] CreateMondayDto dto)
        {
            var newMondayId = _mondayService.CreateMonday(dto);

            //Jako pierwszy parametr ścieżka, a jako drugi
            //możemy zwrócić ciało odpowiedzi, ale w tym wypadku zwracamy null
            return Created($"api/monday/{newMondayId}", null);
        }
    }
}
