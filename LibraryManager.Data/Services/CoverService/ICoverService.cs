using System.Collections;
using LibraryManager.Data.Models;

namespace LibraryManager.Data.Services.CoverService;

public interface ICoverService
{
    Task<IEnumerable<Cover>> GetAllAsync();
    Task<Cover> GetByIdAsync(int id);
    Task<Cover> CreateAsync(Cover cover);
    Task<Cover> UpdateAsync(Cover cover);
    Task<bool> DeleteAsync(int id);
}