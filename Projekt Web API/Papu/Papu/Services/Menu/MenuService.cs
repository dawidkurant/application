using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Papu.Authorization;
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

        // Wyświetlanie jednego jadłospisu
        public MenuDto GetByIdMenu(int id)
        {
            Menu menu = _dbContext
                .Menus
                .Include(c => c.Days)
                    .ThenInclude(cs => cs.Meals)
                        .ThenInclude(css => css.ProductMeals)
                            .ThenInclude(csss => csss.Product)
                .Include(c => c.Days)
                    .ThenInclude(cs => cs.Meals)
                        .ThenInclude(css => css.DishMeals)
                            .ThenInclude(csss => csss.Dish)
                                .ThenInclude(cssss => cssss.DishProducts)
                                    .ThenInclude(cssss => cssss.Product)
                .FirstOrDefault(c => c.MenuId == id) ?? throw new NotFoundException("Menu not found");

            var result = _mapper.Map<MenuDto>(menu);
            return result;
        }

        // Wyświetlanie wszystkich jadłospisów
        public IEnumerable<MenuDto> GetAllMenu()
        {
            var menus = _dbContext
                .Menus
                .Include(c => c.Days)
                    .ThenInclude(cs => cs.Meals)
                        .ThenInclude(css => css.ProductMeals)
                            .ThenInclude(csss => csss.Product)
                .Include(c => c.Days)
                    .ThenInclude(cs => cs.Meals)
                        .ThenInclude(css => css.DishMeals)
                            .ThenInclude(csss => csss.Dish)
                                .ThenInclude(cssss => cssss.DishProducts)
                                    .ThenInclude(cssss => cssss.Product)
                .ToList();

            var menusDto = _mapper.Map<List<MenuDto>>(menus);

            return menusDto;
        }

        // Tworzenie nowego jadłospisu
        public int CreateMenu(CreateMenuDto dtoMenu)
        {
            var menu = _mapper.Map<Menu>(dtoMenu);
            menu.Days = new List<DayMenu>(); // Inicjalizacja listy dni dla danego jadłospisu 

            // Dostaniemy informację jaki użytkownik stworzył konkretny jadłospis w bazie danych
            menu.CreatedById = 1;

            if (dtoMenu.DayMenuId is null)
            {
                dtoMenu.DayMenuId = new int[] { 1 };
            }

            foreach (var addDayMenu in dtoMenu.DayMenuId)
            {
                DayMenu dayMenu = _dbContext.DaysMenu
                    .FirstOrDefault(s => s.DayMenuId == addDayMenu);

                menu.Days.Add(dayMenu);

                dayMenu.Menu = menu;

                _dbContext.Menus.Add(menu);
            }

            _dbContext.SaveChanges();

            return menu.MenuId;
        }

        // Edycja jadłospisu
        public void UpdateMenu(int id, UpdateMenuDto dtoMenu)
        {
            var menu = _dbContext
                .Menus
                .Include(c => c.Days)
                    .ThenInclude(cs => cs.Meals)
                        .ThenInclude(css => css.ProductMeals)
                            .ThenInclude(csss => csss.Product)
                .Include(c => c.Days)
                    .ThenInclude(cs => cs.Meals)
                        .ThenInclude(css => css.DishMeals)
                            .ThenInclude(csss => csss.Dish)
                                .ThenInclude(cssss => cssss.DishProducts)
                                    .ThenInclude(cssss => cssss.Product)
                .FirstOrDefault(c => c.MenuId == id) ?? throw new NotFoundException("Menu not found");

            // Sprawdzamy czy to użytkownik który stworzył dany jadłospis chce go zmodyfikować
            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User,
                menu, new ResourceOperationRequirement(ResourceOperation.Update)).Result;

            // Sprawdzamy czy autoryzacja użytkownika nie powiodła się
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("This menu is not your");
            }

            foreach (var old in menu.Days)
            {
                _dbContext.DaysMenu.Remove(old);
            }

            menu.Days.Clear();

            foreach (var addDayMenu in dtoMenu.DayMenuId)
            {
                DayMenu dayMenu = _dbContext.DaysMenu
                    .FirstOrDefault(s => s.DayMenuId == addDayMenu);

                _dbContext.Menus.Add(menu);
            }

            _dbContext.SaveChanges();
        }

        // Usuwanie jadłospisu
        public void DeleteMenu(int id)
        {
            _logger.LogError($"Menu with id: {id} DELETE action invoked");

            var menu = _dbContext
                .Menus
                .Include(c => c.Days)
                .FirstOrDefault(c => c.MenuId == id) ?? throw new NotFoundException("Menu not found");

            // Sprawdzamy czy to użytkownik który stworzył dany jadłospis chce go zmodyfikować
            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User,
                menu, new ResourceOperationRequirement(ResourceOperation.Delete)).Result;

            // Sprawdzamy czy autoryzacja użytkownika nie powiodła się
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("This menu is not your");
            }

            _dbContext.Menus.Remove(menu);
            _dbContext.SaveChanges();
        }
    }
}
