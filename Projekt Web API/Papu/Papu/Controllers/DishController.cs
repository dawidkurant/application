using Microsoft.AspNetCore.Mvc;
using Papu.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Papu.Controllers
{
    [Route("api/dish")]
    public class DishController : ControllerBase
    {
        private readonly PapuDbContext _dbContext;

        public DishController(PapuDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Pobranie wszystkich potraw z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet]
        public ActionResult<IEnumerable<Dish>> GetAll()
        {
            var dishes = _dbContext
                .Dishes
                .ToList();

            return Ok(dishes);
        }

        //Pobranie konkretnej potrawy
        [HttpGet("{id}")]
        public ActionResult<Dish> Get([FromRoute] int id)
        {
            var dish = _dbContext
                .Dishes
                .FirstOrDefault(r => r.DishId == id);

            if(dish is null)
            {
                return NotFound();
            }

            return Ok(dish);
        }
    }
}
