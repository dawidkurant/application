using Microsoft.AspNetCore.Mvc;
using Papu.Models;
using Papu.Services;
using System.Collections.Generic;

namespace Papu.Controllers
{
    [Route("api")]
    public class DaysOfTheWeekController : ControllerBase
    {

        private readonly IDaysOfTheWeekService _daysOfTheWeekService;
        public DaysOfTheWeekController(IDaysOfTheWeekService daysOfTheWeekService)
        {
            _daysOfTheWeekService = daysOfTheWeekService;
        }

        //Pobranie konkretnego poniedziałku 
        [HttpGet("monday/{id}")]
        public ActionResult<MondayDto> GetMonday([FromRoute] int id)
        {
            var monday = _daysOfTheWeekService.GetByIdMonday(id);

            if (monday is null)
            {
                return NotFound();
            }

            return Ok(monday);
        }

        //Pobranie wszystkich poniedziałków z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet("monday")]
        public ActionResult<IEnumerable<MondayDto>> GetAllMondays()
        {
            var mondaysDtos = _daysOfTheWeekService.GetAllMondays();

            return Ok(mondaysDtos);
        }

        //Tworzenie nowego poniedziałku
        [HttpPost("createmonday")]
        public ActionResult CreateMonday([FromBody] CreateMondayDto dto)
        {
            var newMondayId = _daysOfTheWeekService.CreateMonday(dto);

            //Jako pierwszy parametr ścieżka, a jako drugi
            //możemy zwrócić ciało odpowiedzi, ale w tym wypadku zwracamy null
            return Created($"api/monday/{newMondayId}", null);
        }

        //Pobranie konkretnego wtorku 
        [HttpGet("tuesday/{id}")]
        public ActionResult<TuesdayDto> GetTuesday([FromRoute] int id)
        {
            var tuesday = _daysOfTheWeekService.GetByIdTuesday(id);

            if (tuesday is null)
            {
                return NotFound();
            }

            return Ok(tuesday);
        }

        //Pobranie wszystkich wtorków z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet("tuesday")]
        public ActionResult<IEnumerable<TuesdayDto>> GetAllTuesdays()
        {
            var tuesdaysDtos = _daysOfTheWeekService.GetAllTuesdays();

            return Ok(tuesdaysDtos);
        }

        //Tworzenie nowego wtorku
        [HttpPost("createtuesday")]
        public ActionResult CreateTuesday([FromBody] CreateTuesdayDto dto)
        {
            var newTuesdayId = _daysOfTheWeekService.CreateTuesday(dto);

            //Jako pierwszy parametr ścieżka, a jako drugi
            //możemy zwrócić ciało odpowiedzi, ale w tym wypadku zwracamy null
            return Created($"api/tuesday/{newTuesdayId}", null);
        }

        //Pobranie konkretnej środy 
        [HttpGet("wednesday/{id}")]
        public ActionResult<WednesdayDto> GetWednesday([FromRoute] int id)
        {
            var wednesday = _daysOfTheWeekService.GetByIdWednesday(id);

            if (wednesday is null)
            {
                return NotFound();
            }

            return Ok(wednesday);
        }

        //Pobranie wszystkich śród z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet("wednesday")]
        public ActionResult<IEnumerable<WednesdayDto>> GetAllWednesdays()
        {
            var wednesdaysDtos = _daysOfTheWeekService.GetAllWednesdays();

            return Ok(wednesdaysDtos);
        }

        //Tworzenie nowej środy
        [HttpPost("createwednesday")]
        public ActionResult CreateWednesday([FromBody] CreateWednesdayDto dto)
        {
            var newWednesdayId = _daysOfTheWeekService.CreateWednesday(dto);

            //Jako pierwszy parametr ścieżka, a jako drugi
            //możemy zwrócić ciało odpowiedzi, ale w tym wypadku zwracamy null
            return Created($"api/wednesday/{newWednesdayId}", null);
        }

        //Pobranie konkretnego czwartku 
        [HttpGet("thursday/{id}")]
        public ActionResult<ThursdayDto> GetThursday([FromRoute] int id)
        {
            var thursday = _daysOfTheWeekService.GetByIdThursday(id);

            if (thursday is null)
            {
                return NotFound();
            }

            return Ok(thursday);
        }

        //Pobranie wszystkich czwartków z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet("thursday")]
        public ActionResult<IEnumerable<ThursdayDto>> GetAllThursdays()
        {
            var thursdaysDtos = _daysOfTheWeekService.GetAllThursdays();

            return Ok(thursdaysDtos);
        }

        //Tworzenie nowego czwartku
        [HttpPost("createthursday")]
        public ActionResult CreateThursday([FromBody] CreateThursdayDto dto)
        {
            var newThursdayId = _daysOfTheWeekService.CreateThursday(dto);

            //Jako pierwszy parametr ścieżka, a jako drugi
            //możemy zwrócić ciało odpowiedzi, ale w tym wypadku zwracamy null
            return Created($"api/thursday/{newThursdayId}", null);
        }

        //Pobranie konkretnego piątku 
        [HttpGet("friday/{id}")]
        public ActionResult<FridayDto> GetFriday([FromRoute] int id)
        {
            var friday = _daysOfTheWeekService.GetByIdFriday(id);

            if (friday is null)
            {
                return NotFound();
            }

            return Ok(friday);
        }

        //Pobranie wszystkich piątków z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet("friday")]
        public ActionResult<IEnumerable<FridayDto>> GetAllFridays()
        {
            var fridaysDtos = _daysOfTheWeekService.GetAllFridays();

            return Ok(fridaysDtos);
        }

        //Tworzenie nowego piątku
        [HttpPost("createfriday")]
        public ActionResult CreateFriday([FromBody] CreateFridayDto dto)
        {
            var newFridayId = _daysOfTheWeekService.CreateFriday(dto);

            //Jako pierwszy parametr ścieżka, a jako drugi
            //możemy zwrócić ciało odpowiedzi, ale w tym wypadku zwracamy null
            return Created($"api/friday/{newFridayId}", null);
        }

        //Pobranie konkretnej soboty 
        [HttpGet("saturday/{id}")]
        public ActionResult<SaturdayDto> GetSaturday([FromRoute] int id)
        {
            var saturday = _daysOfTheWeekService.GetByIdSaturday(id);

            if (saturday is null)
            {
                return NotFound();
            }

            return Ok(saturday);
        }

        //Pobranie wszystkich sobót z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet("saturday")]
        public ActionResult<IEnumerable<SaturdayDto>> GetAllSaturdays()
        {
            var saturdaysDtos = _daysOfTheWeekService.GetAllSaturdays();

            return Ok(saturdaysDtos);
        }

        //Tworzenie nowej soboty
        [HttpPost("createsaturday")]
        public ActionResult CreateSaturday([FromBody] CreateSaturdayDto dto)
        {
            var newSaturdayId = _daysOfTheWeekService.CreateSaturday(dto);

            //Jako pierwszy parametr ścieżka, a jako drugi
            //możemy zwrócić ciało odpowiedzi, ale w tym wypadku zwracamy null
            return Created($"api/saturday/{newSaturdayId}", null);
        }

        //Pobranie konkretnej niedzieli 
        [HttpGet("sunday/{id}")]
        public ActionResult<SundayDto> GetSunday([FromRoute] int id)
        {
            var sunday = _daysOfTheWeekService.GetByIdSunday(id);

            if (sunday is null)
            {
                return NotFound();
            }

            return Ok(sunday);
        }

        //Pobranie wszystkich niedziel z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet("sunday")]
        public ActionResult<IEnumerable<SundayDto>> GetAllSundays()
        {
            var sundaysDtos = _daysOfTheWeekService.GetAllSundays();

            return Ok(sundaysDtos);
        }

        //Tworzenie nowej niedzieli
        [HttpPost("createsunday")]
        public ActionResult CreateSunday([FromBody] CreateSundayDto dto)
        {
            var newSundayId = _daysOfTheWeekService.CreateSunday(dto);

            //Jako pierwszy parametr ścieżka, a jako drugi
            //możemy zwrócić ciało odpowiedzi, ale w tym wypadku zwracamy null
            return Created($"api/sunday/{newSundayId}", null);
        }

    }
}
