using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tenant_api.Models;

namespace tenant_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
    public IActionResult GetProducts()
    {
        var products = new List<string> { "Product1", "Product2", "Product3" };
        return Ok(products);
    }

    [HttpPost]
    public IActionResult CreateProduct([FromBody] Product product)
    {
        // Save the product to the database
        return CreatedAtAction(nameof(GetProducts), new { id = product.ProductId }, product);
    }
    }
}