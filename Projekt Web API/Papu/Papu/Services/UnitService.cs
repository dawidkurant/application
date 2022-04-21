using AutoMapper;
using Microsoft.Extensions.Logging;
using Papu.Entities;
using Papu.Exceptions;
using Papu.Models.Product;
using System.Collections.Generic;
using System.Linq;

namespace Papu.Services
{
    public class UnitService : IUnitService
    {
        private readonly PapuDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<UnitService> _logger;

        public UnitService(PapuDbContext dbContext, IMapper mapper, ILogger<UnitService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        //Pobranie jednej jednostki po id 
        public UnitDto GetByIdUnit(int id)
        {
            Unit unit =
                _dbContext.Units
                .FirstOrDefault(c => c.UnitId == id);


            if (unit is null)
            {
                throw new NotFoundException("Unit not found");
            }

            var result = _mapper.Map<UnitDto>(unit);

            return result;
        }

        //Pobieranie wszystkich jednostek z bazy danych
        public IEnumerable<UnitDto> GetAllUnits()
        {
            var units = _dbContext
                .Units
                .ToList();

            var unitsDtos = _mapper.Map<List<UnitDto>>(units);

            return unitsDtos;
        }
    }
}
