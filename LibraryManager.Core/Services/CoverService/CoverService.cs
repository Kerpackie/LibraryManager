using LibraryManager.Core.Data;
using Microsoft.EntityFrameworkCore;
using LibraryManager.Core.Models;

namespace LibraryManager.Core.Services.CoverService
{
	public class CoverService : ICoverService
	{
		private readonly LibraryContext _context;

		public CoverService(LibraryContext context)
		{
			_context = context;
		}

		public async Task<Cover> CreateCoverAsync(Cover cover)
		{
			_context.Covers.Add(cover);
			await _context.SaveChangesAsync();
			return cover;
		}

		public async Task<Cover?> GetCoverAsync(int id)
		{
			return await _context.Covers.FindAsync(id);
		}

		public async Task<Cover> UpdateCoverAsync(Cover cover)
		{
			_context.Entry(cover).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return cover;
		}

		public async Task DeleteCoverAsync(int id)
		{
			var cover = await _context.Covers.FindAsync(id);
			if (cover != null)
			{
				_context.Covers.Remove(cover);
				await _context.SaveChangesAsync();
			}
		}
	}
}