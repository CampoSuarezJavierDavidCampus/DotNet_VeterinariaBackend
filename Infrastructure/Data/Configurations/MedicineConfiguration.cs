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

                    t.Property(x => x.Medicines)
                        .HasColumnName("ID_MedicamentoPK");
                }
            );
    }
}