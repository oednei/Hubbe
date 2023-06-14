using Hubbe.Services.Restaurant.Data.Context;
using Hubbe.Services.Restaurant.Domain.Entities;
using Hubbe.Services.Restaurant.Repositories.Base;
using Hubbe.Services.Restaurant.Repositories.Interface;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubbe.Services.Restaurant.Repositories.Repository
{
    public class TableRepository : BaseRepository<TablesEntity>, ITableRepository
    {
        private readonly DataContext _dbContext;
        public TableRepository(DataContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
