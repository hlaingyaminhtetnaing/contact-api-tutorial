using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    public class BooksContext:DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options):base(options)
        {
           Database.EnsureCreated();
        }
        public DbSet<Books> Book { get; set; }
    }
}
