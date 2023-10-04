using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;
public class ApiContext: DbContext{
    public ApiContext(DbContextOptions<ApiContext> opts):base(opts) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);
		
			//Add users
            modelBuilder.Entity<User>().HasData(          
                new{
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Bob"
                },
                new {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Sarah"
                }        
            );

			//Create Shopping Cart for Users
			//Add Product Categories
			modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
			{
				Id = 1,
				Name = "Beauty"
			});
			modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
			{
				Id = 2,
				Name = "Furniture"
			});
			modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
			{
				Id = 3,
				Name = "Electronics"
			});
			modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
			{
				Id = 4,
				Name = "Shoes"
			});
    }
}
