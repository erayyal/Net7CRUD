using Microsoft.EntityFrameworkCore;

namespace Net7CRUD.DataAccess;

public class Context:DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }
}