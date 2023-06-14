using Hubbe.Services.Restaurant.Data.DataConfig;
using Hubbe.Services.Restaurant.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Hubbe.Services.Restaurant.Data.Context
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ReservationEntity>(new ReservationConfiguration().Configure);
            builder.Entity<TablesEntity>(new TableConfiguration().Configure);
            base.OnModelCreating(builder);
        }
    }
}
