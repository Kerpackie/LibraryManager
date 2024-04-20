using LibraryManager.Data.Models;
using LibraryManager.Data.Repositories.CollectionRepositories;

namespace LibraryManager.Data.Services.CollectionService;

public class CollectionService : ICollectionService
{
    private readonly ICollectionRepository _collectionRepository;

    public CollectionService(ICollectionRepository collectionRepository)
    {
        _collectionRepository = collectionRepository;
    }

    public async Task<ServiceResponse<IEnumerable<Collection>>> GetAllAsync()
    {
        var response = new ServiceResponse<IEnumerable<Collection>>();

        if (await _collectionRepository.GetAll() is { } collections)
        {
            response.Data = collections;
            response.Message = "Collections found";
            response.Success = true;
        }
        else
        {
            response.Success = false;
            response.Message = "Collections not found";
        }

        return response;
    }

    public async Task<ServiceResponse<Collection>> GetByIdAsync(int id)
    {
        var response = new ServiceResponse<Collection>();
        
        if (await _collectionRepository.GetById(id) is { } collection)
        {
            response.Data = collection;
            response.Message = "Collection found";
            response.Success = true;
        }
        else
        {
            response.Success = false;
            response.Message = "Collection not found";
        }

        return response;
    }

    public async Task<ServiceResponse<Collection>> GetByNameAsync(string name)
    {
        var response = new ServiceResponse<Collection>();
        
        if (await _collectionRepository.GetByName(name) is { } collection)
        {
            response.Data = collection;
            response.Message = "Collection found";
            response.Success = true;
        }
        else
        {
            response.Success = false;
            response.Message = "Collection not found";
        }

        return response;
    }

    public async Task<ServiceResponse<Collection>> CreateAsync(Collection collection)
    {
        var response = new ServiceResponse<Collection>();

        if (await _collectionRepository.Create(collection) > 0)
        {
            response.Data = collection;
            response.Message = "Collection created successfully";
            response.Success = true;
        }
        else
        {
            response.Success = false;
            response.Message = "Failed to create collection";
        }

        return response;
    }

    public async Task<ServiceResponse<Collection>> UpdateAsync(Collection collection)
    {
        var response = new ServiceResponse<Collection>();
        
        if (await _collectionRepository.Update(collection) > 0)
        {
            response.Data = collection;
            response.Message = "Collection updated successfully";
            response.Success = true;
        }
        else
        {
            response.Success = false;
            response.Message = "Failed to update collection";
        }

        return response;
    }

    public async Task<ServiceResponse<bool>> DeleteAsync(int id)
    {
        var response = new ServiceResponse<bool>();

        if (await _collectionRepository.Delete(id) > 0)
        {
            response.Data = true;
            response.Message = "Collection deleted successfully";
            response.Success = true;
        }
        else
        {
            response.Success = false;
            response.Message = "Failed to delete collection";
        }
        
        return response;
    }

    public async Task<ServiceResponse<bool>> DeleteAsync(string name)
    {
        var response = new ServiceResponse<bool>();
        
        if (await _collectionRepository.Delete(name) > 0)
        {
            response.Data = true;
            response.Message = "Collection deleted successfully";
            response.Success = true;
        }
        else
        {
            response.Success = false;
            response.Message = "Failed to delete collection";
        }

        return response;
    }

    public async Task<ServiceResponse<bool>> DeleteAsync(Collection collection)
    {
        var response = new ServiceResponse<bool>();
        
        if (await _collectionRepository.Delete(collection.Id) > 0)
        {
            response.Data = true;
            response.Message = "Collection deleted successfully";
            response.Success = true;
        }
        else
        {
            response.Success = false;
            response.Message = "Failed to delete collection";
        }
        
        return response;
    }
}