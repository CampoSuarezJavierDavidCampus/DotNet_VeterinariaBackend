using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class RoleConfiguration : IEntityTypeConfiguration<Role>{
    public void Configure(EntityTypeBuilder<Role> builder){
        builder.ToTable("role");
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
                Name = "Administrator"
            },

            new {
                Id = 2,
                Name = "Manager"
            },

            new {
                Id = 3,
                Name = "Employee"
            }
        );
        
    }
}