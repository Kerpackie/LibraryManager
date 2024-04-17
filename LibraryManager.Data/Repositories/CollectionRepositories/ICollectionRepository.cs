using LibraryManager.Data.Models;

namespace LibraryManager.Data.Repositories.CollectionRepositories;

public interface ICollectionRepository
{
	Task<IEnumerable<Collection>> GetAll();
	Task<Collection> GetById(int id);
	Task<Collection> GetByName(string name);
	Task Create(Collection collection);
	Task Update(Collection collection);
	Task Delete(int id);
}