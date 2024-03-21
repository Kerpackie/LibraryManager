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

		public async Task<Book?> GetBookAsync(int id)
		{
			return await _context.Books.FindAsync(id);
		}

		public async Task<Book?> GetBookByIsbnAsync(string isbn)
		{
			return await _context.Books.FirstOrDefaultAsync(b => b.ISBN == isbn);
		}

		public async Task<IEnumerable<Book?>> GetAllBooksAsync()
		{
			return await _context.Books.ToListAsync();
		}

		public async Task<IEnumerable<Book?>> GetBooksByAuthorAsync(string author)
		{
			return await _context.Books.Where(b => b.Author == author).ToListAsync();
			
		}

		public async Task<IEnumerable<Book?>> GetBooksByTitleAsync(string title)
		{
			return await _context.Books.Where(b => b.Title == title).ToListAsync();
		}

		public async Task<IEnumerable<Book?>> GetBooksByPublisherAsync(string publisher)
		{
			return await _context.Books.Where(b => b.Publisher == publisher).ToListAsync();
		}

		public async Task<IEnumerable<Book?>> GetBooksByGenreAsync(string genre)
		{
			return await _context.Books.Where(b => b.Genre.Name == genre).ToListAsync();
		}

		public async Task<IEnumerable<Book?>> GetBooksByPublicationYearAsync(int publicationYear)
		{
			return await _context.Books.Where(b => b.PublicationYear == publicationYear).ToListAsync();
		}

		public async Task<IEnumerable<Book?>> GetBooksByNumberOfPagesAsync(int numberOfPages)
		{
			return await _context.Books.Where(b => b.NumberOfPages == numberOfPages).ToListAsync();
		}

		public async Task<IEnumerable<Book?>> GetBooksWithMorePagesThanAsync(int numberOfPages)
		{
			return await _context.Books.Where(b => b.NumberOfPages > numberOfPages).ToListAsync();
		}

		public async Task<IEnumerable<Book?>> GetBooksWithLessPagesThanAsync(int numberOfPages)
		{
			return await _context.Books.Where(b => b.NumberOfPages < numberOfPages).ToListAsync();
		}

		public async Task<Book?> UpdateBookAsync(Book book)
		{
			var dbBook = await _context.Books.FindAsync(book.Id);

			if (dbBook != null)
			{
				dbBook.Id = book.Id;
				dbBook.ISBN = book.ISBN;
				dbBook.Title = book.Title;
				dbBook.Author = book.Author;
				dbBook.PublicationYear = book.PublicationYear;
				dbBook.Publisher = book.Publisher;
				dbBook.Genre = book.Genre;
				dbBook.NumberOfPages = book.NumberOfPages;
			}

			await _context.SaveChangesAsync();
			return dbBook;
		}

		public async Task DeleteBookAsync(int id)
		{
			var book = await _context.Books.FindAsync(id);
			if (book != null)
			{
				_context.Books.Remove(book);
				await _context.SaveChangesAsync();
			}
		}

		public async Task DeleteBookByIsbnAsync(string isbn)
		{
			var book = await _context.Books.FirstOrDefaultAsync(b => b.ISBN == isbn);
			if (book != null)
			{
				_context.Books.Remove(book);
				await _context.SaveChangesAsync();
			}
		}
	}
}