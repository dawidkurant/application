using Microsoft.AspNetCore.Mvc;
using Papu.Models.Dish;
using Papu.Services;
using System.Collections.Generic;

namespace Papu.Controllers.Dish
{
    [Route("api/type")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly ITypeService _typeService;

        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        //Pobranie konkretnego typu
        [HttpGet("{id}")]
        public ActionResult<TypeDto> GetType([FromRoute] int id)
        {
            var type = _typeService.GetByIdType(id);

            return Ok(type);
        }

        //Pobranie wszystkich typów z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet]
        public ActionResult<IEnumerable<TypeDto>> GetAllTypes()
        {
            var typesDtos = _typeService.GetAllTypes();

            return Ok(typesDtos);
        }
    }
}
