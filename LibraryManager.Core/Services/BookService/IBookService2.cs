using LibraryManager.Core.Models;

namespace LibraryManager.Core.Services.BookService;

public interface IBookService2
{
	Task<Book> GetBookFromApiAsync(string isbn);
	Task<ServiceResponse<Book>> AddBookAsync(Book book);
	Task<Book> AddBookAsync2(Book book);
	Task<ServiceResponse<Book>> UpdateBookAsync(Book book);
	Task<Book?> GetBookAsync(int id);
	Task<Book?> GetBookByIsbnAsync(string isbn);
}