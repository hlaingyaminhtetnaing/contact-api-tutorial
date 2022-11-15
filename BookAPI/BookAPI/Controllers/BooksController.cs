using BookAPI.Models;
using BookAPI.Respositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRespository _bookRespository;
        public BooksController(IBookRespository bookRespository)
        {
            _bookRespository = bookRespository;
        }
        [HttpGet]
        public async Task<IEnumerable<Books>> GetBooks()
        {
            return await _bookRespository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Books>> GetBooks(int id)
        {
            return await _bookRespository.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult<Books>> PostBooks([FromBody] Books book)
        {
            var newBook = await _bookRespository.Create(book);
            return CreatedAtAction(nameof(GetBooks), new { id = newBook.BookId }, newBook);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutBooks(int id,[FromBody] Books book)
        {
            if(id!=book.BookId)
            {
                return BadRequest();
            }
            await _bookRespository.Update(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var bookToDelete = await _bookRespository.Get(id);
            if (bookToDelete == null)
                return NotFound();
            await _bookRespository.Delete(bookToDelete.BookId);
            return NoContent();
        }

    }
}
