using System.Data;
using Dapper;
using LibraryManager.Data.Models;

namespace LibraryManager.Data.Repositories.BookRepositories;

public class BookRepository : IBookRepository
{
	private readonly Func<IDbConnection> _createConnection;

	public BookRepository(Func<IDbConnection> createConnection)
	{
		_createConnection = createConnection;
	}

	public async Task<IEnumerable<Book>> GetAll()
	{
		using var connection = _createConnection();
		
		var sql = "SELECT * FROM Books";
		
		return await connection.QueryAsync<Book>(sql);
	}

	public async Task<Book> GetById(int id)
	{
		using var connection = _createConnection();
		
		var sql = "SELECT * FROM Books WHERE Id = @id";
		
		return await connection.QuerySingleOrDefaultAsync<Book>(sql, new { id });
	}

	public async Task<Book> GetByIsbn(string isbn)
	{
		using var connection = _createConnection();
		
		var sql = "SELECT * FROM Books WHERE Isbn = @isbn";
		
		return await connection.QuerySingleOrDefaultAsync<Book>(sql, new { isbn });
	}

	public async Task<Book> GetByName(string name)
	{
		using var connection = _createConnection();
		
		var sql = "SELECT * FROM Books WHERE Name = @name";
		
		return await connection.QuerySingleOrDefaultAsync<Book>(sql, new { name });
	}

	public async Task<IEnumerable<Book>> GetAllByAuthor(int authorId)
	{
		using var connection = _createConnection();
		
		var sql = "SELECT * FROM Books WHERE AuthorId = @authorId";
		
		return await connection.QueryAsync<Book>(sql, new { authorId });
	}

	public async Task<IEnumerable<Book>> GetAllByPublisher(int publisherId)
	{
		using var connection = _createConnection();
		
		var sql = "SELECT * FROM Books WHERE PublisherId = @publisherId";
		
		return await connection.QueryAsync<Book>(sql, new { publisherId });
	}

	public async Task<IEnumerable<Book>> GetAllOwned()
	{
		using var connection = _createConnection();
		
		var sql = "SELECT * FROM Books WHERE Owned = 1";
		
		return await connection.QueryAsync<Book>(sql);
	}

	public async Task<IEnumerable<Book>> GetAllLoaned()
	{
		using var connection = _createConnection();
		
		var sql = "SELECT * FROM Books WHERE Loaned = 1";
		
		return await connection.QueryAsync<Book>(sql);
	}

	public async Task<int> Create(Book book)
	{
		using var connection = _createConnection();
		
		var sql = @"
			INSERT INTO Books (Name, Isbn, AuthorId, PublisherId, Owned, Loaned)
			VALUES (@Name, @Isbn, @AuthorId, @PublisherId, @Owned, @Loaned)
		";
		
		var affectedRows = await connection.ExecuteAsync(sql, book);
		return affectedRows;
	}

	public async Task<int> Update(Book book)
	{
		using var connection = _createConnection();

		var sql = @"
			UPDATE Books
			SET Name = @Name, Isbn = @Isbn, AuthorId = @AuthorId, PublisherId = @PublisherId, Owned = @Owned, Loaned = @Loaned
			WHERE Id = @Id
			";
	
		
		var affectedRows = await connection.ExecuteAsync(sql, book);
		return affectedRows;
	}

	public async Task<int> Delete(Book book)
	{
		using var connection = _createConnection();
		
		var sql = "DELETE FROM Books WHERE Id = @Id";
		
		var affectedRows = await connection.ExecuteAsync(sql, book);
		return affectedRows;
	}
	
	public async Task<int> AddNoteToBook(int bookId, int noteId)
	{
		using var connection = _createConnection();
		var sql = "INSERT INTO BookNotes (BookId, NoteId) VALUES (@bookId, @noteId)";
		
		var affectedRows = await connection.ExecuteAsync(sql, new { bookId, noteId });
		return affectedRows;
	}
	
	public async Task<int> AddBookToLoan(int bookId, int loanId)
	{
		using var connection = _createConnection();
		var sql = "UPDATE Books SET LoanId = @loanId WHERE Id = @bookId";
		
		var affectedRows = await connection.ExecuteAsync(sql, new { bookId, loanId });
		return affectedRows;
	}
	
	public async Task<int> AddSubjectToBook(int bookId, int subjectId)
	{
		using var connection = _createConnection();
		var sql = "INSERT INTO BookSubjects (BookId, SubjectId) VALUES (@bookId, @subjectId)";
		
		var affectedRows = await connection.ExecuteAsync(sql, new { bookId, subjectId });
		return affectedRows;
	}
	
	public async Task<int> AddBookToCollection(int bookId, int collectionId)
	{
		using var connection = _createConnection();
		var sql = "INSERT INTO BookCollections (BookId, CollectionId) VALUES (@bookId, @collectionId)";
		
		var affectedRows = await connection.ExecuteAsync(sql, new { bookId, collectionId });
		return affectedRows;
	}
}