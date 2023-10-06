using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class MedicineConfiguration : IEntityTypeConfiguration<Medicine>{
    public void Configure(EntityTypeBuilder<Medicine> builder){
        builder.ToTable("Medicamento");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .IsRequired()
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("ID_MedicamentoPK");

        builder.Property(x => x.LaboratoryId)
            .IsRequired()
            .HasColumnName("ID_LaboratorioFk");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Nombre")
            .HasMaxLength(50);
        
        builder.Property(x => x.Stock)
            .IsRequired()
            .HasColumnName("CantidadDisponible");

        builder.Property(x => x.Price)
            .IsRequired()
            .HasColumnName("Precio");
        
        builder.HasOne(x => x.Laboratory)
            .WithMany(x => x.Medicines)
            .HasForeignKey(x => x.LaboratoryId);

        builder.HasMany(p => p.Suppliers)
            .WithMany(p => p.Medicines)
            .UsingEntity<MedicationsSuppliers>(
                t => t.HasOne(j => j.Supplier)
                    .WithMany(j => j.MedicationsSuppliers)
                    .HasForeignKey(j => j.SupplierId),
                t => t.HasOne(j => j.Medicines)
                    .WithMany(j => j.MedicationsSuppliers)
                    .HasForeignKey(j => j.MedicinesId),
                t => {//--Configurations
                    t.ToTable("MedicamentosProveedores");
                    t.HasKey(j => new{j.SupplierId,j.MedicinesId});
                    
                    t.Property(x => x.SupplierId)
                        .HasColumnName("ID_proveedorPK");

                    t.Property(x => x.MedicinesId)
                        .HasColumnName("ID_MedicamentoPK");
                }
            );

            builder.HasData(
                //-La santé
                new{
                    Id=1,
                    Name = "Ampicilina",
                    Stock = 14,
                    Price =(float) 12500,
                    LaboratoryId = 3
                },
                new{
                    Id=2,
                    Name = "Hidrocortizona",
                    Stock = 50,
                    Price =(float) 5500,
                    LaboratoryId = 3
                },
                new{
                    Id=3,
                    Name = "Lorataina",
                    Stock = 30,
                    Price =(float) 3300,
                    LaboratoryId = 3
                },

                //-MK
                new{
                    Id=4,
                    Name = "Diclofenalco",
                    Stock = 114,
                    Price =(float) 7800,
                    LaboratoryId = 2
                },
                new{
                    Id=5,
                    Name = "Fluoxetina",
                    Stock = 150,
                    Price =(float) 15500,
                    LaboratoryId = 2
                },
                new{
                    Id=6,
                    Name = "Acetamenophen",
                    Stock = 130,
                    Price =(float) 4400,
                    LaboratoryId = 2
                },
                //-Genfar
                new{
                    Id=7,
                    Name = "Ibuprofeno",
                    Stock = 114,
                    Price =(float) 10500,
                    LaboratoryId = 1
                },
                new{
                    Id=8,
                    Name = "Omeprazol",
                    Stock = 10,
                    Price =(float) 3500,
                    LaboratoryId = 1
                },
                new{
                    Id=9,
                    Name = "Naproxeno",
                    Stock = 430,
                    Price =(float) 6500,
                    LaboratoryId = 1
                }
            );
    }
}