using LibraryManager.Core.Data;
using Microsoft.EntityFrameworkCore;
using LibraryManager.Core.Models;
using LibraryManager.Core.Models.OpenLibraryResponseModels;
using LibraryManager.Core.Validators;
using LibraryManager.Core.Validators.AuthorValidator;

namespace LibraryManager.Core.Services.AuthorService
{
	public class AuthorService : IAuthorService
	{
		private readonly LibraryContext _context;
		private readonly IAuthorValidator _authorValidator;

		public AuthorService(LibraryContext context, IAuthorValidator authorValidator)
		{
			_context = context;
			_authorValidator = authorValidator;
		}


		public async Task<ServiceResponse<Author>> InsertOrIgnoreAuthorAsync(Author author)
		{
			var validationResult = _authorValidator.Validate(author);
			
			if (!validationResult.IsValid)
			{
				return new ServiceResponse<Author>
				{
					Data = null,
					Message = string.Join(", ", validationResult.Errors),
					Success = false
				};
			}
			
			author.Trim();
			
			var existingAuthor = await _context.Authors.FirstOrDefaultAsync(a => a.Name == author.Name);
			if (existingAuthor == null)
			{
				_context.Authors.Add(author);
				await _context.SaveChangesAsync();
				
				var responseSuccess = new ServiceResponse<Author?>
				{
					Data = author,
					Message = "Author added",
					Success = true
				};
				return responseSuccess;
			}
			
			var responseFail = new ServiceResponse<Author?>
			{
				Data = existingAuthor,
				Message = "Author already exists",
				Success = false
			};
			return responseFail;
		}

		public async Task<ServiceResponse<Author>> GetAuthorAsync(long id)
		{
			var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
			if (author == null)
			{
				var responseFail = new ServiceResponse<Author>
				{
					Data = null,
					Message = "Author not found",
					Success = false
				};
				return responseFail;
			}
			
			var responseSuccess = new ServiceResponse<Author>
			{
				Data = author,
				Message = "Author found",
				Success = true
			};
			return responseSuccess;
		}

		public async Task<ServiceResponse<Author>> GetAuthorByNameAsync(string name)
		{
			var author = await _context.Authors.FirstOrDefaultAsync(a => a.Name == name);
			if (author == null)
			{
				var responseFail = new ServiceResponse<Author>
				{
					Data = null,
					Message = "Author not found",
					Success = false
				};
				return responseFail;
			}
			
			var responseSuccess = new ServiceResponse<Author>
			{
				Data = author,
				Message = "Author found",
				Success = true
			};
			return responseSuccess;
		}

		public async Task<ServiceResponse<Author>> UpdateAuthorAsync(Author author)
		{
			var validationResult = ValidateAuthor(author, out var valid);

			if (!valid)
			{
				return validationResult;
			}
			
			var existingAuthor = await _context.Authors.FirstOrDefaultAsync(a => a.Id == author.Id);
			if (existingAuthor == null)
			{
				var responseFail = new ServiceResponse<Author>
				{
					Data = null,
					Message = "Author not found",
					Success = false
				};
				return responseFail;
			}
			
			existingAuthor.Name = author.Name;
			_context.Authors.Update(existingAuthor);
			await _context.SaveChangesAsync();
			
			var responseSuccess = new ServiceResponse<Author>
			{
				Data = existingAuthor,
				Message = "Author updated",
				Success = true
			};
			return responseSuccess;
		}

		public async Task<ServiceResponse<bool>> DeleteAuthorAsync(long id)
		{
			var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
			if (author == null)
			{
				var responseFail = new ServiceResponse<bool>
				{
					Data = false,
					Message = "Author not found",
					Success = false
				};
				return responseFail;
			}
			
			_context.Authors.Remove(author);
			await _context.SaveChangesAsync();
			
			var responseSuccess = new ServiceResponse<bool>
			{
				Data = true,
				Message = "Author deleted",
				Success = true
			};
			return responseSuccess;
		}

		public async Task<ServiceResponse<bool>> DeleteAuthorAsync(string name)
		{
			var author = await _context.Authors.FirstOrDefaultAsync(a => a.Name == name);
			if (author == null)
			{
				var responseFail = new ServiceResponse<bool>
				{
					Data = false,
					Message = "Author not found",
					Success = false
				};
				return responseFail;
			}
			
			_context.Authors.Remove(author);
			await _context.SaveChangesAsync();
			
			var responseSuccess = new ServiceResponse<bool>
			{
				Data = true,
				Message = "Author deleted",
				Success = true
			};
			return responseSuccess;
		}
		
		private ServiceResponse<Author> ValidateAuthor(Author author, out bool valid)
		{
			if (author == null)
			{
				valid = false;
				
				return new ServiceResponse<Author>
				{
					Data = null,
					Message = "Author is null",
					Success = false
				};
			}
			
			// Check if author name is null or empty
			if (author.Name == null || author.Name.Trim() == "")
			{
				valid = false;
				
				return new ServiceResponse<Author>
				{
					Data = null,
					Message = "Author name is null or empty",
					Success = false
				};
			}
			
			author.Trim();
			valid = true;
			return new ServiceResponse<Author>
			{
				Data = author,
				Message = "Author is valid",
				Success = true
			};
		}
	}
}