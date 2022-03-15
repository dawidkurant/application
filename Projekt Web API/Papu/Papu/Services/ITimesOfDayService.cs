using Papu.Models;
using Papu.Models.Update.TimesOfDay;
using System.Collections.Generic;

namespace Papu.Services
{
    public interface ITimesOfDayService
    {
        BreakfastDto GetByIdBreakfast(int id);
        IEnumerable<BreakfastDto> GetAllBreakfast();
        int CreateBreakfast(CreateBreakfastDto dtoBreakfast);
        void UpdateBreakfast(int id, UpdateBreakfastDto dtoBreakfast);
        bool DeleteBreakfast(int id);
        SecondBreakfastDto GetByIdSecondBreakfast(int id);
        IEnumerable<SecondBreakfastDto> GetAllSecondBreakfast();
        int CreateSecondBreakfast(CreateSecondBreakfastDto dtoSecondBreakfast);
        void UpdateSecondBreakfast(int id, UpdateSecondBreakfastDto dtoSecondBreakfast);
        bool DeleteSecondBreakfast(int id);
        LunchDto GetByIdLunch(int id);
        IEnumerable<LunchDto> GetAllLunch();
        int CreateLunch(CreateLunchDto dtoLunch);
        void UpdateLunch(int id, UpdateLunchDto dtoLunch);
        bool DeleteLunch(int id);
        SnackDto GetByIdSnack(int id);
        IEnumerable<SnackDto> GetAllSnack();
        int CreateSnack(CreateSnackDto dtoSnack);
        void UpdateSnack(int id, UpdateSnackDto dtoSnack);
        bool DeleteSnack(int id);
        DinnerDto GetByIdDinner(int id);
        IEnumerable<DinnerDto> GetAllDinner();
        int CreateDinner(CreateDinnerDto dtoDinner);
        void UpdateDinner(int id, UpdateDinnerDto dtoDinner);
        bool DeleteDinner(int id);
    }
}
