using LibraryManager.Data.Models;

namespace LibraryManager.Data.Services.CoverService;

public class CoverService : ICoverService
{
    private readonly ICoverService _coverService;

    public CoverService(ICoverService coverService)
    {
        _coverService = coverService;
    }

    public Task<IEnumerable<Cover>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Cover> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Cover> CreateAsync(Cover cover)
    {
        throw new NotImplementedException();
    }

    public Task<Cover> UpdateAsync(Cover cover)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}