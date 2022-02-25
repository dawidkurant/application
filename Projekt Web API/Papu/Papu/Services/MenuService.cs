using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Papu.Entities;
using Papu.Models;
using System.Collections.Generic;
using System.Linq;

namespace Papu.Services
{
    public class MenuService : IMenuService
    {

        private readonly PapuDbContext _dbContext;
        private readonly IMapper _mapper;

        public MenuService(PapuDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public MenuDto GetByIdMenu(int id)
        {
            Menu menu =
                _dbContext.Menus
                .Include(c => c.Monday).ThenInclude(cs => cs.MondayProducts).ThenInclude(css => css.Product)
                .Include(c => c.Monday).ThenInclude(cs => cs.MondayDishes).ThenInclude(css => css.Dish)
                .Include(c => c.Tuesday).ThenInclude(cs => cs.TuesdayProducts).ThenInclude(css => css.Product)
                .Include(c => c.Tuesday).ThenInclude(cs => cs.TuesdayDishes).ThenInclude(css => css.Dish)
                .Include(c => c.Wednesday).ThenInclude(cs => cs.WednesdayProducts).ThenInclude(css => css.Product)
                .Include(c => c.Wednesday).ThenInclude(cs => cs.WednesdayDishes).ThenInclude(css => css.Dish)
                .Include(c => c.Thursday).ThenInclude(cs => cs.ThursdayProducts).ThenInclude(css => css.Product)
                .Include(c => c.Thursday).ThenInclude(cs => cs.ThursdayDishes).ThenInclude(css => css.Dish)
                .Include(c => c.Friday).ThenInclude(cs => cs.FridayProducts).ThenInclude(css => css.Product)
                .Include(c => c.Friday).ThenInclude(cs => cs.FridayDishes).ThenInclude(css => css.Dish)
                .Include(c => c.Saturday).ThenInclude(cs => cs.SaturdayProducts).ThenInclude(css => css.Product)
                .Include(c => c.Saturday).ThenInclude(cs => cs.SaturdayDishes).ThenInclude(css => css.Dish)
                .Include(c => c.Sunday).ThenInclude(cs => cs.SundayProducts).ThenInclude(css => css.Product)
                .Include(c => c.Sunday).ThenInclude(cs => cs.SundayDishes).ThenInclude(css => css.Dish)
                .FirstOrDefault(c => c.MenuId == id);


            if (menu is null)
            {
                return null;
            }

            var result = _mapper.Map<MenuDto>(menu);

            return result;
        }

        public IEnumerable<MenuDto> GetAllMenus()
        {
            var menus = _dbContext
                .Menus
                .Include(c => c.Monday).ThenInclude(cs => cs.MondayProducts).ThenInclude(css => css.Product)
                .Include(c => c.Monday).ThenInclude(cs => cs.MondayDishes).ThenInclude(css => css.Dish)
                .Include(c => c.Tuesday).ThenInclude(cs => cs.TuesdayProducts).ThenInclude(css => css.Product)
                .Include(c => c.Tuesday).ThenInclude(cs => cs.TuesdayDishes).ThenInclude(css => css.Dish)
                .Include(c => c.Wednesday).ThenInclude(cs => cs.WednesdayProducts).ThenInclude(css => css.Product)
                .Include(c => c.Wednesday).ThenInclude(cs => cs.WednesdayDishes).ThenInclude(css => css.Dish)
                .Include(c => c.Thursday).ThenInclude(cs => cs.ThursdayProducts).ThenInclude(css => css.Product)
                .Include(c => c.Thursday).ThenInclude(cs => cs.ThursdayDishes).ThenInclude(css => css.Dish)
                .Include(c => c.Friday).ThenInclude(cs => cs.FridayProducts).ThenInclude(css => css.Product)
                .Include(c => c.Friday).ThenInclude(cs => cs.FridayDishes).ThenInclude(css => css.Dish)
                .Include(c => c.Saturday).ThenInclude(cs => cs.SaturdayProducts).ThenInclude(css => css.Product)
                .Include(c => c.Saturday).ThenInclude(cs => cs.SaturdayDishes).ThenInclude(css => css.Dish)
                .Include(c => c.Sunday).ThenInclude(cs => cs.SundayProducts).ThenInclude(css => css.Product)
                .Include(c => c.Sunday).ThenInclude(cs => cs.SundayDishes).ThenInclude(css => css.Dish)
                .ToList();

            var menusDto = _mapper.Map<List<MenuDto>>(menus);

            return menusDto;
        }

        public int CreateMenu(CreateMenuDto dto)
        {
            var menu = _mapper.Map<Menu>(dto);

            var monday = _mapper.Map<Monday>(dto);

            Menu menu2 = _dbContext.Menus
                .Include(c => c.Monday).ThenInclude(cs => cs.MondayProducts).ThenInclude(css => css.Product)
                .Include(c => c.Monday).ThenInclude(cs => cs.MondayDishes).ThenInclude(css => css.Dish)
                .Include(c => c.Tuesday).ThenInclude(cs => cs.TuesdayProducts).ThenInclude(css => css.Product)
                .Include(c => c.Tuesday).ThenInclude(cs => cs.TuesdayDishes).ThenInclude(css => css.Dish)
                .Include(c => c.Wednesday).ThenInclude(cs => cs.WednesdayProducts).ThenInclude(css => css.Product)
                .Include(c => c.Wednesday).ThenInclude(cs => cs.WednesdayDishes).ThenInclude(css => css.Dish)
                .Include(c => c.Thursday).ThenInclude(cs => cs.ThursdayProducts).ThenInclude(css => css.Product)
                .Include(c => c.Thursday).ThenInclude(cs => cs.ThursdayDishes).ThenInclude(css => css.Dish)
                .Include(c => c.Friday).ThenInclude(cs => cs.FridayProducts).ThenInclude(css => css.Product)
                .Include(c => c.Friday).ThenInclude(cs => cs.FridayDishes).ThenInclude(css => css.Dish)
                .Include(c => c.Saturday).ThenInclude(cs => cs.SaturdayProducts).ThenInclude(css => css.Product)
                .Include(c => c.Saturday).ThenInclude(cs => cs.SaturdayDishes).ThenInclude(css => css.Dish)
                .Include(c => c.Sunday).ThenInclude(cs => cs.SundayProducts).ThenInclude(css => css.Product)
                .Include(c => c.Sunday).ThenInclude(cs => cs.SundayDishes).ThenInclude(css => css.Dish)
                .FirstOrDefault(c => c.MenuId == menu.MenuId);

            Monday monday2 = _dbContext.Mondays
                .Include(c => c.MondayProducts).ThenInclude(cs => cs.Product)
                .FirstOrDefault(c => c.MondayId == monday.MondayId);

            

            _dbContext.SaveChanges();

            return menu.MenuId.Value;
        }
    }
}
