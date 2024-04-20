using LibraryManager.Data.Models;

namespace LibraryManager.Data.Repositories.CoverRepositories;

public interface ICoverRepository
{
	Task<IEnumerable<Cover>> GetAll();
	Task<Cover> GetById();
	Task<int> Create(Cover cover);
	Task<int> Update(Cover cover);
	Task<int> Delete(int id);
}