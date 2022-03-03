using Papu.Models;
using System.Collections.Generic;

namespace Papu.Services
{
    public interface IDaysOfTheWeekService
    {
        MondayDto GetByIdMonday(int id);
        IEnumerable<MondayDto> GetAllMondays();
        int CreateMonday(CreateMondayDto dtoMonday);
        TuesdayDto GetByIdTuesday(int id);
        IEnumerable<TuesdayDto> GetAllTuesdays();
        int CreateTuesday(CreateTuesdayDto dtoTuesday);
        WednesdayDto GetByIdWednesday(int id);
        IEnumerable<WednesdayDto> GetAllWednesdays();
        int CreateWednesday(CreateWednesdayDto dtoWednesday);
        ThursdayDto GetByIdThursday(int id);
        IEnumerable<ThursdayDto> GetAllThursdays();
        int CreateThursday(CreateThursdayDto dtoThursday);
        FridayDto GetByIdFriday(int id);
        IEnumerable<FridayDto> GetAllFridays();
        int CreateFriday(CreateFridayDto dtoFriday);
        SaturdayDto GetByIdSaturday(int id);
        IEnumerable<SaturdayDto> GetAllSaturdays();
        int CreateSaturday(CreateSaturdayDto dtoSaturday);
        SundayDto GetByIdSunday(int id);
        IEnumerable<SundayDto> GetAllSundays();
        int CreateSunday(CreateSundayDto dtoSunday);
    }
}
