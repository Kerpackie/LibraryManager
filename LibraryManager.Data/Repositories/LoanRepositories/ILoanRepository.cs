using LibraryManager.Data.Models;

namespace LibraryManager.Data.Repositories.LoanRepositories;

public interface ILoanRepository
{
	Task<IEnumerable<Loan>> GetAll();
	Task<IEnumerable<Loan>> GetLoansForBook(int bookId);
	Task<Loan> GetById(int id);
	Task Create(Loan loan);
	Task Update(Loan loan);
	Task Delete(int id);
}