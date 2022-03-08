using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Papu.Entities;
using Papu.Models;
using Papu.Services;
using System.Collections.Generic;
using System.Linq;

namespace Papu.Controllers
{
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //Pobranie konkretnego produktu
        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProduct([FromRoute] int id)
        {
            var product = _productService.GetByIdProduct(id);

            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        //Pobranie wszystkich produktów z bazy i zwrócenie ich do klienta z kodem 200 czyli OK
        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetAllProducts()
        {
            var productsDtos = _productService.GetAllProducts();

            return Ok(productsDtos);
        }

        //Tworzenie nowego produktu
        [HttpPost]
        public ActionResult CreateProduct([FromBody] CreateProductDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newProductId = _productService.CreateProduct(dto);

            //Jako pierwszy parametr ścieżka, a jako drugi
            //możemy zwrócić ciało odpowiedzi, ale w tym wypadku zwracamy null
            return Created($"api/product/{newProductId}", null);
        }

        //Usuwanie produktu
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct([FromRoute] int id)
        {
            var isDeleted = _productService.DeleteProduct(id);

            //operacja zakończona sukcesem
            if (isDeleted)
            {
                return NoContent();
            }

            //nie odnaleziono
            return NotFound();
        }
    }
}
