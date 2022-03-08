using Papu.Models;
using System.Collections.Generic;

namespace Papu.Services
{
    public interface IDaysOfTheWeekService
    {
        MondayDto GetByIdMonday(int id);
        IEnumerable<MondayDto> GetAllMondays();
        int CreateMonday(CreateMondayDto dtoMonday);
        bool DeleteMonday(int id);
        TuesdayDto GetByIdTuesday(int id);
        IEnumerable<TuesdayDto> GetAllTuesdays();
        int CreateTuesday(CreateTuesdayDto dtoTuesday);
        bool DeleteTuesday(int id);
        WednesdayDto GetByIdWednesday(int id);
        IEnumerable<WednesdayDto> GetAllWednesdays();
        int CreateWednesday(CreateWednesdayDto dtoWednesday);
        bool DeleteWednesday(int id);
        ThursdayDto GetByIdThursday(int id);
        IEnumerable<ThursdayDto> GetAllThursdays();
        int CreateThursday(CreateThursdayDto dtoThursday);
        bool DeleteThursday(int id);
        FridayDto GetByIdFriday(int id);
        IEnumerable<FridayDto> GetAllFridays();
        int CreateFriday(CreateFridayDto dtoFriday);
        bool DeleteFriday(int id);
        SaturdayDto GetByIdSaturday(int id);
        IEnumerable<SaturdayDto> GetAllSaturdays();
        int CreateSaturday(CreateSaturdayDto dtoSaturday);
        bool DeleteSaturday(int id);
        SundayDto GetByIdSunday(int id);
        IEnumerable<SundayDto> GetAllSundays();
        int CreateSunday(CreateSundayDto dtoSunday);
        bool DeleteSunday(int id);
    }
}
