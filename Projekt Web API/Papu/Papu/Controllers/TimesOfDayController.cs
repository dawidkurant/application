using Microsoft.AspNetCore.Mvc;
using Papu.Models;
using Papu.Services;
using System.Collections.Generic;

namespace Papu.Controllers
{
    [Route("api")]
    public class TimesOfDayController : ControllerBase
    {
        private readonly ITimesOfDayService _timesOfDayService;

        public TimesOfDayController(ITimesOfDayService timesOfDay)
        {
            _timesOfDayService = timesOfDay;
        }

        //Pobranie konkretnego śniadania 
        [HttpGet("breakfast/{id}")]
        public ActionResult<BreakfastDto> GetOneBreakfast([FromRoute] int id)
        {
            var breakfast = _timesOfDayService.GetByIdBreakfast(id);

            if (breakfast is null)
            {
                return NotFound();
            }

            return Ok(breakfast);
        }

        //Pobranie konkretnego drugiego śniadania 
        [HttpGet("secondbreakfast/{id}")]
        public ActionResult<SecondBreakfastDto> GetOneSecondBreakfast([FromRoute] int id)
        {
            var secondBreakfast = _timesOfDayService.GetByIdSecondBreakfast(id);

            if (secondBreakfast is null)
            {
                return NotFound();
            }

            return Ok(secondBreakfast);
        }

        //Pobranie konkretnego obiadu 
        [HttpGet("lunch/{id}")]
        public ActionResult<LunchDto> GetOneLunch([FromRoute] int id)
        {
            var lunch = _timesOfDayService.GetByIdLunch(id);

            if (lunch is null)
            {
                return NotFound();
            }

            return Ok(lunch);
        }

        //Pobranie konkretnego podwieczorka 
        [HttpGet("snack/{id}")]
        public ActionResult<SnackDto> GetOneSnack([FromRoute] int id)
        {
            var snack = _timesOfDayService.GetByIdSnack(id);

            if (snack is null)
            {
                return NotFound();
            }

            return Ok(snack);
        }

        //Pobranie konkretnej kolacji 
        [HttpGet("dinner/{id}")]
        public ActionResult<DinnerDto> GetOneDinner([FromRoute] int id)
        {
            var dinner = _timesOfDayService.GetByIdDinner(id);

            if (dinner is null)
            {
                return NotFound();
            }

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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newBreakfastId = _timesOfDayService.CreateBreakfast(dtoBreakfast);

            //Jako pierwszy parametr ścieżka, a jako drugi
            //możemy zwrócić ciało odpowiedzi, ale w tym wypadku zwracamy null
            return Created($"api/breakfast/{newBreakfastId}", null);
        }

        //Tworzenie nowego drugiego śniadania
        [HttpPost("createsecondbreakfast")]
        public ActionResult CreateSecondBreakfast([FromBody] CreateSecondBreakfastDto dtoSecondBreakfast)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newSecondBreakfastId = _timesOfDayService.CreateSecondBreakfast(dtoSecondBreakfast);

            //Jako pierwszy parametr ścieżka, a jako drugi
            //możemy zwrócić ciało odpowiedzi, ale w tym wypadku zwracamy null
            return Created($"api/secondbreakfast/{newSecondBreakfastId}", null);
        }

        //Tworzenie nowego obiadu
        [HttpPost("createlunch")]
        public ActionResult CreateLunch([FromBody] CreateLunchDto dtoLunch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newLunchId = _timesOfDayService.CreateLunch(dtoLunch);

            //Jako pierwszy parametr ścieżka, a jako drugi
            //możemy zwrócić ciało odpowiedzi, ale w tym wypadku zwracamy null
            return Created($"api/lunch/{newLunchId}", null);
        }

        //Tworzenie nowego podwieczorka
        [HttpPost("createsnack")]
        public ActionResult CreateSnack([FromBody] CreateSnackDto dtoSnack)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newSnackId = _timesOfDayService.CreateSnack(dtoSnack);

            //Jako pierwszy parametr ścieżka, a jako drugi
            //możemy zwrócić ciało odpowiedzi, ale w tym wypadku zwracamy null
            return Created($"api/snack/{newSnackId}", null);
        }

        //Tworzenie nowej kolacji
        [HttpPost("createdinner")]
        public ActionResult CreateDinner([FromBody] CreateDinnerDto dtoDinner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newDinnerId = _timesOfDayService.CreateDinner(dtoDinner);

            //Jako pierwszy parametr ścieżka, a jako drugi
            //możemy zwrócić ciało odpowiedzi, ale w tym wypadku zwracamy null
            return Created($"api/dinner/{newDinnerId}", null);
        }
    }
}
