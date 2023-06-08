using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _dataRepository;
        public ProductController(IProductRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/Product
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Product> products = _dataRepository.GetAll();
            return Ok(products);
        }
        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            Product product = _dataRepository.Get(id);
            if (product == null)
            {
                return NotFound("The Product record couldn't be found.");
            }
            return Ok(product);
        }

        [HttpGet("categoryId/{categoryId}", Name = "GetbyCategoryId")]
        public IActionResult GetByCategoryId(int categoryId)
        {
            IEnumerable<Product> products = _dataRepository.GetByCategoryId(categoryId);
            if (products == null || products.Count() == 0)
            {
                return NotFound("The Product record couldn't be found.");
            }
            return Ok(products);
        }
        [HttpGet("GetbyName")]
        public IActionResult GetByCategoryName(string categoryName)
        {
            IEnumerable<Product> products = _dataRepository.GetByName(categoryName);
            if (products == null)
            {
                return NotFound("The Product record couldn't be found.");
            }
            return Ok(products);
        }
        // POST: api/Produ
        // POST: api/Product
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product is null.");
            }
            _dataRepository.Add(product);
            return CreatedAtRoute(
                  "Get",
                  new { Id = product.Id },
                  product);
        }
        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product is null.");
            }
            Product productToUpdate = _dataRepository.Get(id);
            if (productToUpdate == null)
            {
                return NotFound("The Product record couldn't be found.");
            }
            _dataRepository.Update(productToUpdate, product);
            return NoContent();
        }
        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Product product = _dataRepository.Get(id);
            if (product == null)
            {
                return NotFound("The Product record couldn't be found.");
            }
            _dataRepository.Delete(product);
            return NoContent();
        }
    }
}