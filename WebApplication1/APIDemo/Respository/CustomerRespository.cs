using APIDemo.IRespository;
using APIDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDemo.Respository
{
    public class CustomerRespository:GenericRespository<Customers>, ICustomerRespository
    {
        private readonly APIDbContext _dbContext;
        public CustomerRespository(APIDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
