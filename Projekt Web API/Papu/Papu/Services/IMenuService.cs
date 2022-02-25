using Papu.Models;
using System.Collections.Generic;

namespace Papu.Services
{
    public interface IMenuService
    {
        MenuDto GetByIdMenu(int id);
        IEnumerable<MenuDto> GetAllMenus();
        int CreateMenu(CreateMenuDto dto);
    }
}
