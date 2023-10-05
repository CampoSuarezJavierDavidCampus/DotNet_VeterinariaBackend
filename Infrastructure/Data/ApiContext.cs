using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;
public class ApiContext: DbContext{
    public ApiContext(DbContextOptions<ApiContext> opts):base(opts) { }

    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
}
