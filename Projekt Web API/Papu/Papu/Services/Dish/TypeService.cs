using AutoMapper;
using Papu.Entities;
using Papu.Exceptions;
using Papu.Models.Dish;
using System.Collections.Generic;
using System.Linq;

namespace Papu.Services
{
    public class TypeService : ITypeService
    {
        private readonly PapuDbContext _dbContext;
        private readonly IMapper _mapper;

        public TypeService(PapuDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //Pobranie jednego typu po id 
        public TypeDto GetByIdType(int id)
        {
            Type type =
            _dbContext.Types
            .FirstOrDefault(c => c.TypeId == id) ?? throw new NotFoundException("Type not found");
            
            var result = _mapper.Map<TypeDto>(type);

            return result;
        }

        //Pobieranie wszystkich typów z bazy danych
        public IEnumerable<TypeDto> GetAllTypes()
        {
            var types = _dbContext
            .Types
            .ToList();

            var typesDtos = _mapper.Map<List<TypeDto>>(types);

            return typesDtos;
        }
    }
}
