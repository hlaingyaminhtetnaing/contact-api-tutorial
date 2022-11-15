using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDemo.IBAL
{
    public class IGenericBAL<TEntity>
    where TEntity : class
    {
      /*  Task<IEnumerable<TEntity>> Get();
        Task<TEntity> Get(int id);
        Task<TEntity> Create(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(int id);*/
    }
}
