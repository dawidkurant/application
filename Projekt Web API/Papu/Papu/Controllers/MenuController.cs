using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Papu.Entities;
using Papu.Models;
using System.Collections.Generic;
using System.Linq;

namespace Papu.Controllers
{
    [Route("api/menu")]
    public class MenuController : ControllerBase
    {
        private readonly PapuDbContext _dbContext;
        private readonly IMapper _mapper;

        public MenuController(PapuDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //Pobranie wszystkich menu z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet]
        public ActionResult<IEnumerable<MenuDto>> GetAll()
        {
            var menus = _dbContext
                .Menus
                .Include(r => r.Monday.MondayProducts)
                .Include(r => r.Monday.MondayDishes)
                .Include(r => r.Tuesday.TuesdayProducts)
                .Include(r => r.Tuesday.TuesdayDishes)
                .Include(r => r.Wednesday.WednesdayProducts)
                .Include(r => r.Wednesday.WednesdayDishes)
                .Include(r => r.Thursday.ThursdayProducts)
                .Include(r => r.Thursday.ThursdayDishes)
                .Include(r => r.Friday.FridayProducts)
                .Include(r => r.Friday.FridayDishes)
                .Include(r => r.Saturday.SaturdayProducts)
                .Include(r => r.Saturday.SaturdayDishes)
                .Include(r => r.Sunday.SundayProducts)
                .Include(r => r.Sunday.SundayDishes)
                .ToList();

            var menusDtos = _mapper.Map<List<MenuDto>>(menus);

            return Ok(menusDtos);
        }

        //Pobranie konkretnego menu
        [HttpGet("{id}")]
        public ActionResult<MenuDto> Get([FromRoute] int id)
        {
            var menu = _dbContext
                .Menus
                .Include(r => r.Monday.MondayProducts)
                .Include(r => r.Monday.MondayDishes)
                .Include(r => r.Tuesday.TuesdayProducts)
                .Include(r => r.Tuesday.TuesdayDishes)
                .Include(r => r.Wednesday.WednesdayProducts)
                .Include(r => r.Wednesday.WednesdayDishes)
                .Include(r => r.Thursday.ThursdayProducts)
                .Include(r => r.Thursday.ThursdayDishes)
                .Include(r => r.Friday.FridayProducts)
                .Include(r => r.Friday.FridayDishes)
                .Include(r => r.Saturday.SaturdayProducts)
                .Include(r => r.Saturday.SaturdayDishes)
                .Include(r => r.Sunday.SundayProducts)
                .Include(r => r.Sunday.SundayDishes)
                .FirstOrDefault(r => r.MenuId == id);

            if (menu is null)
            {
                return NotFound();
            }

            var menuDto = _mapper.Map<MenuDto>(menu);

            return Ok(menuDto);
        }
    }
}
