using LibraryManager.Data.Models;

namespace LibraryManager.Data.Repositories.SubjectRepositories;

public interface ISubjectRepository
{
	Task<IEnumerable<Subject>> GetAll();
	Task<Subject> GetById(int id);
	Task<Subject> GetByName(string name);
	Task Create(Subject subject);
	Task Update(Subject subject);
	Task Delete(int id);
}