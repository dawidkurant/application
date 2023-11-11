using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Papu.Entities;
using Papu.Exceptions;
using Papu.Models;
using System.Collections.Generic;
using System.Linq;

namespace Papu.Services
{
    public class MenuService : IMenuService
    {

        private readonly PapuDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<MenuService> _logger;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;

        public MenuService(PapuDbContext dbContext, IMapper mapper, ILogger<MenuService> logger,
            IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }

        public int CreateMenu(CreateMenuDto dtoMenu)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteMenu(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<MenuDto> GetAllMenus()
        {
            throw new System.NotImplementedException();
        }

        public MenuDto GetMenuById(int id)
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
                .FirstOrDefault(c => c.MenuId == id) ?? throw new NotFoundException("Menu not found");
            
            var result = _mapper.Map<MenuDto>(menu);

            return result;
        }

        public void UpdateMenu(int id, UpdateMenuDto dto)
        {
            throw new System.NotImplementedException();
        }
    }
}