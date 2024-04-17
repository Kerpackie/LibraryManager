using LibraryManager.Data.Models;

namespace LibraryManager.Data.Repositories.CoverRepositories;

public interface ICoverRepository
{
	Task<IEnumerable<Cover>> GetAll();
	Task<Cover> GetById();
	Task Create(Cover cover);
	Task Update(Cover cover);
	Task Delete(int id);
}