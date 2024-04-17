using LibraryManager.Core.Models;
using LibraryManager.Core.Models.OpenLibraryResponseModels;

namespace LibraryManager.Core.Services.AuthorService;

public interface IAuthorService
{
	Task<ServiceResponse<Author>> InsertOrIgnoreAuthorAsync(Author author);
	Task<ServiceResponse<Author>> GetAuthorAsync(long id);
	Task<ServiceResponse<List<Author>>> GetAllAuthorsAsync();
	Task<ServiceResponse<Author>> GetAuthorByNameAsync(string name);
	Task<ServiceResponse<Author>> UpdateAuthorAsync(Author author);
	Task<ServiceResponse<bool>> DeleteAuthorAsync(long id);
	Task<ServiceResponse<bool>> DeleteAuthorAsync(string name);
}