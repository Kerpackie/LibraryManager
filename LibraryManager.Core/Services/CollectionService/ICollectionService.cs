using LibraryManager.Core.Models;

namespace LibraryManager.Core.Services.CollectionService;

public interface ICollectionService
{
	Task<ServiceResponse<Collection>> CreateCollectionAsync(Collection newCollection);
	Task<ServiceResponse<Collection>> GetCollectionAsync(int id);
	Task<ServiceResponse<Collection>> GetCollectionByNameAsync(string name);
	Task<ServiceResponse<List<Collection>>> GetAllCollectionsAsync();
	Task<ServiceResponse<Collection>> UpdateCollectionAsync(Collection updatedCollection);
	Task<ServiceResponse<bool>> DeleteCollectionAsync(int id);
	Task<ServiceResponse<bool>> DeleteCollectionAsync(string name);
	Task<ServiceResponse<Collection>> AddBookToCollectionAsync(int collectionId, int bookId);
	Task<ServiceResponse<Collection>> RemoveBookFromCollectionAsync(int collectionId, int bookId);
}