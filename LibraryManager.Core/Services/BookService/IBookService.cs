using LibraryManager.Core.Models;

namespace LibraryManager.Core.Services.BookService
{
	public interface IBookService
	{
		Task<Book?> CreateBookAsync(Book? book);
		Task<Book?> GetBookAsync(int id);
		Task<Book?> GetBookByIsbnAsync(string isbn);
		Task<IEnumerable<Book?>> GetAllBooksAsync();
		Task<IEnumerable<Book?>> GetBooksByAuthorAsync(string author);
		Task<IEnumerable<Book?>> GetBooksByTitleAsync(string title);
		Task<IEnumerable<Book?>> GetBooksByPublisherAsync(string publisher);
		Task<IEnumerable<Book?>> GetBooksByGenreAsync(string genre);
		Task<IEnumerable<Book?>> GetBooksByPublicationYearAsync(int publicationYear);
		Task<IEnumerable<Book?>> GetBooksByNumberOfPagesAsync(int numberOfPages);
		Task<IEnumerable<Book?>> GetBooksWithMorePagesThanAsync(int numberOfPages);
		Task<IEnumerable<Book?>> GetBooksWithLessPagesThanAsync(int numberOfPages);
		Task<Book?> UpdateBookAsync(Book book);
		Task DeleteBookAsync(int id);
		Task DeleteBookByIsbnAsync(string isbn);
	}
}