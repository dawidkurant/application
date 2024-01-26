using Papu.Models;
using System.Collections.Generic;

namespace Papu.Services
{
    public interface IMenuService
    {
        MenuDto GetByIdMenu(int id);
        IEnumerable<MenuDto> GetAllMenu();
        int CreateMenu(CreateMenuDto dtoMenu);
        void UpdateMenu(int id, UpdateMenuDto dtoMenu);
        void DeleteMenu(int id);
    }
}
