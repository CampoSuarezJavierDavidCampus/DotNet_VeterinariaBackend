using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class CartConfiguration : IEntityTypeConfiguration<Cart>{
    public void Configure(EntityTypeBuilder<Cart> builder){
        builder.ToTable("cart");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .IsRequired()
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("idPk");
        
        builder.Property(x => x.UserId)
            .IsRequired()
            .HasColumnName("userIdFk");

        builder.HasOne(x => x.User)
            .WithMany(x => x.Carts)
            .HasForeignKey(x => x.UserId);

        builder.HasMany(p => p.Products)
            .WithMany(p => p.Carts)
            .UsingEntity<CartItem>(
                t => t.HasOne(j => j.Product)
                    .WithMany(j => j.CartItems)
                    .HasForeignKey(j => j.ProductId),

                t => t.HasOne(j => j.Cart)
                    .WithMany(j => j.CartItems)
                    .HasForeignKey(j => j.CartId),

                t => {//--Configurations
                    t.ToTable("cartItem");
                    t.HasKey(j => new{j.ProductId, j.CartId});

                    t.Property(x => x.CartId)
                        .IsRequired()
                        .HasColumnName("cartIdPK");
                    
                    t.Property(x => x.ProductId)
                        .IsRequired()
                        .HasColumnName("productIdPK");
                }                
            );
                        
        builder.HasData(
            new{
				Id = 1,
				UserId = 1
			},

            new{
				Id = 2,
				UserId = 2
			}
        );
    }
}