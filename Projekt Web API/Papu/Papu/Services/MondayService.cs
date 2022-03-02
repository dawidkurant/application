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
                .Include(c => c.Breakfast)
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
                .Include(c => c.Breakfast)
                .ToList();

            var mondaysDtos = _mapper.Map<List<MondayDto>>(mondays);

            return mondaysDtos;
        }

        //Tworzenie nowego poniedziałku

        public int CreateMonday(CreateMondayDto dtoMonday)
        {

            var monday = _mapper.Map<Monday>(dtoMonday);

            monday.BreakfastId = dtoMonday.BreakfastMondayId;

            _dbContext.Mondays.Add(monday);
            _dbContext.SaveChanges();

            return monday.MondayId;
        }
    }
}
