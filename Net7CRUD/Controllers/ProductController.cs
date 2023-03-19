using Microsoft.AspNetCore.Mvc;
using Net7CRUD.Business;

namespace Net7CRUD.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    [Route("AllProducts")]
    public async Task<ActionResult<List<Product>>> AllProducts()
    {
        return await _productService.AllProducts();
    }

    [HttpGet]
    [Route("GetById/{id}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var product = await _productService.ProductById(id);
        return Ok(product);
    }
    
    [HttpPost]
    [Route("Add")]
    public async Task<ActionResult<List<Product>>> AddHero(Product product)
    {
        var result = await _productService.Add(product);
        return Ok(result);
    }

    [HttpPut]
    [Route("Update")]
    public async Task<ActionResult<Product>> Update(int id, Product product)
    {
        var updateProduct = await _productService.Update(id, product);
        return Ok(updateProduct);
    }

    [HttpDelete]
    [Route("Delete/{id}")]
    public async Task<ActionResult<Product>> Delete(int id)
    {
        var deleteProduct = await _productService.Delete(id);
        return Ok(deleteProduct);
    }
}