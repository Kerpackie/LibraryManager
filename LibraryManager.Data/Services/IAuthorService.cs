using LibraryManager.Data.Models;

namespace LibraryManager.Data.Services;

public interface IAuthorService
{
	Task<ServiceResponse<Author>> CreateAuthorAsync(Author author);
	Task<ServiceResponse<Author>> GetAuthorAsync(int id);
	Task<ServiceResponse<List<Author>>> GetAllAuthorsAsync();
	Task<ServiceResponse<Author>> GetAuthorByNameAsync(string name);
	Task<ServiceResponse<Author>> UpdateAuthorAsync(Author author);
	Task<ServiceResponse<bool>> DeleteAuthorAsync(int id);
	Task<ServiceResponse<bool>> DeleteAuthorAsync(string name);
	Task<ServiceResponse<bool>> AddAuthorToBookAsync(Book book, Author author);
}