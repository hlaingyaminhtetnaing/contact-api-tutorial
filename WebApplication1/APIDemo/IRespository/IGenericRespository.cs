using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDemo.IRespository
{
     public interface IGenericRespository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll(); 
        Task<bool> Create(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(int id);
        Task<TEntity> GetById(int? id);
    }
}
