using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TCCS.DataAccess.Interfaces;
using TCCS.DataAccess.Models;

namespace TCCS.DataAccess.Repositories
{
    public class Repository<TEntity, TType> : IRepository<TEntity, TType> where TEntity : class
    {

        private TccsContext _context;

        public Repository(TccsContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var res = await _context.Set<TEntity>().ToListAsync();
            return res;
        }

        public async Task<TEntity> GetById(TType id)
        {
            var res = await _context.Set<TEntity>().FindAsync(id);
            return res;
        }

        public async Task<IEnumerable<TEntity>> GetById(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }



        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var result = await _context.Set<TEntity>().AddAsync(entity);
            return result.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            var res = _context.Set<TEntity>().Update(entity);
            return res.Entity;
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task RemoveById(TType id)
        {
            var entity = await GetById(id);
            Remove(entity);
        }




        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }



        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }




        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().UpdateRange(entities);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
