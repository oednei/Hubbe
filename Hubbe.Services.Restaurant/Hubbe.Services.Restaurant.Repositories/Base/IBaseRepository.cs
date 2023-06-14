using Hubbe.Services.Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubbe.Services.Restaurant.Repositories.Base
{
    public interface IBaseRepository<T>where T : class
    {
        Task Insert(T entity);
        Task Update(int ID, T entity);
        Task Delete(int ID);
        Task<IEnumerable<T>> GetAll();
        Task<T> FindById(int ID);
    }
}
