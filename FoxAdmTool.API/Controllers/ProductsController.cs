using FoxAdmTool.API.Models;
using FoxAdmTool.API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoxAdmTool.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productsService.GetAsync(id);
            return Ok(product);
        }
        
        [HttpGet] 
        public async Task<IActionResult> GetAllProducts()
        {
            var product = await _productsService.GetAllAsync();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] Product product)
        {
            try
            {
                await _productsService.AddProduct(product);
                return Ok(product);
            } catch (Exception ex)
            {
                return StatusCode(500);
            }  
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = await _productsService.DeleteProductAsync(id);
            return Ok(response);
        }
    }
}
