using LibraryManager.Core.Models;

namespace LibraryManager.Core.Services.AuthorService;

public interface IAuthorService
{
	Task<Author> CreateAuthorAsync(Author author);
	Task<Author?> GetAuthorAsync(int id);
	Task<Author?> GetAuthorByNameAsync(string name);
	Task<Author> UpdateAuthorAsync(Author author);
	Task DeleteAuthorAsync(int id);
}