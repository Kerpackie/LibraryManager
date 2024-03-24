using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Core.Services.SubjectService;

public class SubjectService : ISubjectService
{
	private readonly LibraryContext _context;

	public SubjectService(LibraryContext context)
	{
		_context = context;
	}

	public async Task<ServiceResponse<Subject>> InsertOrIgnoreSubjectAsync(Subject subject)
	{
		subject.Trim();
		
		var existingSubject = await _context.Subjects.FirstOrDefaultAsync(s => s.Name == subject.Name);
		
		if (existingSubject == null)
		{
			_context.Subjects.Add(subject);
			await _context.SaveChangesAsync();
			
			var responseSuccess = new ServiceResponse<Subject>
			{
				Data = subject,
				Message = "Subject added",
				Success = true
			};
			
			return responseSuccess;
		}
		
		var responseFail = new ServiceResponse<Subject>
		{
			Data = existingSubject,
			Message = "Subject already exists",
			Success = false
		};

		return responseFail;
	}

	public async Task<ServiceResponse<List<Subject>>> InsertOrIgnoreSubjectsAsync(List<Subject> subjects)
	{
		subjects.ForEach(s => s.Trim());
		
		var existingSubjects = new List<Subject>();

		foreach (var subject in subjects)
		{
			var existingSubject = await _context.Subjects.FirstOrDefaultAsync(s => s.Name == subject.Name);

			if (existingSubject == null)
			{
				_context.Subjects.Add(subject);
				existingSubjects.Add(subject);
				await _context.SaveChangesAsync();
			}
			else
			{
				existingSubjects.Add(existingSubject);
			}
		}
		
		return new ServiceResponse<List<Subject>>
		{
			Data = existingSubjects,
			Message = "",
			Success = true
		};
	}

	public async Task<ServiceResponse<Subject?>> GetSubjectAsync(int id)
	{
		var subject = await _context.Subjects.FirstOrDefaultAsync(s => s.Id == id);
		
		if (subject == null)
		{
			var responseFail = new ServiceResponse<Subject?>
			{
				Data = null,
				Message = "Subject not found",
				Success = false
			};
			
			return responseFail;
		}
		
		var responseSuccess = new ServiceResponse<Subject?>
		{
			Data = subject,
			Message = "Subject found",
			Success = true
		};
		
		return responseSuccess;
	}

	public async Task<ServiceResponse<Subject?>> GetSubjectByNameAsync(string name)
	{
		var subject = await _context.Subjects.FirstOrDefaultAsync(s => s.Name == name);
		
		if (subject == null)
		{
			var responseFail = new ServiceResponse<Subject?>
			{
				Data = null,
				Message = "Subject not found",
				Success = false
			};
			
			return responseFail;
		}
		
		var responseSuccess = new ServiceResponse<Subject?>
		{
			Data = subject,
			Message = "Subject found",
			Success = true
		};
		
		return responseSuccess;
	}

	public async Task<ServiceResponse<Subject>> UpdateSubjectAsync(Subject subject)
	{
		var existingSubject = await _context.Subjects.FirstOrDefaultAsync(s => s.Id == subject.Id);
		
		if (existingSubject == null)
		{
			var responseFail = new ServiceResponse<Subject>
			{
				Data = null,
				Message = "Subject not found",
				Success = false
			};
			
			return responseFail;
		}
		
		existingSubject.Name = subject.Name;
		await _context.SaveChangesAsync();
		
		var responseSuccess = new ServiceResponse<Subject>
		{
			Data = existingSubject,
			Message = "Subject updated",
			Success = true
		};
		
		return responseSuccess;
	}

	public async Task<ServiceResponse<bool>> DeleteSubjectAsync(int id)
	{
		var subject = await _context.Subjects.FirstOrDefaultAsync(s => s.Id == id);
		
		if (subject == null)
		{
			var responseFail = new ServiceResponse<bool>
			{
				Data = false,
				Message = "Subject not found",
				Success = false
			};
			
			return responseFail;
		}
		
		_context.Subjects.Remove(subject);
		await _context.SaveChangesAsync();
		
		var responseSuccess = new ServiceResponse<bool>
		{
			Data = true,
			Message = "Subject deleted",
			Success = true
		};
		
		return responseSuccess;
	}

	public async Task<ServiceResponse<bool>> DeleteSubjectAsync(string name)
	{
		var subject = await _context.Subjects.FirstOrDefaultAsync(s => s.Name == name);
		
		if (subject == null)
		{
			var responseFail = new ServiceResponse<bool>
			{
				Data = false,
				Message = "Subject not found",
				Success = false
			};
			
			return responseFail;
		}
		
		_context.Subjects.Remove(subject);
		await _context.SaveChangesAsync();
		
		var responseSuccess = new ServiceResponse<bool>
		{
			Data = true,
			Message = "Subject deleted",
			Success = true
		};
		
		return responseSuccess;
	}
}