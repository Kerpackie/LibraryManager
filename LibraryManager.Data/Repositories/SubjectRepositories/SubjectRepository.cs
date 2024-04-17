using System.Data;
using Dapper;
using LibraryManager.Data.Models;

namespace LibraryManager.Data.Repositories.SubjectRepositories;

public class SubjectRepository : ISubjectRepository
{
	private readonly Func<IDbConnection> _createConnection;

	public SubjectRepository(Func<IDbConnection> createConnection)
	{
		_createConnection = createConnection;
	}

	public async Task<IEnumerable<Subject>> GetAll()
	{
		using var connection = _createConnection();
		
		var sql = "SELECT * FROM Subjects";
		
		return await connection.QueryAsync<Subject>(sql);
	}

	public async Task<Subject> GetById(int id)
	{
		using var connection = _createConnection();
		
		var sql = "SELECT * FROM Subjects WHERE Id = @id";
		
		return await connection.QuerySingleOrDefaultAsync<Subject>(sql, new { id });
	}

	public async Task<Subject> GetByName(string name)
	{
		using var connection = _createConnection();
		
		var sql = "SELECT * FROM Subjects WHERE Name = @name";
		
		return await connection.QuerySingleOrDefaultAsync<Subject>(sql, new { name });
	}

	public async Task Create(Subject subject)
	{
		using var connection = _createConnection();
		
		var sql = @"
			INSERT INTO Subjects (Name)
			VALUES (@Name)
		";
		
		await connection.ExecuteAsync(sql, subject);
	}

	public async Task Update(Subject subject)
	{
		using var connection = _createConnection();
		
		var sql = @"
			UPDATE Subjects
			SET Name = @Name
			WHERE Id = @Id
		";
		
		await connection.ExecuteAsync(sql, subject);
	}

	public async Task Delete(int id)
	{
		using var connection = _createConnection();
		
		var sql = "DELETE FROM Subjects WHERE Id = @id";
		
		await connection.ExecuteAsync(sql, new { id });
	}
}