using BookAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Respositories
{
    public class BookRespository : IBookRespository
    {
        private readonly BooksContext _booksContext;
        public BookRespository(BooksContext booksContext)
        {
            _booksContext = booksContext;
        }
        public async Task<Books> Create(Books book)
        {
            _booksContext.Book.Add(book);
            await _booksContext.SaveChangesAsync();
            return book;
        }

        public async Task Delete(int id)
        {
            var DeleteId = await _booksContext.Book.FindAsync();
            _booksContext.Book.Remove(DeleteId);
            await _booksContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Books>> Get()
        {
            return await _booksContext.Book.ToListAsync();
        }

        public async Task<Books> Get(int id)
        {
            return await _booksContext.Book.FindAsync(id);
        }

        public async Task Update(Books book)
        {
            _booksContext.Entry(book).State = EntityState.Modified;
            await _booksContext.SaveChangesAsync();
        }
    }
}
