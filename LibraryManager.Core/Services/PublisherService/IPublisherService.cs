using LibraryManager.Core.Models;

namespace LibraryManager.Core.Services.PublisherService;

public interface IPublisherService
{
	Task<Publisher> CreatePublisherAsync(Publisher publisher);
	Task<Publisher?> GetPublisherAsync(int id);
	Task<Publisher?> GetPublisherByNameAsync(string name);
	Task<Publisher> UpdatePublisherAsync(Publisher publisher);
	Task DeletePublisherAsync(int id);
}