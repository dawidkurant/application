using Microsoft.AspNetCore.Mvc;
using Papu.Models.Dish;
using Papu.Services;
using System.Collections.Generic;

namespace Papu.Controllers.Dish
{
    [Route("api/kindOf")]
    [ApiController]
    public class KindOfController : ControllerBase
    {
        private readonly IKindOfService _kindOfService;

        public KindOfController(IKindOfService kindOfService)
        {
            _kindOfService = kindOfService;
        }

        // Pobranie konkretnego rodzaju
        [HttpGet("{id}")]
        public ActionResult<KindOfDto> GetKindOf([FromRoute] int id)
        {
            var kindOf = _kindOfService.GetByIdKindOf(id);

            return Ok(kindOf);
        }

        // Pobranie wszystkich rodzajów z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet]
        public ActionResult<IEnumerable<KindOfDto>> GetAllKindsOf()
        {
            var kindsOfDtos = _kindOfService.GetAllKindsOf();

            return Ok(kindsOfDtos);
        }
    }
}
