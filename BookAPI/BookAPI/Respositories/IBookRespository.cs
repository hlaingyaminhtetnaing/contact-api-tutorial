using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Respositories
{
   public interface IBookRespository
    {
        Task<IEnumerable<Books>> Get();
        Task<Books> Get(int id);
        Task<Books> Create(Books book);
        Task Update(Books book);
        Task Delete(int id);
    }
}
