using LibraryManager.Core.Models;

namespace LibraryManager.Core.Services.SubjectService;

public interface ISubjectService
{
	Task<ServiceResponse<Subject>> InsertOrIgnoreSubjectAsync(Subject subject);
	Task<ServiceResponse<List<Subject>>> InsertOrIgnoreSubjectsAsync(List<Subject> subjects);
	Task<ServiceResponse<Subject?>> GetSubjectAsync(int id);
	Task<ServiceResponse<Subject?>> GetSubjectByNameAsync(string name);
	Task<ServiceResponse<Subject>> UpdateSubjectAsync(Subject subject);
	Task<ServiceResponse<bool>> DeleteSubjectAsync(int id);
	Task<ServiceResponse<bool>> DeleteSubjectAsync(string name);
}