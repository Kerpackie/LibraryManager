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

	public async Task Create(Book book)
	{
		using var connection = _createConnection();
		
		var sql = @"
			INSERT INTO Books (Name, Isbn, AuthorId, PublisherId, Owned, Loaned)
			VALUES (@Name, @Isbn, @AuthorId, @PublisherId, @Owned, @Loaned)
		";
		
		await connection.ExecuteAsync(sql, book);
	}

	public async Task Update(Book book)
	{
		using var connection = _createConnection();

		var sql = @"
			UPDATE Books
			SET Name = @Name, Isbn = @Isbn, AuthorId = @AuthorId, PublisherId = @PublisherId, Owned = @Owned, Loaned = @Loaned
			WHERE Id = @Id
			";
	
		
		await connection.ExecuteAsync(sql, book);
	}

	public async Task Delete(Book book)
	{
		using var connection = _createConnection();
		
		var sql = "DELETE FROM Books WHERE Id = @Id";
		
		await connection.ExecuteAsync(sql, book);
	}
	
	public async Task AddNoteToBook(int bookId, int noteId)
	{
		using var connection = _createConnection();
		var sql = "INSERT INTO BookNotes (BookId, NoteId) VALUES (@bookId, @noteId)";
		await connection.ExecuteAsync(sql, new { bookId, noteId });
	}
	
	public async Task AddBookToLoan(int bookId, int loanId)
	{
		using var connection = _createConnection();
		var sql = "UPDATE Books SET LoanId = @loanId WHERE Id = @bookId";
		await connection.ExecuteAsync(sql, new { bookId, loanId });
	}
	
	public async Task AddSubjectToBook(int bookId, int subjectId)
	{
		using var connection = _createConnection();
		var sql = "INSERT INTO BookSubjects (BookId, SubjectId) VALUES (@bookId, @subjectId)";
		await connection.ExecuteAsync(sql, new { bookId, subjectId });
	}
	
	public async Task AddBookToCollection(int bookId, int collectionId)
	{
		using var connection = _createConnection();
		var sql = "INSERT INTO BookCollections (BookId, CollectionId) VALUES (@bookId, @collectionId)";
		await connection.ExecuteAsync(sql, new { bookId, collectionId });
	}
}