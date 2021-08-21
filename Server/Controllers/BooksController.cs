using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BlazorWasm.Server.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorWasm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BlazorDBContext _context;
        public BooksController(BlazorDBContext context)
        {
            _context = context;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public object Get()
        {
            return new { Items = _context.Book, Count = _context.Book.Count() };
        }

        // POST api/<BooksController>
        [HttpPost]
        public void Post([FromBody] Book book)
        {
            _context.Book.Add(book);
            _context.SaveChanges();
        }

        // PUT api/<BooksController>
        [HttpPut]
        public void Put(long id, [FromBody] Book book)
        {
            Book _book = _context.Book.Where(x => x.Id.Equals(book.Id)).FirstOrDefault();
            _book.Name = book.Name;
            _book.Author = book.Author;
            _book.Price = book.Price;
            _book.Quantity = book.Quantity;
            _book.Available = book.Available;
            _context.SaveChanges();
        }

        // DELETE api/<BooksController>
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            Book _book = _context.Book.Where(x => x.Id.Equals(id)).FirstOrDefault();
            _context.Book.Remove(_book);
            _context.SaveChanges();
        }
    }
}