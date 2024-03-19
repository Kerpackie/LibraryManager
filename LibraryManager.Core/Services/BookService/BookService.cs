using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Core.Services.BookService
{
	public class BookService : IBookService
	{
		private readonly LibraryContext _context;

		public BookService(LibraryContext context)
		{
			_context = context;
		}

		public async Task<Book?> CreateBookAsync(Book? book)
		{
			_context.Books.Add(book);
			await _context.SaveChangesAsync();
			return book;
		}

		public async Task<Book?> GetBookByIsbnAsync(string isbn)
		{
			return await _context.Books.FindAsync(isbn);
		}

		public async Task<IEnumerable<Book?>> GetAllBooksAsync()
		{
			return await _context.Books.ToListAsync();
		}

		public async Task<Book> UpdateBookAsync(Book book)
		{
			_context.Entry(book).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return book;
		}

		public async Task DeleteBookAsync(string isbn)
		{
			var book = await _context.Books.FindAsync(isbn);
			if (book != null)
			{
				_context.Books.Remove(book);
				await _context.SaveChangesAsync();
			}
		}
	}
}