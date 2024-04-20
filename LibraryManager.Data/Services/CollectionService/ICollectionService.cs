using LibraryManager.Data.Models;

namespace LibraryManager.Data.Services.CollectionService;

public interface ICollectionService
{
    Task<ServiceResponse<IEnumerable<Collection>>> GetAllAsync();
    Task<ServiceResponse<Collection>> GetByIdAsync(int id);
    Task<ServiceResponse<Collection>> GetByNameAsync(string name);
    Task<ServiceResponse<Collection>> CreateAsync(Collection collection);
    Task<ServiceResponse<Collection>> UpdateAsync(Collection collection);
    Task<ServiceResponse<bool>> DeleteAsync(int id);
    Task<ServiceResponse<bool>> DeleteAsync(string name);
    Task<ServiceResponse<bool>> DeleteAsync(Collection collection);

}