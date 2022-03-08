using Papu.Models;
using System.Collections.Generic;

namespace Papu.Services
{
    public interface ITimesOfDayService
    {
        BreakfastDto GetByIdBreakfast(int id);
        IEnumerable<BreakfastDto> GetAllBreakfast();
        int CreateBreakfast(CreateBreakfastDto dtoBreakfast);
        bool DeleteBreakfast(int id);
        SecondBreakfastDto GetByIdSecondBreakfast(int id);
        IEnumerable<SecondBreakfastDto> GetAllSecondBreakfast();
        int CreateSecondBreakfast(CreateSecondBreakfastDto dtoSecondBreakfast);
        bool DeleteSecondBreakfast(int id);
        LunchDto GetByIdLunch(int id);
        IEnumerable<LunchDto> GetAllLunch();
        int CreateLunch(CreateLunchDto dtoLunch);
        bool DeleteLunch(int id);
        SnackDto GetByIdSnack(int id);
        IEnumerable<SnackDto> GetAllSnack();
        int CreateSnack(CreateSnackDto dtoSnack);
        bool DeleteSnack(int id);
        DinnerDto GetByIdDinner(int id);
        IEnumerable<DinnerDto> GetAllDinner();
        int CreateDinner(CreateDinnerDto dtoDinner);
        bool DeleteDinner(int id);
    }
}
