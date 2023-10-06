using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>{
    public void Configure(EntityTypeBuilder<User> builder){
        builder.ToTable("user");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("ID_UsuarioPK");                
        
        builder.Property(x => x.UserName)
            .IsRequired()
            .HasColumnName("Nombre")
            .HasMaxLength(50);
        
        builder.HasIndex(x => x.UserName)
            .IsUnique();
         
        builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnName("CorreoElectronico")
            .HasMaxLength(100);
        
        builder.Property(x => x.Password)
            .IsRequired()
            .HasColumnName("Contraseña")
            .HasMaxLength(200);

       builder.HasMany(p => p.Roles)
        .WithMany(p => p.Users)
        .UsingEntity<UserRoles>(
            t => t.HasOne(j => j.Role)
                .WithMany(j => j.UserRoles)
                .HasForeignKey(j => j.RoleId),
            t => t.HasOne(j => j.User)
                .WithMany(j => j.UserRoles)
                .HasForeignKey(j => j.UserId),
            t => {//--Configurations
                t.ToTable("RolesUsuarios");
                t.HasKey(j => new{j.RoleId,j.UserId});
       
                t.Property(x => x.UserId)
                    .HasColumnName("ID_UsuarioPK");

                t.Property(x => x.RoleId)
                    .HasColumnName("ID_RolPK");
            }
        );
    }
}