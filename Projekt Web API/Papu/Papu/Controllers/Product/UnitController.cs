using Microsoft.AspNetCore.Mvc;
using Papu.Models.Product;
using Papu.Services;
using System.Collections.Generic;

namespace Papu.Controllers
{
    [Route("api/unit")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        // Pobranie konkretnej jednostki
        [HttpGet("{id}")]
        public ActionResult<UnitDto> GetUnit([FromRoute] int id)
        {
            var unit = _unitService.GetByIdUnit(id);

            return Ok(unit);
        }

        // Pobranie wszystkich jednostek z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet]
        public ActionResult<IEnumerable<UnitDto>> GetAllUnits()
        {
            var unitsDtos = _unitService.GetAllUnits();

            return Ok(unitsDtos);
        }
    }
}
