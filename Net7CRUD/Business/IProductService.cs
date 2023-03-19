namespace Net7CRUD.Business;

public interface IProductService
{
    Task<List<Product>> AllProducts();
    Task<Product?> ProductById(int id);
    Task<List<Product>> Add(Product product);
    Task<Product> Update(int id, Product product);
    Task<Product> Delete(int id);
    
}