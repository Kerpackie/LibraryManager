using System.Collections;
using LibraryManager.Data.Models;

namespace LibraryManager.Data.Repositories.PublisherRepositories;

public interface IPublisherRepository
{
	Task<IEnumerable<Publisher>> GetAll();
	Task<Publisher> GetById(int id);
	Task<Publisher> GetByName(string name);
	Task Create(Publisher publisher);
	Task Update(Publisher publisher);
	Task Delete(int id);
}