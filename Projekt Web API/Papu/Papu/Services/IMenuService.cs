using Papu.Models;
using Papu.Models.Update;
using System.Collections.Generic;
using System.Security.Claims;

namespace Papu.Services
{
    public interface IMenuService
    {
        MenuDto GetByIdMenu(int id);
        IEnumerable<MenuDto> GetAllMenus();
        int CreateMenu(CreateMenuDto dtoMenu);
        void UpdateMenu(int id, UpdateMenuDto dto);
        void DeleteMenu(int id);
    }
}
