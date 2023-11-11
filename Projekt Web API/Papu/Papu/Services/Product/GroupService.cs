using AutoMapper;
using Papu.Entities;
using Papu.Exceptions;
using Papu.Models.Product;
using System.Collections.Generic;
using System.Linq;

namespace Papu.Services
{
    public class GroupService : IGroupService
    {
        private readonly PapuDbContext _dbContext;
        private readonly IMapper _mapper;

        public GroupService(PapuDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //Pobranie jednej grupy po id 
        public GroupDto GetByIdGroup(int id)
        {
            Group group =
                _dbContext.Groups
                .FirstOrDefault(c => c.GroupId == id) ?? throw new NotFoundException("Group not found");
            
            var result = _mapper.Map<GroupDto>(group);

            return result;
        }

        //Pobieranie wszystkich grup z bazy danych
        public IEnumerable<GroupDto> GetAllGroups()
        {
            var groups = _dbContext
                .Groups
                .ToList();

            var groupsDtos = _mapper.Map<List<GroupDto>>(groups);

            return groupsDtos;
        }
    }
}
