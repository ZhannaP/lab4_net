using DAL.Base;
using DAL.Context;
using DAL.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{

    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly TheatreContext context;
        protected readonly DbSet<T> dbSet;

        public GenericRepository(TheatreContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);

            await SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            dbSet.Update(entity);

            await SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity is not null)
            {
                dbSet.Remove(entity);

                await SaveChangesAsync();
            }
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }

}
