using LibraryManager.Core.Models;

namespace LibraryManager.Core.Services.LoanService;

public interface ILoanService
{
	Task<ServiceResponse<Loan>> CreateLoanAsync(Loan newLoan);
	Task<ServiceResponse<Loan>> GetLoanAsync(int id);
	Task<ServiceResponse<Loan>> GetLoanByBookIdAsync(int bookId);
	Task<ServiceResponse<IEnumerable<Loan>>> GetAllLoansAsync();
	Task<ServiceResponse<IEnumerable<Loan>>> GetLoansByBorrowerAsync(string borrower);
	Task<ServiceResponse<Loan>> ReturnLoanAsync(int id);
	Task<ServiceResponse<Loan>> UpdateLoanAsync(Loan updatedLoan);
	Task<ServiceResponse<Loan>> DeleteLoanAsync(int id);
}