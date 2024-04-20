using LibraryManager.Data.Models;

namespace LibraryManager.Data.Repositories.SubjectRepositories;

public interface ISubjectRepository
{
	Task<IEnumerable<Subject>> GetAll();
	Task<Subject> GetById(int id);
	Task<Subject> GetByName(string name);
	Task<int> Create(Subject subject);
	Task<int> Update(Subject subject);
	Task<int> Delete(int id);
}