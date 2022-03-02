using Papu.Models;
using System.Collections.Generic;

namespace Papu.Services
{
    public interface ITimesOfDayService
    {
        BreakfastDto GetByIdBreakfast(int id);
        IEnumerable<BreakfastDto> GetAllBreakfast();
        int CreateBreakfast(CreateBreakfastDto dtoBreakfast);
        SecondBreakfastDto GetByIdSecondBreakfast(int id);
        IEnumerable<SecondBreakfastDto> GetAllSecondBreakfast();
        int CreateSecondBreakfast(CreateSecondBreakfastDto dtoSecondBreakfast);
        LunchDto GetByIdLunch(int id);
        IEnumerable<LunchDto> GetAllLunch();
        int CreateLunch(CreateLunchDto dtoLunch);
        SnackDto GetByIdSnack(int id);
        IEnumerable<SnackDto> GetAllSnack();
        int CreateSnack(CreateSnackDto dtoSnack);
        DinnerDto GetByIdDinner(int id);
        IEnumerable<DinnerDto> GetAllDinner();
        int CreateDinner(CreateDinnerDto dtoDinner);
    }
}
