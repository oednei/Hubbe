using Hubbe.Services.Restaurant.Data.Context;
using Hubbe.Services.Restaurant.Domain.Entities;
using Hubbe.Services.Restaurant.Repositories.Base;
using Hubbe.Services.Restaurant.Repositories.Interface;


namespace Hubbe.Services.Restaurant.Repositories.Repository
{
    public class ReservartionRepository : BaseRepository<ReservationEntity>, IReservationRepository
    {
        private readonly DataContext _dbContext;

        public ReservartionRepository(DataContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
