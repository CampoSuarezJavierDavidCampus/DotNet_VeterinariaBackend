using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>{
    public void Configure(EntityTypeBuilder<User> builder){
        builder.ToTable("user");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.UserName)
            .IsRequired()
            .HasColumnName("userName")
            .HasMaxLength(50);
        
        builder.HasIndex(x => x.UserName)
            .IsUnique();

        builder.HasOne(x => x.Role)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.RoleId);

        builder.HasMany(p => p.Products)
        .WithMany(p => p.Users)
        .UsingEntity<CartItem>(
            t => t.HasOne(j => j.Product)
                .WithMany(j => j.CartItems)
                .HasForeignKey(j => j.ProductId),

            t => t.HasOne(j => j.User)
                .WithMany(j => j.CartItems)
                .HasForeignKey(j => j.UserId),

            t => {//--Configurations
                t.ToTable("cartItem");
                t.HasKey(j => new{j.ProductId, j.UserId});

                t.Property(x => x.UserId)
                    .IsRequired()
                    .HasColumnName("cartIdPK");
                
                t.Property(x => x.ProductId)
                    .IsRequired()
                    .HasColumnName("productIdPK");
            }                
        );    

        builder.HasData(
            new{
                Id = Guid.NewGuid().ToString(),
                CreateDate = DateTime.Now,
                UserName = "Bob",
                RoleId = 3
            },

            new {
                Id = Guid.NewGuid().ToString(),
                CreateDate = DateTime.Now,
                UserName = "Sarah",
                RoleId = 3
            } 
        );        
    }
}