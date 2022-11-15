using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApI.Models;
namespace WebApI.Respositories
{
    public class CustomerRespository : DatabaseContext, ICustomerRespository
    {
        private readonly DatabaseContext _dBContext;
        public CustomerRespository(DatabaseContext databaseContext) :base(databaseContext)
        {
            _dBContext = databaseContext;
        }
      

        public async Task<bool> Create(Customers customers)
        {
            try
            {
                await _dBContext.Set<Customers>().AddAsync(customers);
                await _dBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var DeleteItems = await Get(id);
               _dBContext.Set<Customers>().Remove(DeleteItems);
                await _dBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public  IQueryable<Customers> Get()
        {
            return _dBContext.Set<Customers>().AsNoTracking();
        }

        public async Task<Customers> Get(int id)
        {
            return await _dBContext.Set<Customers>().FindAsync(id);
        }

        public async Task<bool> Update(Customers customers)
        {
            try
            {
                _dBContext.Set<Customers>().Update(customers);
                await _dBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
    }
}
