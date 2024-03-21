using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagerDevAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        // GET: api/Book
        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            await Task.Delay(1);
            
            /*// Create a book
            var book = new Book
            {
                Id = 1,
                Title = "The Hobbit",
                Author = "J.R.R. Tolkien",
                PublicationYear = 1937,
                ISBN = "978-0-395-08254-1",
                Publisher = "Houghton Mifflin",
                Genre = "Fantasy",
                NumberOfPages = 310
            };
            
            // Create a second book
            var book2 = new Book
            {
                Id = 2,
                Title = "The Fellowship of the Ring",
                Author = "J.R.R. Tolkien",
                PublicationYear = 1954,
                ISBN = "978-0-395-08254-1",
                Publisher = "Houghton Mifflin",
                Genre = "Fantasy",
                NumberOfPages = 423
            };*/
            
            // Add the books to a list
            var books = new List<Book> {  };
            
            return books;
            
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Book> Get(int id)
        {
            await Task.Delay(1);
            
            var book = new Book
            {
                /*Id = 1,
                Title = "The Hobbit",
                Author = "J.R.R. Tolkien",
                PublicationYear = 1937,
                ISBN = "978-0-395-08254-1",
                Publisher = "Houghton Mifflin",
                Genre = "Fantasy",
                NumberOfPages = 310*/
            };
            
            return book;
        }

        // POST: api/Book
        [HttpPost]
        public async Task Post([FromBody] Book value)
        {
            await Task.Delay(1);
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Book value)
        {
            await Task.Delay(1);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await Task.Delay(1);
        }
    }
}
