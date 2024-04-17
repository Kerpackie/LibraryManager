using System.Data;
using Dapper;
using LibraryManager.Data.Models;

namespace LibraryManager.Data.Repositories.AuthorRepositories;

public class AuthorRepository : IAuthorRepository
{
	private readonly Func<IDbConnection> _createConnection;

	public AuthorRepository(Func<IDbConnection> createConnection)
	{
		_createConnection = createConnection;
	}

	public async Task<IEnumerable<Author>> GetAll()
	{
		using var connection = _createConnection();

		var sql = "SELECT * FROM Authors";
		
		return await connection.QueryAsync<Author>(sql);
	}

	public async Task<Author> GetById(int id)
	{
		using var connection = _createConnection();

		var sql = "SELECT * FROM Authors WHERE Id = @id";
		
		return await connection.QuerySingleOrDefaultAsync<Author>(sql, new { id });
	}

	public async Task<Author> GetByName(string name)
	{
		using var connection = _createConnection();

		var sql = "SELECT * FROM Authors WHERE Name = @name";
		
		return await connection.QuerySingleOrDefaultAsync<Author>(sql, new { name });
	}

	public async Task<int> Create(Author author)
	{
		using var connection = _createConnection();
		var sql = @"
        INSERT INTO Authors (Name)
        VALUES (@Name)
    ";
		var affectedRows = await connection.ExecuteAsync(sql, author);
		return affectedRows;
	}

	public async Task<int> Update(Author author)
	{
		using var connection = _createConnection();

		var sql = @"
			UPDATE Authors
			SET Name = @Name
			WHERE Id = @Id
		";
		
		var affectedRows = await connection.ExecuteAsync(sql, author);
		return affectedRows;
	}

	public async Task<int> Delete(int id)
	{
		using var connection = _createConnection();

		var sql = "DELETE FROM Authors WHERE Id = @id";
		
		var affectedRows = await connection.ExecuteAsync(sql, new { id });
		return affectedRows;
	}
	
	public async Task<IEnumerable<Author>> GetAuthorsByBookId(int bookId)
	{
		using var connection = _createConnection();
		
		var sql = @"
        SELECT a.* 
        FROM Authors a
        INNER JOIN BookAuthors ba ON a.Id = ba.AuthorId
        WHERE ba.BookId = @bookId
    ";
		return await connection.QueryAsync<Author>(sql, new { bookId });
	}

	public async Task<int> AddAuthorToBook(int bookId, int authorId)
	{
		using var connection = _createConnection();
		
		var sql = "INSERT INTO BookAuthors (BookId, AuthorId) VALUES (@bookId, @authorId)";
		
		var affectedRows = await connection.ExecuteAsync(sql, new { bookId, authorId });
		return affectedRows;
	}
}