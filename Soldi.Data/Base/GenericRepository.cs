using Microsoft.EntityFrameworkCore;
using Soldi.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Data.Base
{
    public abstract class GenericRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly SoldiDbContext db;
        public GenericRepository(SoldiDbContext db)
        {
            this.db = db;
        }
        public async Task<bool> CreateAsync(T entity)
        {
          db.Add(entity);
           return await db.SaveChangesAsync()==1;
        }

        public async Task<bool> CreateRangeAsync(List<T> entity)
        {
            db.AddRange(entity);
            return await db.SaveChangesAsync()==1;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            db.Remove(entity);
            return await db.SaveChangesAsync()==1;
        }

        public async Task<bool> DeleteRangeAsync(List<T> entity)
        {
           db.RemoveRange(entity);
            return await db.SaveChangesAsync()==1;
        }
        public async Task<bool> UpdateAsync(T entity)
        {
            db.Update(entity);
            return await db.SaveChangesAsync() == 1;
        }

        public async Task<bool> UpdateRangeAsync(List<T> entity)
        {
            db.UpdateRange(entity);
            return await db.SaveChangesAsync() == 1;
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
          return await db.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await db.Set<T>().AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<T>> GetEnumerableByQueryAsync(Expression<Func<T, bool>> expression)
        {
            return await db.Set<T>().AsNoTracking().Where(expression).ToListAsync();
        }

        public async Task<IQueryable<T>> GetQueriableByQueryAsync(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
            //  return await db.Set<T>().AsNoTracking().Where(expression).ToListAsync();
        }

      
    }
}
