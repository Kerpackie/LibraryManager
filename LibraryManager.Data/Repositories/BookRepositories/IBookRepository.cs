using System.Collections;
using LibraryManager.Data.Models;

namespace LibraryManager.Data.Repositories.BookRepositories;

public interface IBookRepository
{
	Task<IEnumerable<Book>> GetAll();
	Task<Book> GetById(int id);
	Task<Book> GetByIsbn(string isbn);
	Task<Book> GetByName(string name);
	Task<IEnumerable<Book>> GetAllByAuthor(int authorId);
	Task<IEnumerable<Book>> GetAllByPublisher(int publisherId);
	Task<IEnumerable<Book>> GetAllOwned();
	Task<IEnumerable<Book>> GetAllLoaned();
	Task Create(Book book);
	Task Update(Book book);
	Task Delete(Book book);
	Task AddNoteToBook(int bookId, int noteId);
	Task AddBookToLoan(int bookId, int loanId);
	Task AddSubjectToBook(int bookId, int subjectId);
	Task AddBookToCollection(int bookId, int collectionId);

}