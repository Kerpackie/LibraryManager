using System.Data;
using Dapper;
using LibraryManager.Data.Models;

namespace LibraryManager.Data.Repositories.PublisherRepositories;

public class PublisherRepository : IPublisherRepository
{
	private readonly Func<IDbConnection> _createConnection;

	public PublisherRepository(Func<IDbConnection> createConnection)
	{
		_createConnection = createConnection;
	}

	public async Task<IEnumerable<Publisher>> GetAll()
	{
		using var connection = _createConnection();
		
		var sql = "SELECT * FROM Publishers";
		
		return await connection.QueryAsync<Publisher>(sql);
	}

	public async Task<Publisher> GetById(int id)
	{
		using var connection = _createConnection();
		
		var sql = "SELECT * FROM Publishers WHERE Id = @id";
		
		return await connection.QuerySingleOrDefaultAsync<Publisher>(sql, new { id });
	}

	public async Task<Publisher> GetByName(string name)
	{
		using var connection = _createConnection();
		
		var sql = "SELECT * FROM Publishers WHERE Name = @name";
		
		return await connection.QuerySingleOrDefaultAsync<Publisher>(sql, new { name });
	}

	public async Task<int> Create(Publisher publisher)
	{
		using var connection = _createConnection();
		
		var sql = @"
			INSERT INTO Publishers (Name)
			VALUES (@Name)
		";
		
		var affectedRows = await connection.ExecuteAsync(sql, publisher);
		return affectedRows;
	}

	public async Task<int> Update(Publisher publisher)
	{
		using var connection = _createConnection();
		
		var sql = @"
			UPDATE Publishers
			SET Name = @Name
		";
		
		var affectedRows = await connection.ExecuteAsync(sql, publisher);
		return affectedRows;
	}

	public async Task<int> Delete(int id)
	{
		using var connection = _createConnection();
		
		var sql = "DELETE FROM Publishers WHERE Id = @id";
		
		var affectedRows = await connection.ExecuteAsync(sql, new { id });
		return affectedRows;
	}
}