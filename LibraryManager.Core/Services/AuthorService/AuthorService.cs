using LibraryManager.Core.Data;
using Microsoft.EntityFrameworkCore;
using LibraryManager.Core.Models;

namespace LibraryManager.Core.Services.AuthorService
{
	public class AuthorService : IAuthorService
	{
		private readonly LibraryContext _context;

		public AuthorService(LibraryContext context)
		{
			_context = context;
		}

		public async Task<Author> CreateAuthorAsync(Author author)
		{
			_context.Authors.Add(author);
			await _context.SaveChangesAsync();
			return author;
		}

		public async Task<Author?> GetAuthorAsync(int id)
		{
			return await _context.Authors.FindAsync(id);
		}

		public async Task<Author?> GetAuthorByNameAsync(string name)
		{
			return await _context.Authors.FirstOrDefaultAsync(a => a.Name == name);
		}

		public async Task<Author> UpdateAuthorAsync(Author author)
		{
			_context.Entry(author).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return author;
		}

		public async Task DeleteAuthorAsync(int id)
		{
			var author = await _context.Authors.FindAsync(id);
			if (author != null)
			{
				_context.Authors.Remove(author);
				await _context.SaveChangesAsync();
			}
		}
	}
}