using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using LibraryManager.Core.Services.OpenLibraryAPIService;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Core.Services.BookService
{
	public class BookService : IBookService
	{
		private readonly LibraryContext _context;
		private readonly IOpenLibraryApiService _openLibraryApiService;

		public BookService(LibraryContext context, IOpenLibraryApiService openLibraryApiService)
		{
			_context = context;
			_openLibraryApiService = openLibraryApiService;
		}

		public async Task<Book> GetBookFromApiAsync(string isbn)
		{
			// Get the response from the API
			var response = await _openLibraryApiService.GetBookByIsbn(isbn);

			if (response != null && response.ContainsKey($"ISBN:{isbn}"))
			{
				return new Book(response[$"ISBN:{isbn}"]);
			}
			else
			{
				Console.WriteLine("Book not found in the API.");
				return null;
			}
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
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Book?>> GetBooksByGenreAsync(string genre)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Book?>> GetBooksByPublicationYearAsync(string publicationYear)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Book?>> GetBooksByNumberOfPagesAsync(int numberOfPages)
		{
			return await _context.Books.Where(b => b.PageCount == numberOfPages).ToListAsync();
		}

		public async Task<IEnumerable<Book?>> GetBooksWithMorePagesThanAsync(int numberOfPages)
		{
			return await _context.Books.Where(b => b.PageCount > numberOfPages).ToListAsync();
		}

		public async Task<IEnumerable<Book?>> GetBooksWithLessPagesThanAsync(int numberOfPages)
		{
			return await _context.Books.Where(b => b.PageCount < numberOfPages).ToListAsync();
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
				dbBook.Publisher = book.Publisher;
				dbBook.PageCount = book.PageCount;
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