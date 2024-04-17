using LibraryManager.Data.Models;

namespace LibraryManager.Data.Repositories.AuthorRepositories;

public interface IAuthorRepository
{
	Task<IEnumerable<Author>> GetAll();
	Task<Author> GetById(int id);
	Task<Author> GetByName(string name);
	Task<int> Create(Author author);
	Task<int> Update(Author author);
	Task<int> Delete(int id);
	Task<IEnumerable<Author>> GetAuthorsByBookId(int bookId);
	Task<int> AddAuthorToBook(int bookId, int authorId);
}