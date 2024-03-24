using LibraryManager.Core.Models;

namespace LibraryManager.Core.Services.BookService
{
	public interface IBookService
	{
		public Task<ServiceResponse<Book>> LoadBookFromApiWithIsbnAsync(string isbn);
		public Task<ServiceResponse<Book>> InsertOrIgnoreBookAsync(Book book);
		public Task<ServiceResponse<Book>> GetBookByIsbnAsync(string isbn);
		public Task<ServiceResponse<Book>> GetBookAsync(long id);
		public Task<ServiceResponse<Book>> GetBookByTitleAsync(string title);
		public Task<ServiceResponse<IEnumerable<Book>>> GetBooksAsync();
		public Task<ServiceResponse<IEnumerable<Book>>> GetBooksByAuthorAsync(string authorName);
		public Task<ServiceResponse<IEnumerable<Book>>> GetBooksBySubjectAsync(string subject);
		public Task<ServiceResponse<IEnumerable<Book>>> GetBooksByPublisherAsync(string publisher);
		public Task<ServiceResponse<Book>> UpdateBookAsync(Book book);
		public Task<ServiceResponse<Book>> DeleteBookAsync(long id);
		public Task<ServiceResponse<Book>> DeleteBookByIsbnAsync(string isbn);
	}
}