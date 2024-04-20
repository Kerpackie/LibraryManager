using LibraryManager.Data.Models;

namespace LibraryManager.Data.Services.SubjectService;

public interface ISubjectService
{
    Task<ServiceResponse<List<Subject>>> GetAllAsync();
    Task<ServiceResponse<Subject>> GetByIdAsync(int id);
    Task<ServiceResponse<Subject>> GetByNameAsync(string name);
    Task<ServiceResponse<Subject>> CreateAsync(Subject subject);
    Task<ServiceResponse<Subject>> UpdateAsync(Subject subject);
    Task<ServiceResponse<bool>> DeleteAsync(int id);
    
}