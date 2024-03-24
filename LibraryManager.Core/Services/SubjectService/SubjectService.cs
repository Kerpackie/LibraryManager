using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Core.Services.SubjectService
{
	public class SubjectService : ISubjectService
	{
		private readonly LibraryContext _context;

		public SubjectService(LibraryContext context)
		{
			_context = context;
		}

		public async Task<Subject> CreateSubjectAsync(Subject subject)
		{
			
			try
			{
				_context.Subjects.Add(subject);
				await _context.SaveChangesAsync();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return subject;
		}

		public async Task<Subject?> GetSubjectAsync(int id)
		{
			return await _context.Subjects.FindAsync(id);
		}

		public async Task<Subject?> GetSubjectByNameAsync(string name)
		{
			return await _context.Subjects.FirstOrDefaultAsync(s => s.Name == name);
		}

		public async Task<Subject> UpdateSubjectAsync(Subject subject)
		{
			_context.Entry(subject).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return subject;
		}

		public async Task DeleteSubjectAsync(int id)
		{
			var subject = await _context.Subjects.FindAsync(id);
			if (subject != null)
			{
				_context.Subjects.Remove(subject);
				await _context.SaveChangesAsync();
			}
		}
	}
}