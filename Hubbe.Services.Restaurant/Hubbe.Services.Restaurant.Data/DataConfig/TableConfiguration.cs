using Hubbe.Services.Restaurant.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubbe.Services.Restaurant.Data.DataConfig
{
    public class TableConfiguration : IEntityTypeConfiguration<TablesEntity>
    {
        public void Configure(EntityTypeBuilder<TablesEntity> builder)
        {
            builder.ToTable("Tables");
            builder.HasKey(k => k.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Sector)
                .HasColumnType("varchar(50)");
        }
    }
}
