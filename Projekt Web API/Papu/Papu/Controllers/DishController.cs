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

        //pobranie wszystkich potraw z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        public ActionResult<IEnumerable<Dish>> GetAll()
        {
            var dishes = _dbContext
                .Dishes
                .ToList();

            return Ok(dishes);
        }
    }
}
