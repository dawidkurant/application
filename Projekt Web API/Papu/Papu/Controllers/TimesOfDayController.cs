using Microsoft.AspNetCore.Mvc;
using Papu.Models;
using Papu.Models.Create;
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

        //Pobranie wszystkich śniadań z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet("breakfast")]
        public ActionResult<IEnumerable<BreakfastDto>> GetAllBreakfasts()
        {
            var breakfastsDtos = _timesOfDayService.GetAllBreakfast();

            return Ok(breakfastsDtos);
        }

        //Tworzenie nowego śniadania
        [HttpPost]
        public ActionResult CreateBreakfast([FromBody] CreateBreakfastDto dtoBreakfast)
        {
            var newBreakfastId = _timesOfDayService.CreateBreakfast(dtoBreakfast);

            //Jako pierwszy parametr ścieżka, a jako drugi
            //możemy zwrócić ciało odpowiedzi, ale w tym wypadku zwracamy null
            return Created($"api/breakfast/{newBreakfastId}", null);
        }
    }
}
