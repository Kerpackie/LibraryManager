using LibraryManager.Core.Models;

namespace LibraryManager.Core.Services.PublisherService;

public interface IPublisherService
{
	Task<ServiceResponse<Publisher>> InsertOrIgnorePublisherAsync(Publisher publisher);
	Task<ServiceResponse<Publisher?>> GetPublisherAsync(int id);
	Task<ServiceResponse<Publisher?>> GetPublisherByNameAsync(string name);
	Task<ServiceResponse<Publisher>> UpdatePublisherAsync(Publisher publisher);
	Task<ServiceResponse<bool>> DeletePublisherAsync(int id);
	Task<ServiceResponse<bool>> DeletePublisherAsync(string name);
}