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
        protected readonly MultiDbContext _db;
        private readonly DbSet<T> _dbSet;
        public Repository(MultiDbContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }
        
        public async Task<T> GetByIdAsync(Guid id)
        {
            return (await _dbSet.FindAsync(id))!;
           // return (await _db.Set<T>().FindAsync(id))!;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
           // return await _db.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return (await _dbSet.FirstOrDefaultAsync(predicate))!;
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return (await _dbSet.SingleOrDefaultAsync(predicate))!;
        }

        public async Task<IQueryable<T>> QListAsync()
        {
            return await Task.FromResult(_dbSet.AsQueryable());
            //
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task RemoveAsync(T entity)
        {
            _dbSet.Remove(entity); 
            await _db.SaveChangesAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            await _db.SaveChangesAsync();
        }

        public T Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
