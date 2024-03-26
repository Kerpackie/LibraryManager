using LibraryManager.Core.Models;

namespace LibraryManager.Core.Services.CollectionService;

public interface ICollectionService
{
	Task<ServiceResponse<Collection>> CreateCollection(Collection newCollection);
	Task<ServiceResponse<Collection>> GetCollection(int id);
	Task<ServiceResponse<Collection>> GetCollection(string name);
	Task<ServiceResponse<IEnumerable<Collection>>> GetAllCollections();
	Task<ServiceResponse<Collection>> UpdateCollection(Collection updatedCollection);
	Task<ServiceResponse<bool>> DeleteCollection(int id);
	Task<ServiceResponse<bool>> DeleteCollection(string name);
	Task<ServiceResponse<Collection>> AddBookToCollection(int collectionId, int bookId);
}