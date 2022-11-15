using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApI.Models;
using WebApI.Respositories;

namespace WebApI.BAL
{
    public class CustomerBAl : ICustomerBAL
    {
        private readonly ICustomerRespository _customerRespository;

        public CustomerBAl(ICustomerRespository customerRespository)
        {
            _customerRespository = customerRespository;
        }
        public async Task<bool> Create(Customers customers)
        {
            try {
                // var NewCustomer=_customerRespository.Create(customers);
                Customers newCustomer = new Customers()
                {
                    CustomerName = customers.CustomerName,
                    CustomerAddress = customers.CustomerAddress,
                    CustomerPhNo = customers.CustomerPhNo

                };
                var NewCustomer= await _customerRespository.Create(customers);
                return NewCustomer;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Customers> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Customers> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Customers customers)
        {
            throw new NotImplementedException();
        }
    }
}
