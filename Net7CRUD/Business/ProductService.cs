using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Net7CRUD.DataAccess;

namespace Net7CRUD.Business;

public class ProductService : IProductService
{
    private readonly Context _context;

    public ProductService(Context context)
    {
        _context = context;
    }

    public async Task<List<Product>> AllProducts()
    {
        var products = await _context.Products.ToListAsync();
        return products;
    }

    public async Task<Product?> ProductById(int id)
    {
        var product = await _context.Products.FindAsync(id);
        return product;
    }

    public async Task<List<Product>> Add(Product product)
    {
        product.CreatedDate = DateTime.Now;
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> Update(int id, Product product)
    {
        var updateProduct = await _context.Products.FindAsync(id);
        updateProduct.Name = product.Name;
        updateProduct.Description = product.Description;
        product.CreatedDate = updateProduct.CreatedDate;
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> Delete(int id)
    {
        var deleteProduct = await _context.Products.FindAsync(id);
        if (deleteProduct != null) _context.Products.Remove(deleteProduct);
        await _context.SaveChangesAsync();
        return deleteProduct;
    }
}