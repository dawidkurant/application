using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Papu.Entities;
using Papu.Models;
using System.Collections.Generic;
using System.Linq;

namespace Papu.Controllers
{
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly PapuDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductController(PapuDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //Pobranie wszystkich produktów z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetAll()
        {
            var products = _dbContext
                .Products
                .Include(r => r.Groups)
                .ToList();

            var productsDtos = _mapper.Map<List<ProductDto>>(products);

            return Ok(productsDtos);
        }

        //Pobranie konkretnego produktu
        [HttpGet("{id}")]
        public ActionResult<ProductDto> Get([FromRoute] int id)
        {
            var product = _dbContext
                .Products
                .Include(r => r.Groups)
                .FirstOrDefault(r => r.ProductId == id);

            if (product is null)
            {
                return NotFound();
            }

            var productDto = _mapper.Map<ProductDto>(product);

            return Ok(productDto);
        }
    }
}
