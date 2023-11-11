using Papu.Models;
using System.Collections.Generic;

namespace Papu.Services
{
    public interface IMenuService
    {
        MenuDto GetMenuById(int id);
        IEnumerable<MenuDto> GetAllMenus();
        int CreateMenu(CreateMenuDto dtoMenu);
        void UpdateMenu(int id, UpdateMenuDto dto);
        void DeleteMenu(int id);
    }
}
