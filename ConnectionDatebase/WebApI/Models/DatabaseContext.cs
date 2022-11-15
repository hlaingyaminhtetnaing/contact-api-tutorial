using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApI.Models
{
    public class DatabaseContext : DbContext
    {
        private DatabaseContext databaseContext;

        public DatabaseContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Customers> customers { get; set; }
    }
}
