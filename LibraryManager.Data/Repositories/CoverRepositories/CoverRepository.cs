using System.Data;
using Dapper;
using LibraryManager.Data.Models;

namespace LibraryManager.Data.Repositories.CoverRepositories;

public class CoverRepository : ICoverRepository
{
	private readonly Func<IDbConnection> _createConnection;

	public CoverRepository(Func<IDbConnection> createConnection)
	{
		_createConnection = createConnection;
	}

	public async Task<IEnumerable<Cover>> GetAll()
	{
		using var connection = _createConnection();
		
		var sql = "SELECT * FROM Covers";

		return await connection.QueryAsync<Cover>(sql);
	}

	public async Task<Cover> GetById()
	{
		using var connection = _createConnection();
		
		var sql = "SELECT * FROM Covers WHERE Id = @id";
		
		return await connection.QuerySingleOrDefaultAsync<Cover>(sql);
	}

	public async Task Create(Cover cover)
	{
		using var connection = _createConnection();
		
		var sql = @"
			INSERT INTO Covers (Name)
			VALUES (@Name)
		";
		
		await connection.ExecuteAsync(sql, cover);
	}

	public async Task Update(Cover cover)
	{
		using var connection = _createConnection();
		
		var sql = @"
			UPDATE Covers
			SET Name = @Name
			WHERE Id = @Id
		";
		
		await connection.ExecuteAsync(sql, cover);
	}

	public async Task Delete(int id)
	{
		using var connection = _createConnection();
		
		var sql = "DELETE FROM Covers WHERE Id = @id";
		
		await connection.ExecuteAsync(sql, new { id });
	}
}
	