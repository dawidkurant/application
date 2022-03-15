using Papu.Models;
using Papu.Models.Update;
using System.Collections.Generic;

namespace Papu.Services
{
    public interface IMenuService
    {
        MenuDto GetByIdMenu(int id);
        IEnumerable<MenuDto> GetAllMenus();
        int CreateMenu(CreateMenuDto dtoMenu);
        bool UpdateMenu(int id, UpdateMenuDto dto);
        bool DeleteMenu(int id);
    }
}
