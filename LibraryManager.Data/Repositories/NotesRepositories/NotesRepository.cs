using System.Data;
using Dapper;
using LibraryManager.Data.Models;

namespace LibraryManager.Data.Repositories.NotesRepositories;

public class NotesRepository : INotesRepository
{
	private readonly Func<IDbConnection> _createConnection;

	public NotesRepository(Func<IDbConnection> createConnection)
	{
		_createConnection = createConnection;
	}

	public async Task<IEnumerable<Note>> GetAll()
	{
		using var connection = _createConnection();
		
		var sql = "SELECT * FROM Notes";
		
		return await connection.QueryAsync<Note>(sql);
	}

	public async Task<IEnumerable<Note>> GetAllNotesForBook(int bookId)
	{
		using var connection = _createConnection();
		
		var sql = "SELECT * FROM Notes WHERE BookId = @bookId";
		
		return await connection.QueryAsync<Note>(sql, new { bookId });
	}

	public async Task<Note> GetById(int id)
	{
		using var connection = _createConnection();
		
		var sql = "SELECT * FROM Notes WHERE Id = @id";
		
		return await connection.QuerySingleOrDefaultAsync<Note>(sql, new { id });
	}

	public async Task<int> Create(Note note)
	{
		using var connection = _createConnection();
		
		var sql = @"
			INSERT INTO Notes (BookId, Text)
			VALUES (@BookId, @Text)
		";
		
		var affectedRows = await connection.ExecuteAsync(sql, note);
		return affectedRows;
	}

	public async Task<int> Update(Note note)
	{
		using var connection = _createConnection();
		
		var sql = @"
			UPDATE Notes
			SET Text = @Text
			WHERE Id = @Id
		";
		
		var affectedRows = await connection.ExecuteAsync(sql, note);
		return affectedRows;
	}

	public async Task<int> Delete(int id)
	{
		using var connection = _createConnection();
		
		var sql = "DELETE FROM Notes WHERE Id = @id";
		
		var affectedRows = await connection.ExecuteAsync(sql, new { id });
		return affectedRows;
	}

	public async Task<int> DeleteAllNotesForBook(int bookId)
	{
		using var connection = _createConnection();
		
		var sql = "DELETE FROM Notes WHERE BookId = @bookId";
		
		var affectedRows = await connection.ExecuteAsync(sql, new { bookId });
		return affectedRows;
	}
}