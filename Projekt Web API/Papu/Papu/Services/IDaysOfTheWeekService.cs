using Papu.Models;
using Papu.Models.Update.DayOfTheWeek;
using System.Collections.Generic;

namespace Papu.Services
{
    public interface IDaysOfTheWeekService
    {
        MondayDto GetByIdMonday(int id);
        IEnumerable<MondayDto> GetAllMondays();
        int CreateMonday(CreateMondayDto dtoMonday);
        bool UpdateMonday(int id, UpdateMondayDto dto);
        bool DeleteMonday(int id);
        TuesdayDto GetByIdTuesday(int id);
        IEnumerable<TuesdayDto> GetAllTuesdays();
        int CreateTuesday(CreateTuesdayDto dtoTuesday);
        bool UpdateTuesday(int id, UpdateTuesdayDto dto);
        bool DeleteTuesday(int id);
        WednesdayDto GetByIdWednesday(int id);
        IEnumerable<WednesdayDto> GetAllWednesdays();
        int CreateWednesday(CreateWednesdayDto dtoWednesday);
        bool UpdateWednesday(int id, UpdateWednesdayDto dto);
        bool DeleteWednesday(int id);
        ThursdayDto GetByIdThursday(int id);
        IEnumerable<ThursdayDto> GetAllThursdays();
        int CreateThursday(CreateThursdayDto dtoThursday);
        bool UpdateThursday(int id, UpdateThursdayDto dto);
        bool DeleteThursday(int id);
        FridayDto GetByIdFriday(int id);
        IEnumerable<FridayDto> GetAllFridays();
        int CreateFriday(CreateFridayDto dtoFriday);
        bool UpdateFriday(int id, UpdateFridayDto dto);
        bool DeleteFriday(int id);
        SaturdayDto GetByIdSaturday(int id);
        IEnumerable<SaturdayDto> GetAllSaturdays();
        int CreateSaturday(CreateSaturdayDto dtoSaturday);
        bool UpdateSaturday(int id, UpdateSaturdayDto dto);
        bool DeleteSaturday(int id);
        SundayDto GetByIdSunday(int id);
        IEnumerable<SundayDto> GetAllSundays();
        int CreateSunday(CreateSundayDto dtoSunday);
        bool UpdateSunday(int id, UpdateSundayDto dto);
        bool DeleteSunday(int id);
    }
}
