using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Papu.Entities;
using Papu.Models;
using Papu.Models.Update;
using System.Collections.Generic;
using System.Linq;

namespace Papu.Services
{
    public class MenuService : IMenuService
    {

        private readonly PapuDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<MenuService> _logger;

        public MenuService(PapuDbContext dbContext, IMapper mapper, ILogger<MenuService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public MenuDto GetByIdMenu(int id)
        {
            Menu menu = _dbContext
                .Menus
                .Include(c => c.Monday)
                .Include(c => c.Tuesday)
                .Include(c => c.Wednesday)
                .Include(c => c.Thursday)
                .Include(c => c.Friday)
                .Include(c => c.Saturday)
                .Include(c => c.Sunday)
                //.Include(c => c.Monday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                //.Include(c => c.Monday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Monday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Monday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Monday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Monday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Monday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Monday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Monday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Monday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Tuesday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                //.Include(c => c.Tuesday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Tuesday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Tuesday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Tuesday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Tuesday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Tuesday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Tuesday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Tuesday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Tuesday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Wednesday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                //.Include(c => c.Wednesday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Wednesday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Wednesday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Wednesday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Wednesday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Wednesday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Wednesday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Wednesday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Wednesday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Thursday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                //.Include(c => c.Thursday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Thursday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Thursday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Thursday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Thursday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Thursday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Thursday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Thursday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Thursday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Friday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                //.Include(c => c.Friday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Friday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Friday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Friday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Friday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Friday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Friday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Friday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Friday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Saturday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                //.Include(c => c.Saturday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Saturday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Saturday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Saturday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Saturday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Saturday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Saturday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Saturday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Saturday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Sunday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                //.Include(c => c.Sunday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Sunday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Sunday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Sunday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Sunday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Sunday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Sunday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Sunday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Sunday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
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
                .Include(c => c.Monday)
                .Include(c => c.Tuesday)
                .Include(c => c.Wednesday)
                .Include(c => c.Thursday)
                .Include(c => c.Friday)
                .Include(c => c.Saturday)
                .Include(c => c.Sunday)
                //.Include(c => c.Monday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                //.Include(c => c.Monday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Monday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Monday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Monday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Monday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Monday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Monday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Monday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Monday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Tuesday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                //.Include(c => c.Tuesday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Tuesday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Tuesday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Tuesday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Tuesday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Tuesday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Tuesday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Tuesday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Tuesday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Wednesday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                //.Include(c => c.Wednesday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Wednesday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Wednesday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Wednesday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Wednesday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Wednesday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Wednesday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Wednesday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Wednesday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Thursday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                //.Include(c => c.Thursday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Thursday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Thursday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Thursday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Thursday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Thursday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Thursday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Thursday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Thursday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Friday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                //.Include(c => c.Friday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Friday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Friday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Friday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Friday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Friday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Friday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Friday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Friday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Saturday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                //.Include(c => c.Saturday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Saturday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Saturday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Saturday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Saturday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Saturday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Saturday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Saturday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Saturday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Sunday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                //.Include(c => c.Sunday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Sunday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Sunday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Sunday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Sunday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Sunday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Sunday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Sunday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Sunday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .ToList();

            var menusDto = _mapper.Map<List<MenuDto>>(menus);

            return menusDto;
        }

        public int CreateMenu(CreateMenuDto dtoMenu)
        {
            var menu = _mapper.Map<Menu>(dtoMenu);

            menu.MondayId = dtoMenu.MondayId;
            menu.TuesdayId = dtoMenu.TuesdayId;
            menu.WednesdayId = dtoMenu.WednesdayId;
            menu.ThursdayId = dtoMenu.ThursdayId;
            menu.FridayId = dtoMenu.FridayId;
            menu.SaturdayId = dtoMenu.SaturdayId;
            menu.SundayId = dtoMenu.SundayId;

            _dbContext.Menus.Add(menu);
            _dbContext.SaveChanges();

            return menu.MenuId;
        }

        public void UpdateMenu(int id, UpdateMenuDto dto)
        {
            var menu = _dbContext
                .Menus
                .Include(c => c.Monday)
                .Include(c => c.Tuesday)
                .Include(c => c.Wednesday)
                .Include(c => c.Thursday)
                .Include(c => c.Friday)
                .Include(c => c.Saturday)
                .Include(c => c.Sunday)
                //.Include(c => c.Monday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                //.Include(c => c.Monday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Monday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Monday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Monday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Monday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Monday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Monday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Monday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Monday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Tuesday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                //.Include(c => c.Tuesday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Tuesday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Tuesday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Tuesday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Tuesday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Tuesday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Tuesday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Tuesday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Tuesday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Wednesday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                //.Include(c => c.Wednesday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Wednesday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Wednesday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Wednesday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Wednesday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Wednesday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Wednesday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Wednesday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Wednesday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Thursday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                //.Include(c => c.Thursday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Thursday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Thursday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Thursday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Thursday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Thursday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Thursday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Thursday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Thursday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Friday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                //.Include(c => c.Friday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Friday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Friday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Friday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Friday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Friday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Friday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Friday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Friday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Saturday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                //.Include(c => c.Saturday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Saturday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Saturday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Saturday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Saturday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Saturday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Saturday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Saturday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Saturday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Sunday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                //.Include(c => c.Sunday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Sunday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Sunday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Sunday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Sunday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Sunday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Sunday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                //.Include(c => c.Sunday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                //.Include(c => c.Sunday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.MenuId == id);


            //Jeśli jesteśmy pewni, że dany jadłospis nie istnieje, zwracamy wyjątek
            if (menu is null)
            {
                throw new NotFoundException("Menu not found");
            }

            menu.MenuName = dto.MenuName;
            menu.MenuDescription = dto.MenuDescription;
            menu.MondayId = dto.MondayId;
            menu.TuesdayId = dto.TuesdayId;
            menu.WednesdayId = dto.WednesdayId;
            menu.ThursdayId = dto.ThursdayId;
            menu.FridayId = dto.FridayId;
            menu.SaturdayId = dto.SaturdayId;
            menu.SundayId = dto.SundayId;

            _dbContext.SaveChanges();
        }

        public bool DeleteMenu(int id)
        {
            _logger.LogError($"Menu with id: {id} DELETE action invoked");

            var menu =
                _dbContext
                .Menus
                .Include(c => c.Monday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                .Include(c => c.Monday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Monday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Monday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Monday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Monday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Monday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Monday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Monday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Monday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Tuesday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                .Include(c => c.Tuesday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Tuesday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Tuesday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Tuesday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Tuesday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Tuesday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Tuesday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Tuesday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Tuesday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Wednesday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                .Include(c => c.Wednesday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Wednesday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Wednesday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Wednesday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Wednesday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Wednesday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Wednesday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Wednesday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Wednesday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Thursday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                .Include(c => c.Thursday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Thursday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Thursday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Thursday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Thursday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Thursday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Thursday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Thursday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Thursday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Friday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                .Include(c => c.Friday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Friday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Friday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Friday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Friday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Friday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Friday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Friday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Friday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Saturday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                .Include(c => c.Saturday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Saturday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Saturday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Saturday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Saturday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Saturday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Saturday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Saturday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Saturday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Sunday).ThenInclude(cs => cs.Breakfast).ThenInclude(css => css.Products).ThenInclude(csss => csss.Product)
                .Include(c => c.Sunday).ThenInclude(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Sunday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Sunday).ThenInclude(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Sunday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Sunday).ThenInclude(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Sunday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Sunday).ThenInclude(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Sunday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Sunday).ThenInclude(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.MenuId == id);

            if (menu is null)
            {
                return false;
            }

            _dbContext.Menus.Remove(menu);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
