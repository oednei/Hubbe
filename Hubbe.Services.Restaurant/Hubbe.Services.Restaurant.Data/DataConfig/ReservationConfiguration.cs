using Hubbe.Services.Restaurant.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hubbe.Services.Restaurant.Data.DataConfig
{
    public class ReservationConfiguration : IEntityTypeConfiguration<ReservationEntity>
    {
        public void Configure(EntityTypeBuilder<ReservationEntity> builder)
        {
            builder.ToTable("Reservations");
            builder.HasKey(k => k.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.NumberOfClients)
                .HasColumnType("Integer")
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnType("varchar(500)");
        }
    }
}
