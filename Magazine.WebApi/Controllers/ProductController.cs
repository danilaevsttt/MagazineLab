using Magazine.Core.Models;
using Magazine.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Magazine.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> Add(Product product)
    {
        var result = await _service.AddAsync(product);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Product>> Remove(Guid id)
    {
        var result = await _service.RemoveAsync(id);
        return result == null ? NotFound() : result;
    }

    [HttpPut]
    public async Task<ActionResult<Product>> Edit(Product product)
    {
        var result = await _service.EditAsync(product);
        return result == null ? NotFound() : result;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> Get(Guid id)
    {
        var result = await _service.SearchAsync(id);
        return result == null ? NotFound() : result;
    }
}