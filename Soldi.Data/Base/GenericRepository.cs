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
        public void Create(T entity)
        {
          db.Add(entity);
        }

        public void CreateRange(List<T> entity)
        {
            db.AddRange(entity);
        }

        public void Delete(T entity)
        {
            db.Remove(entity);
        }

        public  void DeleteRange(List<T> entity)
        {
           db.RemoveRange(entity);
        }
        public  void Update(T entity)
        {
            db.Update(entity);
        }

        public  void UpdateRange(List<T> entity)
        {
            db.UpdateRange(entity);
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
