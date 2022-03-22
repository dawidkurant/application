using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papu.Models;
using Papu.Models.Update.TimesOfDay;
using Papu.Services;
using System.Collections.Generic;

namespace Papu.Controllers
{
    [Route("api")]
    [ApiController]
    //Atrybut potrzebny aby dane akcje były zablokowane przed niezalogowanymi użytkownikami
    [Authorize]
    public class TimesOfDayController : ControllerBase
    {
        private readonly ITimesOfDayService _timesOfDayService;

        public TimesOfDayController(ITimesOfDayService timesOfDay)
        {
            _timesOfDayService = timesOfDay;
        }

        //Pobranie konkretnego śniadania 
        [HttpGet("breakfast/{id}")]
        //Ta akcja nie wymaga autoryzacji
        [AllowAnonymous]
        public ActionResult<BreakfastDto> GetOneBreakfast([FromRoute] int id)
        {
            var breakfast = _timesOfDayService.GetByIdBreakfast(id);

            return Ok(breakfast);
        }

        //Pobranie konkretnego drugiego śniadania 
        [HttpGet("secondbreakfast/{id}")]
        //Ta akcja nie wymaga autoryzacji
        [AllowAnonymous]
        public ActionResult<SecondBreakfastDto> GetOneSecondBreakfast([FromRoute] int id)
        {
            var secondBreakfast = _timesOfDayService.GetByIdSecondBreakfast(id);

            return Ok(secondBreakfast);
        }

        //Pobranie konkretnego obiadu 
        [HttpGet("lunch/{id}")]
        //Ta akcja nie wymaga autoryzacji
        [AllowAnonymous]
        public ActionResult<LunchDto> GetOneLunch([FromRoute] int id)
        {
            var lunch = _timesOfDayService.GetByIdLunch(id);

            return Ok(lunch);
        }

        //Pobranie konkretnego podwieczorka 
        [HttpGet("snack/{id}")]
        //Ta akcja nie wymaga autoryzacji
        [AllowAnonymous]
        public ActionResult<SnackDto> GetOneSnack([FromRoute] int id)
        {
            var snack = _timesOfDayService.GetByIdSnack(id);

            return Ok(snack);
        }

        //Pobranie konkretnej kolacji 
        [HttpGet("dinner/{id}")]
        //Ta akcja nie wymaga autoryzacji
        [AllowAnonymous]
        public ActionResult<DinnerDto> GetOneDinner([FromRoute] int id)
        {
            var dinner = _timesOfDayService.GetByIdDinner(id);

            return Ok(dinner);
        }

        //Pobranie wszystkich śniadań z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet("breakfast")]
        public ActionResult<IEnumerable<BreakfastDto>> GetAllBreakfasts()
        {
            var breakfastsDtos = _timesOfDayService.GetAllBreakfast();

            return Ok(breakfastsDtos);
        }

        //Pobranie wszystkich drugich śniadań z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet("secondbreakfast")]
        public ActionResult<IEnumerable<SecondBreakfastDto>> GetAllSecondBreakfasts()
        {
            var secondBreakfastsDtos = _timesOfDayService.GetAllSecondBreakfast();

            return Ok(secondBreakfastsDtos);
        }

        //Pobranie wszystkich obiadów z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet("lunch")]
        public ActionResult<IEnumerable<LunchDto>> GetAllLunches()
        {
            var lunchesDtos = _timesOfDayService.GetAllLunch();

            return Ok(lunchesDtos);
        }

        //Pobranie wszystkich podwieczorków z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet("snack")]
        public ActionResult<IEnumerable<SnackDto>> GetAllSnacks()
        {
            var snacksDtos = _timesOfDayService.GetAllSnack();

            return Ok(snacksDtos);
        }

        //Pobranie wszystkich kolacji z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet("dinner")]
        public ActionResult<IEnumerable<SnackDto>> GetAllDinners()
        {
            var dinnersDtos = _timesOfDayService.GetAllDinner();

            return Ok(dinnersDtos);
        }

        //Tworzenie nowego śniadania
        [HttpPost("createbreakfast")]
        public ActionResult CreateBreakfast([FromBody] CreateBreakfastDto dtoBreakfast)
        {

            var newBreakfastId = _timesOfDayService.CreateBreakfast(dtoBreakfast);

            //Jako pierwszy parametr ścieżka, a jako drugi
            //możemy zwrócić ciało odpowiedzi, ale w tym wypadku zwracamy null
            return Created($"api/breakfast/{newBreakfastId}", null);
        }

        //Tworzenie nowego drugiego śniadania
        [HttpPost("createsecondbreakfast")]
        public ActionResult CreateSecondBreakfast([FromBody] CreateSecondBreakfastDto dtoSecondBreakfast)
        {
            var newSecondBreakfastId = _timesOfDayService.CreateSecondBreakfast(dtoSecondBreakfast);

            //Jako pierwszy parametr ścieżka, a jako drugi
            //możemy zwrócić ciało odpowiedzi, ale w tym wypadku zwracamy null
            return Created($"api/secondbreakfast/{newSecondBreakfastId}", null);
        }

        //Tworzenie nowego obiadu
        [HttpPost("createlunch")]
        public ActionResult CreateLunch([FromBody] CreateLunchDto dtoLunch)
        {
            var newLunchId = _timesOfDayService.CreateLunch(dtoLunch);

            //Jako pierwszy parametr ścieżka, a jako drugi
            //możemy zwrócić ciało odpowiedzi, ale w tym wypadku zwracamy null
            return Created($"api/lunch/{newLunchId}", null);
        }

        //Tworzenie nowego podwieczorka
        [HttpPost("createsnack")]
        public ActionResult CreateSnack([FromBody] CreateSnackDto dtoSnack)
        {
            var newSnackId = _timesOfDayService.CreateSnack(dtoSnack);

            //Jako pierwszy parametr ścieżka, a jako drugi
            //możemy zwrócić ciało odpowiedzi, ale w tym wypadku zwracamy null
            return Created($"api/snack/{newSnackId}", null);
        }

        //Tworzenie nowej kolacji
        [HttpPost("createdinner")]
        public ActionResult CreateDinner([FromBody] CreateDinnerDto dtoDinner)
        {
            var newDinnerId = _timesOfDayService.CreateDinner(dtoDinner);

            //Jako pierwszy parametr ścieżka, a jako drugi
            //możemy zwrócić ciało odpowiedzi, ale w tym wypadku zwracamy null
            return Created($"api/dinner/{newDinnerId}", null);
        }

        //Edycja śniadania
        [HttpPut("breakfast/{id}")]
        public ActionResult UpdateBreakfast([FromBody] UpdateBreakfastDto dto, [FromRoute] int id)
        {
            _timesOfDayService.UpdateBreakfast(id, dto);

            return Ok();
        }

        //Edycja drugiego śniadania
        [HttpPut("secondbreakfast/{id}")]
        public ActionResult UpdateSecondBreakfast([FromBody] UpdateSecondBreakfastDto dto, [FromRoute] int id)
        {
            _timesOfDayService.UpdateSecondBreakfast(id, dto);

            return Ok();
        }

        //Edycja obiadu
        [HttpPut("lunch/{id}")]
        public ActionResult UpdateLunch([FromBody] UpdateLunchDto dto, [FromRoute] int id)
        {
            _timesOfDayService.UpdateLunch(id, dto);

            return Ok();
        }

        //Edycja podwieczorka
        [HttpPut("snack/{id}")]
        public ActionResult UpdateSnack([FromBody] UpdateSnackDto dto, [FromRoute] int id)
        {
            _timesOfDayService.UpdateSnack(id, dto);

            return Ok();
        }

        //Edycja kolacji
        [HttpPut("dinner/{id}")]
        public ActionResult UpdateDinner([FromBody] UpdateDinnerDto dto, [FromRoute] int id)
        {
            _timesOfDayService.UpdateDinner(id, dto);

            return Ok();
        }

        //Usuwanie konkretnego śniadania
        [HttpDelete("breakfast/{id}")]
        public ActionResult DeleteBreakfast([FromRoute] int id)
        {
            _timesOfDayService.DeleteBreakfast(id);

            //operacja zakończona sukcesem
            return NoContent();
        }

        //Usuwanie konkretnego drugiego śniadania
        [HttpDelete("secondbreakfast/{id}")]
        public ActionResult DeleteSecondBreakfast([FromRoute] int id)
        {
            _timesOfDayService.DeleteSecondBreakfast(id);

            //operacja zakończona sukcesem
            return NoContent();
        }

        //Usuwanie konkretnego obiadu
        [HttpDelete("lunch/{id}")]
        public ActionResult DeleteLunch([FromRoute] int id)
        {
            _timesOfDayService.DeleteLunch(id);

            //operacja zakończona sukcesem
            return NoContent();
        }

        //Usuwanie konkretnego podwieczorka
        [HttpDelete("snack/{id}")]
        public ActionResult DeleteSnack([FromRoute] int id)
        {
            _timesOfDayService.DeleteSnack(id);

            //operacja zakończona sukcesem
            return NoContent();
        }

        //Usuwanie konkretnej kolacji
        [HttpDelete("dinner/{id}")]
        public ActionResult DeleteDinner([FromRoute] int id)
        {
            _timesOfDayService.DeleteDinner(id);

            //operacja zakończona sukcesem
            return NoContent();
        }
    }
}
