using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApI.Models;

namespace WebApI.Respositories
{
    public interface ICustomerRespository
    {
        IQueryable<Customers> Get();
        Task<Customers> Get(int id);
        Task<bool> Create(Customers customers);

        Task<bool> Update(Customers customers);
        Task<bool> Delete(int id);
    }
}
