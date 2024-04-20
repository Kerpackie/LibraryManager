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
	Task<int> Create(Book book);
	Task<int> Update(Book book);
	Task<int> Delete(Book book);
	Task<int> AddNoteToBook(int bookId, int noteId);
	Task<int> AddBookToLoan(int bookId, int loanId);
	Task<int> AddSubjectToBook(int bookId, int subjectId);
	Task<int> AddBookToCollection(int bookId, int collectionId);

}