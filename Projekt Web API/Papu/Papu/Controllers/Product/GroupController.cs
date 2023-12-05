using Microsoft.AspNetCore.Mvc;
using Papu.Models.Product;
using Papu.Services;
using System.Collections.Generic;

namespace Papu.Controllers
{
    [Route("api/group")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        // Pobranie konkretnej grupy
        [HttpGet("{id}")]
        public ActionResult<GroupDto> GetGroup([FromRoute] int id)
        {
            var group = _groupService.GetByIdGroup(id);

            return Ok(group);
        }

        // Pobranie wszystkich grup z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet]
        public ActionResult<IEnumerable<GroupDto>> GetAllCategories()
        {
            var groupsDtos = _groupService.GetAllGroups();

            return Ok(groupsDtos);
        }
    }
}
