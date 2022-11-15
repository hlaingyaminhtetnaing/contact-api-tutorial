using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDemo.IRespository;
using APIDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace APIDemo.Respository
{
    public class GenericRespository<TEntity> : IGenericRespository<TEntity>
     where TEntity : class
    {
        private readonly APIDbContext _dbContext;
        public GenericRespository(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<bool> Create(TEntity entity)
        {
            try
            {
                await _dbContext.Set<TEntity>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception exception)
            {
                return false;
            }

        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var DeleteItem = await GetById(id);
                _dbContext.Set<TEntity>().Remove(DeleteItem);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetById(int? id)
        {
            return  await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<bool> Update(TEntity entity)
        {
            try
            {
                _dbContext.Set<TEntity>().Update(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
