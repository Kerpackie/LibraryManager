using System.Data;
using Dapper;
using LibraryManager.Data.Models;

namespace LibraryManager.Data.Repositories.CollectionRepositories;

public class CollectionRepository : ICollectionRepository
{
	private readonly Func<IDbConnection> _createConnection;

	public CollectionRepository(Func<IDbConnection> createConnection)
	{
		_createConnection = createConnection;
	}

	public async Task<IEnumerable<Collection>> GetAll()
	{
		using var connection = _createConnection();
		
		var sql	= "SELECT * FROM Collections";
		
		return await connection.QueryAsync<Collection>(sql);
	}

	public async Task<Collection> GetById(int id)
	{
		using var connection = _createConnection();
		
		var sql = "SELECT * FROM Collections WHERE Id = @id";
		
		return await connection.QuerySingleOrDefaultAsync<Collection>(sql, new { id });
	}

	public async Task<Collection> GetByName(string name)
	{
		using var connection = _createConnection();
		
		var sql = "SELECT * FROM Collections WHERE Name = @name";
		
		return await connection.QuerySingleOrDefaultAsync<Collection>(sql, new { name });
	}

	public async Task Create(Collection collection)
	{
		using var connection = _createConnection();
		
		var sql = @"
			INSERT INTO Collections (Name)
			VALUES (@Name)
		";
		
		await connection.ExecuteAsync(sql, collection);
	}

	public async Task Update(Collection collection)
	{
		using var connection = _createConnection();
		
		var sql = @"
			UPDATE Collections
			SET Name = @Name
			WHERE Id = @Id
		";
		
		await connection.ExecuteAsync(sql, collection);
	}

	public async Task Delete(int id)
	{
		using var connection = _createConnection();
		
		var sql = "DELETE FROM Collections WHERE Id = @id";
		
		await connection.ExecuteAsync(sql, new { id });
	}
}