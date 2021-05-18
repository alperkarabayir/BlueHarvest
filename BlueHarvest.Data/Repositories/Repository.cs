using BlueHarvest.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueHarvest.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly BlueHarvestDbContext Context;

        public Repository(BlueHarvestDbContext context)
        {
            this.Context = context;
        }
        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }
        public async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }
        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }
        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
