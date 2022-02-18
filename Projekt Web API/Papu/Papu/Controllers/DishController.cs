using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Papu.Entities;
using Papu.Models;
using System.Collections.Generic;
using System.Linq;

namespace Papu.Controllers
{
    [Route("api/dish")]
    public class DishController : ControllerBase
    {
        private readonly PapuDbContext _dbContext;
        private readonly IMapper _mapper;

        public DishController(PapuDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //Pobranie wszystkich potraw z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet]
        public ActionResult<IEnumerable<DishDto>> GetAll()
        {
            var dishes = _dbContext
                .Dishes
                .Include(r => r.KindsOf)
                .Include(r => r.Types)
                .Include(r => r.Products)
                .ToList();

            var dishesDtos = _mapper.Map<List<DishDto>>(dishes);

            return Ok(dishesDtos);
        }

        //Pobranie konkretnej potrawy
        [HttpGet("{id}")]
        public ActionResult<DishDto> Get([FromRoute] int id)
        {
            var dish = _dbContext
                .Dishes
                .Include(r => r.KindsOf)
                .Include(r => r.Types)
                .Include(r => r.Products)
                .FirstOrDefault(r => r.DishId == id);

            if(dish is null)
            {
                return NotFound();
            }

            var dishDto = _mapper.Map<DishDto>(dish);

            return Ok(dishDto);
        }
    }
}
