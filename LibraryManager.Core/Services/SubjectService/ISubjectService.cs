using LibraryManager.Core.Models;

namespace LibraryManager.Core.Services.SubjectService;

public interface ISubjectService
{
	Task<Subject> CreateSubjectAsync(Subject subject);
	Task<Subject?> GetSubjectAsync(int id);
	Task<Subject> UpdateSubjectAsync(Subject subject);
	Task DeleteSubjectAsync(int id);
}