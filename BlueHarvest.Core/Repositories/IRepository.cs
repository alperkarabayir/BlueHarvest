using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueHarvest.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task AddAsync(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        Task<int> SaveChangesAsync();
    }
}
