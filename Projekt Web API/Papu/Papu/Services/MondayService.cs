using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Papu.Entities;
using Papu.Models;
using System.Collections.Generic;
using System.Linq;

namespace Papu.Services
{
    public class MondayService : IMondayService
    {

        private readonly PapuDbContext _dbContext;
        private readonly IMapper _mapper;

        public MondayService(PapuDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

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
    }
}
