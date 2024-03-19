using LibraryManager.Core.Models;

namespace LibraryManager.Core.Services.BookService
{
	public interface IBookService
	{
		Task<Book?> CreateBookAsync(Book? book);
		Task<Book?> GetBookByIsbnAsync(string isbn);
		Task<IEnumerable<Book?>> GetAllBooksAsync();
		Task<Book> UpdateBookAsync(Book book);
		Task DeleteBookAsync(string isbn);
	}
}