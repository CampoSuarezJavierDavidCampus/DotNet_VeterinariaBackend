using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>{
    public void Configure(EntityTypeBuilder<ProductCategory> builder){
        builder.ToTable("productCategory");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .IsRequired()
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("idPk");
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("name")
            .HasMaxLength(50);
        
        builder.HasData(
            new {
				Id = 1,
				Name = "Beauty"
			},

            new {
				Id = 2,
				Name = "Furniture"
			},

            new {
				Id = 3,
				Name = "Electronics"
			},
            
            new {
				Id = 4,
				Name = "Shoes"
			}
        );
    }
}