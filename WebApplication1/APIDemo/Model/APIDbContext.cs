using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDemo.Model
{
    public class APIDbContext:DbContext

    {
        public APIDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Customers> Book { get; set; }
    }
}
