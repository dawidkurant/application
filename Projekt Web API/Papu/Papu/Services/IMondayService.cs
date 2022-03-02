using Papu.Models;
using System.Collections.Generic;

namespace Papu.Services
{
    public interface IMondayService
    {
        MondayDto GetByIdMonday(int id);
        IEnumerable<MondayDto> GetAllMondays();
        int CreateMonday(CreateMondayDto dto);
    }
}
