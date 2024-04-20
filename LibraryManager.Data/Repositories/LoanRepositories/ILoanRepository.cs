using LibraryManager.Data.Models;

namespace LibraryManager.Data.Repositories.LoanRepositories;

public interface ILoanRepository
{
	Task<IEnumerable<Loan>> GetAll();
	Task<IEnumerable<Loan>> GetLoansForBook(int bookId);
	Task<Loan> GetById(int id);
	Task<int> Create(Loan loan);
	Task<int> Update(Loan loan);
	Task<int> Delete(int id);
}