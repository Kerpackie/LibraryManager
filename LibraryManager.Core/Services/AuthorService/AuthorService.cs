using LibraryManager.Core.Data;
using Microsoft.EntityFrameworkCore;
using LibraryManager.Core.Models;
using LibraryManager.Core.Models.OpenLibraryResponseModels;

namespace LibraryManager.Core.Services.AuthorService
{
	public class AuthorService : IAuthorService
	{
		private readonly LibraryContext _context;

		public AuthorService(LibraryContext context)
		{
			_context = context;
		}


		public async Task<ServiceResponse<Author>> InsertOrIgnoreAuthorAsync(Author author)
		{
			var existingAuthor = await _context.Authors.FirstOrDefaultAsync(a => a.Name == author.Name);
			if (existingAuthor == null)
			{
				_context.Authors.Add(author);
				await _context.SaveChangesAsync();
				
				var responseSuccess = new ServiceResponse<Author>
				{
					Data = author,
					Message = "Author added",
					Success = true
				};
				return responseSuccess;
			}
			
			var responseFail = new ServiceResponse<Author>
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
	}
}