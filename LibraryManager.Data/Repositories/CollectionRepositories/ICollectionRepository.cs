using LibraryManager.Data.Models;

namespace LibraryManager.Data.Repositories.CollectionRepositories;

public interface ICollectionRepository
{
	Task<IEnumerable<Collection>> GetAll();
	Task<Collection> GetById(int id);
	Task<Collection> GetByName(string name);
	Task<int> Create(Collection collection);
	Task<int> Update(Collection collection);
	Task<int> Delete(int id);
	Task<int> Delete(string name);
}