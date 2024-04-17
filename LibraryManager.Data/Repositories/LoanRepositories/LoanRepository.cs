using System.Data;
using Dapper;
using LibraryManager.Data.Models;

namespace LibraryManager.Data.Repositories.LoanRepositories;

public class LoanRepository : ILoanRepository
{
	private readonly Func<IDbConnection> _createConnection;

	public LoanRepository(Func<IDbConnection> createConnection)
	{
		_createConnection = createConnection;
	}

	public async Task<IEnumerable<Loan>> GetAll()
	{
		using var connection = _createConnection();
		
		var sql = "SELECT * FROM Loans";
		
		return await connection.QueryAsync<Loan>(sql);
	}

	public async Task<IEnumerable<Loan>> GetLoansForBook(int bookId)
	{
		using var connection = _createConnection();
		
		var sql = "SELECT * FROM Loans WHERE BookId = @bookId";
		
		return await connection.QueryAsync<Loan>(sql, new { bookId });
	}

	public async Task<Loan> GetById(int id)
	{
		using var connection = _createConnection();
		
		var sql = "SELECT * FROM Loans WHERE Id = @id";
		
		return await connection.QuerySingleOrDefaultAsync<Loan>(sql, new { id });
	}

	public async Task Create(Loan loan)
	{
		using var connection = _createConnection();
		
		var sql = @"
			INSERT INTO Loans (BookId, MemberId, BorrowedDate, DueDate, ReturnDate)
			VALUES (@BookId, @MemberId, @BorrowedDate, @DueDate, @ReturnDate)
		";
		
		await connection.ExecuteAsync(sql, loan);
	}

	public async Task Update(Loan loan)
	{
		using var connection = _createConnection();
		
		var sql = @"
			UPDATE Loans
			SET BookId = @BookId, MemberId = @MemberId, BorrowedDate = @BorrowedDate, DueDate = @DueDate, ReturnDate = @ReturnDate
			WHERE Id = @Id
		";
		
		await connection.ExecuteAsync(sql, loan);
	}

	public async Task Delete(int id)
	{
		using var connection = _createConnection();
		
		var sql = "DELETE FROM Loans WHERE Id = @id";
		
		await connection.ExecuteAsync(sql, new { id });
	}
}