using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MultiCoreApp.Core.IntRepository;

namespace MultiCoreApp.DataAccessLayer.Repository
{
    public class Repository<T>:IRepository<T> where T:class
    {
        private readonly MultiDbContext _db;
        private readonly DbSet<T> _dbSet;
        public Repository(MultiDbContext db, DbSet<T> dbSet)
        {
            _db = db;
            _dbSet = dbSet;
        }
        
        public async Task<T> GetByIdAsync(int id)
        {
            return (await _dbSet.FindAsync(id))!;
           // return (await _db.Set<T>().FindAsync(id))!;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
           // return await _db.Set<T>().ToListAsync();
        }

        public Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> QListAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
