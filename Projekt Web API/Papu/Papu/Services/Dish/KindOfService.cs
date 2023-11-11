using AutoMapper;
using Papu.Entities;
using Papu.Exceptions;
using Papu.Models.Dish;
using System.Collections.Generic;
using System.Linq;

namespace Papu.Services
{
    public class KindOfService : IKindOfService
    {
        private readonly PapuDbContext _dbContext;
        private readonly IMapper _mapper;

        public KindOfService(PapuDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //Pobranie jednego rodzaju po id 
        public KindOfDto GetByIdKindOf(int id)
        {
            KindOf kindOf =
            _dbContext.KindsOf
            .FirstOrDefault(c => c.KindOfId == id) ?? throw new NotFoundException("Kind of not found");
            
            var result = _mapper.Map<KindOfDto>(kindOf);

            return result;
        }

        //Pobieranie wszystkich rodzajów z bazy danych
        public IEnumerable<KindOfDto> GetAllKindsOf()
        {
            var kindsOf = _dbContext
            .KindsOf
            .ToList();

            var kindsOfDtos = _mapper.Map<List<KindOfDto>>(kindsOf);

            return kindsOfDtos;
        }
    }
}
