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
    }
}