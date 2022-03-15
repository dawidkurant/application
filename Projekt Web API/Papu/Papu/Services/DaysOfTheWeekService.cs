using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Papu.Entities;
using Papu.Exceptions;
using Papu.Models;
using Papu.Models.Update.DayOfTheWeek;
using System.Collections.Generic;
using System.Linq;

namespace Papu.Services
{
    public class DaysOfTheWeekService : IDaysOfTheWeekService
    {

        private readonly PapuDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<DaysOfTheWeekService> _logger;

        public DaysOfTheWeekService(PapuDbContext dbContext, IMapper mapper, ILogger<DaysOfTheWeekService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        //Wyświetlanie jednego poniedziałku

        public MondayDto GetByIdMonday(int id)
        {
            Monday monday = _dbContext
                .Mondays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.MondayId == id);


            if (monday is null)
            {
                return null;
            }

            var result = _mapper.Map<MondayDto>(monday);

            return result;
        }

        //Wyświetlanie wszystkich poniedziałków

        public IEnumerable<MondayDto> GetAllMondays()
        {
            var mondays = _dbContext
                .Mondays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .ToList();

            var mondaysDtos = _mapper.Map<List<MondayDto>>(mondays);

            return mondaysDtos;
        }

        //Tworzenie nowego poniedziałku

        public int CreateMonday(CreateMondayDto dtoMonday)
        {
            var monday = _mapper.Map<Monday>(dtoMonday);

            monday.BreakfastId = dtoMonday.BreakfastMondayId;
            monday.SecondBreakfastId = dtoMonday.SecondBreakfastMondayId;
            monday.LunchId = dtoMonday.LunchMondayId;
            monday.SnackId = dtoMonday.SnackMondayId;
            monday.DinnerId = dtoMonday.DinnerMondayId;

            _dbContext.Mondays.Add(monday);
            _dbContext.SaveChanges();

            return monday.MondayId;
        }

        //Edycja poniedziałku
        public void UpdateMonday(int id, UpdateMondayDto dto)
        {
            var monday = _dbContext
                .Mondays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.MondayId == id);


            //Jeśli jesteśmy pewni, że dany poniedziałek nie istnieje, zwracamy wyjątek
            if (monday is null)
            {
                throw new NotFoundException("Monday not found");
            }

            monday.BreakfastId = dto.BreakfastMondayId;
            monday.SecondBreakfastId = dto.SecondBreakfastMondayId;
            monday.LunchId = dto.LunchMondayId;
            monday.SnackId = dto.SnackMondayId;
            monday.DinnerId = dto.DinnerMondayId;

            _dbContext.SaveChanges();
        }

        //Usuwanie poniedziałku
        public bool DeleteMonday(int id)
        {
            _logger.LogError($"Monday with id: {id} DELETE action invoked");

            var monday = _dbContext
                .Mondays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.MondayId == id);

            if (monday is null)
            {
                return false;
            }

            _dbContext.Mondays.Remove(monday);
            _dbContext.SaveChanges();

            return true;
        }

        //Wyświetlanie jednego wtorku
        public TuesdayDto GetByIdTuesday(int id)
        {
            Tuesday tuesday = _dbContext
                .Tuesdays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.TuesdayId == id);


            if (tuesday is null)
            {
                return null;
            }

            var result = _mapper.Map<TuesdayDto>(tuesday);

            return result;
        }

        //Wyświetlanie wszystkich wtorków
        public IEnumerable<TuesdayDto> GetAllTuesdays()
        {
            var tuesdays = _dbContext
                .Tuesdays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .ToList();

            var tuesdaysDtos = _mapper.Map<List<TuesdayDto>>(tuesdays);

            return tuesdaysDtos;
        }

        //Tworzenie nowego wtorku
        public int CreateTuesday(CreateTuesdayDto dtoTuesday)
        {
            var tuesday = _mapper.Map<Tuesday>(dtoTuesday);

            tuesday.BreakfastId = dtoTuesday.BreakfastTuesdayId;
            tuesday.SecondBreakfastId = dtoTuesday.SecondBreakfastTuesdayId;
            tuesday.LunchId = dtoTuesday.LunchTuesdayId;
            tuesday.SnackId = dtoTuesday.SnackTuesdayId;
            tuesday.DinnerId = dtoTuesday.DinnerTuesdayId;

            _dbContext.Tuesdays.Add(tuesday);
            _dbContext.SaveChanges();

            return tuesday.TuesdayId;
        }

        //Edycja wtorku
        public void UpdateTuesday(int id, UpdateTuesdayDto dto)
        {
            var tuesday = _dbContext
                .Tuesdays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.TuesdayId == id);


            //Jeśli jesteśmy pewni, że dany wtorek nie istnieje, zwracamy wyjątek
            if (tuesday is null)
            {
                throw new NotFoundException("Tuesday not found");
            }

            tuesday.BreakfastId = dto.BreakfastTuesdayId;
            tuesday.SecondBreakfastId = dto.SecondBreakfastTuesdayId;
            tuesday.LunchId = dto.LunchTuesdayId;
            tuesday.SnackId = dto.SnackTuesdayId;
            tuesday.DinnerId = dto.DinnerTuesdayId;

            _dbContext.SaveChanges();
        }

        //Usuwanie wtorku
        public bool DeleteTuesday(int id)
        {
            _logger.LogError($"Tuesday with id: {id} DELETE action invoked");

            var tuesday = _dbContext
                .Tuesdays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.TuesdayId == id);

            if (tuesday is null)
            {
                return false;
            }

            _dbContext.Tuesdays.Remove(tuesday);
            _dbContext.SaveChanges();

            return true;
        }

        //Wyświetlanie jednej środy
        public WednesdayDto GetByIdWednesday(int id)
        {
            Wednesday wednesday = _dbContext
                .Wednesdays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.WednesdayId == id);


            if (wednesday is null)
            {
                return null;
            }

            var result = _mapper.Map<WednesdayDto>(wednesday);

            return result;
        }

        //Wyświetlanie wszystkich śród
        public IEnumerable<WednesdayDto> GetAllWednesdays()
        {
            var wednesdays = _dbContext
                .Wednesdays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .ToList();

            var wednesdaysDtos = _mapper.Map<List<WednesdayDto>>(wednesdays);

            return wednesdaysDtos;
        }

        //Tworzenie nowej środy
        public int CreateWednesday(CreateWednesdayDto dtoWednesday)
        {
            var wednesday = _mapper.Map<Wednesday>(dtoWednesday);

            wednesday.BreakfastId = dtoWednesday.BreakfastWednesdayId;
            wednesday.SecondBreakfastId = dtoWednesday.SecondBreakfastWednesdayId;
            wednesday.LunchId = dtoWednesday.LunchWednesdayId;
            wednesday.SnackId = dtoWednesday.SnackWednesdayId;
            wednesday.DinnerId = dtoWednesday.DinnerWednesdayId;

            _dbContext.Wednesdays.Add(wednesday);
            _dbContext.SaveChanges();

            return wednesday.WednesdayId;
        }

        //Edycja środy
        public void UpdateWednesday(int id, UpdateWednesdayDto dto)
        {
            var wednesday = _dbContext
                .Wednesdays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.WednesdayId == id);


            //Jeśli jesteśmy pewni, że dana środa nie istnieje, zwracamy wyjątek
            if (wednesday is null)
            {
                throw new NotFoundException("Wednesday not found");
            }

            wednesday.BreakfastId = dto.BreakfastWednesdayId;
            wednesday.SecondBreakfastId = dto.SecondBreakfastWednesdayId;
            wednesday.LunchId = dto.LunchWednesdayId;
            wednesday.SnackId = dto.SnackWednesdayId;
            wednesday.DinnerId = dto.DinnerWednesdayId;

            _dbContext.SaveChanges();
        }

        //Usuwanie środy
        public bool DeleteWednesday(int id)
        {
            _logger.LogError($"Wednesday with id: {id} DELETE action invoked");

            var wednesday = _dbContext
                .Wednesdays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.WednesdayId == id);

            if (wednesday is null)
            {
                return false;
            }

            _dbContext.Wednesdays.Remove(wednesday);
            _dbContext.SaveChanges();

            return true;
        }

        //Wyświetlanie jednego czwartku
        public ThursdayDto GetByIdThursday(int id)
        {
            Thursday thursday = _dbContext
                .Thursdays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.ThursdayId == id);


            if (thursday is null)
            {
                return null;
            }

            var result = _mapper.Map<ThursdayDto>(thursday);

            return result;
        }

        //Wyświetlanie wszystkich czwartków
        public IEnumerable<ThursdayDto> GetAllThursdays()
        {
            var thursdays = _dbContext
                .Thursdays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .ToList();

            var thursdaysDtos = _mapper.Map<List<ThursdayDto>>(thursdays);

            return thursdaysDtos;
        }

        //Tworzenie nowego czwartku
        public int CreateThursday(CreateThursdayDto dtoThursday)
        {
            var thursday = _mapper.Map<Thursday>(dtoThursday);

            thursday.BreakfastId = dtoThursday.BreakfastThursdayId;
            thursday.SecondBreakfastId = dtoThursday.SecondBreakfastThursdayId;
            thursday.LunchId = dtoThursday.LunchThursdayId;
            thursday.SnackId = dtoThursday.SnackThursdayId;
            thursday.DinnerId = dtoThursday.DinnerThursdayId;

            _dbContext.Thursdays.Add(thursday);
            _dbContext.SaveChanges();

            return thursday.ThursdayId;
        }

        //Edycja czwartku
        public void UpdateThursday(int id, UpdateThursdayDto dto)
        {
            var thursday = _dbContext
                .Thursdays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.ThursdayId == id);


            //Jeśli jesteśmy pewni, że dany czwartek nie istnieje, zwracamy wyjątek
            if (thursday is null)
            {
                throw new NotFoundException("Thursday not found");
            }

            thursday.BreakfastId = dto.BreakfastThursdayId;
            thursday.SecondBreakfastId = dto.SecondBreakfastThursdayId;
            thursday.LunchId = dto.LunchThursdayId;
            thursday.SnackId = dto.SnackThursdayId;
            thursday.DinnerId = dto.DinnerThursdayId;

            _dbContext.SaveChanges();
        }

        //Usuwanie czwartku
        public bool DeleteThursday(int id)
        {
            _logger.LogError($"Thursday with id: {id} DELETE action invoked");

            var thursday = _dbContext
                .Thursdays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.ThursdayId == id);

            if (thursday is null)
            {
                return false;
            }

            _dbContext.Thursdays.Remove(thursday);
            _dbContext.SaveChanges();

            return true;
        }

        //Wyświetlanie jednego piątku
        public FridayDto GetByIdFriday(int id)
        {
            Friday friday = _dbContext
                .Fridays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.FridayId == id);


            if (friday is null)
            {
                return null;
            }

            var result = _mapper.Map<FridayDto>(friday);

            return result;
        }

        //Wyświetlanie wszystkich piątków
        public IEnumerable<FridayDto> GetAllFridays()
        {
            var fridays = _dbContext
                .Fridays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .ToList();

            var fridaysDtos = _mapper.Map<List<FridayDto>>(fridays);

            return fridaysDtos;
        }

        //Tworzenie nowego piątku
        public int CreateFriday(CreateFridayDto dtoFriday)
        {
            var friday = _mapper.Map<Friday>(dtoFriday);

            friday.BreakfastId = dtoFriday.BreakfastFridayId;
            friday.SecondBreakfastId = dtoFriday.SecondBreakfastFridayId;
            friday.LunchId = dtoFriday.LunchFridayId;
            friday.SnackId = dtoFriday.SnackFridayId;
            friday.DinnerId = dtoFriday.DinnerFridayId;

            _dbContext.Fridays.Add(friday);
            _dbContext.SaveChanges();

            return friday.FridayId;
        }

        //Edycja piątku
        public void UpdateFriday(int id, UpdateFridayDto dto)
        {
            var friday = _dbContext
                .Fridays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.FridayId == id);


            //Jeśli jesteśmy pewni, że dany piątek nie istnieje, zwracamy wyjątek
            if (friday is null)
            {
                throw new NotFoundException("Friday not found");
            }

            friday.BreakfastId = dto.BreakfastFridayId;
            friday.SecondBreakfastId = dto.SecondBreakfastFridayId;
            friday.LunchId = dto.LunchFridayId;
            friday.SnackId = dto.SnackFridayId;
            friday.DinnerId = dto.DinnerFridayId;

            _dbContext.SaveChanges();
        }

        //Usuwanie piątku
        public bool DeleteFriday(int id)
        {
            _logger.LogError($"Friday with id: {id} DELETE action invoked");

            var friday = _dbContext
                .Fridays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.FridayId == id);

            if (friday is null)
            {
                return false;
            }

            _dbContext.Fridays.Remove(friday);
            _dbContext.SaveChanges();

            return true;
        }

        //Wyświetlanie jednej soboty
        public SaturdayDto GetByIdSaturday(int id)
        {
            Saturday saturday = _dbContext
                .Saturdays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.SaturdayId == id);


            if (saturday is null)
            {
                return null;
            }

            var result = _mapper.Map<SaturdayDto>(saturday);

            return result;
        }

        //Wyświetlanie wszystkich sobót
        public IEnumerable<SaturdayDto> GetAllSaturdays()
        {
            var saturdays = _dbContext
                .Saturdays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .ToList();

            var saturdaysDtos = _mapper.Map<List<SaturdayDto>>(saturdays);

            return saturdaysDtos;
        }

        //Tworzenie nowej soboty
        public int CreateSaturday(CreateSaturdayDto dtoSaturday)
        {
            var saturday = _mapper.Map<Saturday>(dtoSaturday);

            saturday.BreakfastId = dtoSaturday.BreakfastSaturdayId;
            saturday.SecondBreakfastId = dtoSaturday.SecondBreakfastSaturdayId;
            saturday.LunchId = dtoSaturday.LunchSaturdayId;
            saturday.SnackId = dtoSaturday.SnackSaturdayId;
            saturday.DinnerId = dtoSaturday.DinnerSaturdayId;

            _dbContext.Saturdays.Add(saturday);
            _dbContext.SaveChanges();

            return saturday.SaturdayId;
        }

        //Edycja soboty
        public void UpdateSaturday(int id, UpdateSaturdayDto dto)
        {
            var saturday = _dbContext
                .Saturdays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.SaturdayId == id);


            //Jeśli jesteśmy pewni, że dana sobota nie istnieje, zwracamy wyjątek
            if (saturday is null)
            {
                throw new NotFoundException("Saturday not found");
            }

            saturday.BreakfastId = dto.BreakfastSaturdayId;
            saturday.SecondBreakfastId = dto.SecondBreakfastSaturdayId;
            saturday.LunchId = dto.LunchSaturdayId;
            saturday.SnackId = dto.SnackSaturdayId;
            saturday.DinnerId = dto.DinnerSaturdayId;

            _dbContext.SaveChanges();
        }

        //Usuwanie soboty
        public bool DeleteSaturday(int id)
        {
            _logger.LogError($"Saturday with id: {id} DELETE action invoked");

            var saturday = _dbContext
                .Saturdays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.SaturdayId == id);

            if (saturday is null)
            {
                return false;
            }

            _dbContext.Saturdays.Remove(saturday);
            _dbContext.SaveChanges();

            return true;
        }

        //Wyświetlanie jednej niedzieli
        public SundayDto GetByIdSunday(int id)
        {
            Sunday sunday = _dbContext
                .Sundays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.SundayId == id);


            if (sunday is null)
            {
                return null;
            }

            var result = _mapper.Map<SundayDto>(sunday);

            return result;
        }

        //Wyświetlanie wszystkich niedziel
        public IEnumerable<SundayDto> GetAllSundays()
        {
            var sundays = _dbContext
                .Sundays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .ToList();

            var sundaysDtos = _mapper.Map<List<SundayDto>>(sundays);

            return sundaysDtos;
        }

        //Tworzenie nowej niedzieli
        public int CreateSunday(CreateSundayDto dtoSunday)
        {
            var sunday = _mapper.Map<Sunday>(dtoSunday);

            sunday.BreakfastId = dtoSunday.BreakfastSundayId;
            sunday.SecondBreakfastId = dtoSunday.SecondBreakfastSundayId;
            sunday.LunchId = dtoSunday.LunchSundayId;
            sunday.SnackId = dtoSunday.SnackSundayId;
            sunday.DinnerId = dtoSunday.DinnerSundayId;

            _dbContext.Sundays.Add(sunday);
            _dbContext.SaveChanges();

            return sunday.SundayId;
        }

        //Edycja niedzieli
        public void UpdateSunday(int id, UpdateSundayDto dto)
        {
            var sunday = _dbContext
                .Sundays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.SundayId == id);


            //Jeśli jesteśmy pewni, że dana niedziela nie istnieje, zwracamy wyjątek
            if (sunday is null)
            {
                throw new NotFoundException("Sunday not found");
            }

            sunday.BreakfastId = dto.BreakfastSundayId;
            sunday.SecondBreakfastId = dto.SecondBreakfastSundayId;
            sunday.LunchId = dto.LunchSundayId;
            sunday.SnackId = dto.SnackSundayId;
            sunday.DinnerId = dto.DinnerSundayId;

            _dbContext.SaveChanges();
        }

        //Usuwanie niedzieli
        public bool DeleteSunday(int id)
        {
            _logger.LogError($"Sunday with id: {id} DELETE action invoked");

            var sunday = _dbContext
                .Sundays
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Breakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.SecondBreakfast).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Lunch).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Snack).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Snack).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dinner).ThenInclude(cs => cs.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.SundayId == id);

            if (sunday is null)
            {
                return false;
            }

            _dbContext.Sundays.Remove(sunday);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
