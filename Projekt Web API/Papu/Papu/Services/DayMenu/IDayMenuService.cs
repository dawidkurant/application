using Papu.Models;
using System.Collections.Generic;

namespace Papu.Services
{
    public interface IDayMenuService
    {
        DayMenuDto GetByIdDayMenu(int id);
        IEnumerable<DayMenuDto> GetAllDayMenu();
        int CreateDayMenu(CreateDayMenuDto dtoDayMenu);
        void UpdateDayMenu(int id, UpdateDayMenuDto dtoDayMenu);
        void DeleteDayMenu(int id);
    }
}
