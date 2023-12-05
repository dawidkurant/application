using Microsoft.AspNetCore.Mvc;
using Papu.Models.Product;
using Papu.Services;
using System.Collections.Generic;

namespace Papu.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // Pobranie konkretnej kategorii
        [HttpGet("{id}")]
        public ActionResult<CategoryDto> GetCategory([FromRoute] int id)
        {
            var category = _categoryService.GetByIdCategory(id);

            return Ok(category);
        }

        // Pobranie wszystkich kategorii z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> GetAllCategories()
        {
            var categoriesDtos = _categoryService.GetAllCategories();

            return Ok(categoriesDtos);
        }
    }
}
