using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class MovementMedicineDetailConfiguration : IEntityTypeConfiguration<MovementMedicineDetail>{
    public void Configure(EntityTypeBuilder<MovementMedicineDetail> builder){
        builder.ToTable("DetalleMovimiento");
        builder.HasKey(x => new{ x.MedicineId, x.MovementMedicineId});

        builder.Property(x => x.MedicineId)
            .IsRequired()
            .HasColumnName("ID_ProductoPK");

        builder.Property(x => x.MovementMedicineId)
            .IsRequired()
            .HasColumnName("ID_MovMedPK");

        builder.Property(x => x.Quantity)
            .IsRequired()
            .HasColumnName("Cantidad");
        
        builder.Property(x => x.Price)
            .IsRequired()
            .HasColumnName("Precio");
        
        builder.HasOne(x => x.Medicine)
            .WithMany(x => x.MovementMedicineDetails)
            .HasForeignKey(x => x.MedicineId);

        builder.HasOne(x => x.MovementMedicine)
            .WithMany(x => x.MovementMedicineDetails)
            .HasForeignKey(x => x.MovementMedicineId);
    }
}