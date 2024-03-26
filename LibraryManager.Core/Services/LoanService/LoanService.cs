using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Core.Services.LoanService;

public class LoanService : ILoanService
{
	private readonly LibraryContext _context;

	public LoanService(LibraryContext context)
	{
		_context = context;
	}

	public async Task<ServiceResponse<Loan>> CreateLoanAsync(Loan newLoan)
	{
		var response = new ServiceResponse<Loan>();

		await using var transaction = await _context.Database.BeginTransactionAsync();

		try
		{
			foreach (var bookInLoan in newLoan.Books)
			{
				var book = await _context.Books.FindAsync(bookInLoan.Id);
				if (book == null)
				{
					response.Success = false;
					response.Message = "Book not found";
					return response;
				}

				if (book.Loaned)
				{
					response.Success = false;
					response.Message = "Book is already on loan";
					return response;
				}

				book.Loaned = true;
				_context.Books.Update(book);
			}

			await _context.Loans.AddAsync(newLoan);
			await _context.SaveChangesAsync();

			await transaction.CommitAsync();

			response.Data = newLoan;
			response.Message = "Loan created successfully";
			response.Success = true;
		}
		catch (Exception ex)
		{
			await transaction.RollbackAsync();

			response.Success = false;
			response.Message = ex.Message;
		}

		return response;
	}

	public async Task<ServiceResponse<Loan>> GetLoanAsync(int id)
	{
		var response = new ServiceResponse<Loan>();

		try
		{
			var loan = await _context.Loans.FindAsync(id);
			if (loan == null || loan.Deleted)
			{
				response.Success = false;
				response.Message = "Loan not found";
				return response;
			}

			response.Data = loan;
			response.Success = true;
		}
		catch (Exception ex)
		{
			response.Success = false;
			response.Message = ex.Message;
		}

		return response;
	}

	public async Task<ServiceResponse<Loan>> GetLoanByBookIdAsync(int bookId)
	{
		var response = new ServiceResponse<Loan>();

		try
		{
			var loan = await _context.Loans
				.Where(l => l.Deleted == false)
				.Include(l => l.Books)
				.FirstOrDefaultAsync(l => l.Books
					.Any(b => b.Id == bookId));
			if (loan == null)
			{
				response.Success = false;
				response.Message = "Loan not found";
				return response;
			}

			response.Data = loan;
			response.Success = true;
		}
		catch (Exception ex)
		{
			response.Success = false;
			response.Message = ex.Message;
		}

		return response;
	}

	public async Task<ServiceResponse<IEnumerable<Loan>>> GetAllLoansAsync()
	{
		var response = new ServiceResponse<IEnumerable<Loan>>();

		try
		{
			var loans = await _context.Loans
				.Where(l => l.Deleted == false)
				.ToListAsync();

			if (loans.Count == 0)
			{
				response.Success = false;
				response.Message = "No loans found";
			}
			
			response.Data = loans;
			response.Success = true;
		}
		catch (Exception ex)
		{
			response.Success = false;
			response.Message = ex.Message;
		}

		return response;
	}

	public async Task<ServiceResponse<IEnumerable<Loan>>> GetLoansByBorrowerAsync(string borrower)
	{
		var response = new ServiceResponse<IEnumerable<Loan>>();

		try
		{
			var loans = await _context.Loans
				.Where(l => l.Deleted == false && l.Borrower == borrower)
				.ToListAsync();

			if (loans.Count == 0)
			{
				response.Success = false;
				response.Message = "No loans found";
			}
			
			response.Data = loans;
			response.Success = true;
		}
		catch (Exception ex)
		{
			response.Success = false;
			response.Message = ex.Message;
		}

		return response;
	}

	public async Task<ServiceResponse<Loan>> ReturnLoanAsync(int id)
	{
		var response = new ServiceResponse<Loan>();

		await using var transaction = await _context.Database.BeginTransactionAsync();

		try
		{
			var loan = await _context.Loans
				.Where(l => l.Deleted == false)
				.Include(l => l.Books)
				.FirstOrDefaultAsync(l => l.Id == id);
			if (loan == null)
			{
				response.Success = false;
				response.Message = "Loan not found";
				return response;
			}

			if (loan.Books.Any(book => !book.Loaned))
			{
				response.Success = false;
				response.Message = "Book is not on loan";
				return response;
			}

			if (loan.IsReturned)
			{
				response.Success = false;
				response.Message = "Loan is already returned";
				return response;
			}

			foreach (var book in loan.Books)
			{
				book.Loaned = false;
				_context.Books.Update(book);
			}

			loan.IsReturned = true;
			loan.ReturnDate = DateTime.Now;
			_context.Loans.Update(loan);

			await _context.SaveChangesAsync();
			await transaction.CommitAsync();

			response.Data = loan;
			response.Message = "Loan returned successfully";
			response.Success = true;
		}
		catch (Exception ex)
		{
			await transaction.RollbackAsync();

			response.Success = false;
			response.Message = ex.Message;
		}

		return response;
	}

	public async Task<ServiceResponse<Loan>> UpdateLoanAsync(Loan updatedLoan)
	{
		var response = new ServiceResponse<Loan>();

		await using var transaction = await _context.Database.BeginTransactionAsync();

		try
		{
			var loan = await _context.Loans
				.Where(l => l.Deleted == false)
				.Include(l => l.Books)
				.FirstOrDefaultAsync(l => l.Id == updatedLoan.Id);
			
			if (loan == null)
			{
				response.Success = false;
				response.Message = "Loan not found";
				return response;
			}

			foreach (var book in loan.Books)
			{
				book.Loaned = false;
				_context.Books.Update(book);
			}

			foreach (var bookInLoan in updatedLoan.Books)
			{
				var book = await _context.Books.FindAsync(bookInLoan.Id);
				if (book == null)
				{
					response.Success = false;
					response.Message = "Book not found";
					return response;
				}

				if (book.Loaned)
				{
					response.Success = false;
					response.Message = "Book is already on loan";
					return response;
				}

				book.Loaned = true;
				_context.Books.Update(book);
			}

			loan.Borrower = updatedLoan.Borrower;
			loan.LoanDate = updatedLoan.LoanDate;
			loan.ReturnDate = updatedLoan.ReturnDate;
			loan.IsReturned = updatedLoan.IsReturned;
			loan.Books = updatedLoan.Books;

			_context.Loans.Update(loan);

			await _context.SaveChangesAsync();
			await transaction.CommitAsync();

			response.Data = loan;
			response.Message = "Loan updated successfully";
			response.Success = true;
		}
		catch (Exception ex)
		{
			await transaction.RollbackAsync();

			response.Success = false;
			response.Message = ex.Message;
		}

		return response;
	}

	public async Task<ServiceResponse<Loan>> DeleteLoanAsync(int id)
	{
		var response = new ServiceResponse<Loan>();

		await using var transaction = await _context.Database.BeginTransactionAsync();

		try
		{
			var loan = await _context.Loans
				.Where(l => l.Deleted == false)
				.Include(l => l.Books)
				.FirstOrDefaultAsync(l => l.Id == id);
			if (loan == null)
			{
				response.Success = false;
				response.Message = "Loan not found";
				return response;
			}

			foreach (var book in loan.Books)
			{
				book.Loaned = false;
				_context.Books.Update(book);
			}

			loan.Deleted = true;
			_context.Loans.Update(loan);
			await _context.SaveChangesAsync();
			await transaction.CommitAsync();

			response.Data = loan;
			response.Message = "Loan deleted successfully";
			response.Success = true;
		}
		catch (Exception ex)
		{
			await transaction.RollbackAsync();

			response.Success = false;
			response.Message = ex.Message;
		}

		return response;
	}
}