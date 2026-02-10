using Microsoft.AspNetCore.Mvc;
using ProductPulseServer.Application.DTOs;
using ProductPulseServer.Application.Interfaces;
using ProductPulseServer.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductPulseServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Add(ProductDto productDto)
        {
            var product = await _productService.AddProductAsync(productDto);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Update(int id, ProductDto productDto)
        {
            var product = await _productService.UpdateProductAsync(id, productDto);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _productService.DeleteProductAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
