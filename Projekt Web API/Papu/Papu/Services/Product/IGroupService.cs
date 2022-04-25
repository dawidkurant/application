using Papu.Models.Product;
using System.Collections.Generic;

namespace Papu.Services
{
    public interface IGroupService
    {
        IEnumerable<GroupDto> GetAllGroups();
        GroupDto GetByIdGroup(int id);
    }
}
