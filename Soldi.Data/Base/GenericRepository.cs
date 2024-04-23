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
    public class GenericRepository<T> : IRepository<T> where T : Entity
    {
        private readonly SoldiDbContext db;
        public GenericRepository(SoldiDbContext db)
        {
            this.db = db;
        }
        public async Task<bool> CreateAsync(T entity)
        {
          await db.AddAsync(entity);
           return await db.SaveChangesAsync()==1;
        }

        public async Task<bool> CreateRangeAsync(List<T> entity)
        {
          await  db.AddRangeAsync(entity);
            return await db.SaveChangesAsync()==1;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            await DeleteAsync(entity);
            return await db.SaveChangesAsync()==1;
        }

        public async Task<bool> DeleteRangeAsync(List<T> entity)
        {
           await DeleteRangeAsync(entity);
            return await db.SaveChangesAsync()==1;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
          return await db.Set<T>().AsNoTracking().ToListAsync();
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
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

        public Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRangeAsync(List<T> entity)
        {
            throw new NotImplementedException();
        }
    }
}
