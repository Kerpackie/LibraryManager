using LibraryManager.Core.Models;

namespace LibraryManager.Core.Services.CoverService;

public interface ICoverService
{
	Task<Cover> CreateCoverAsync(Cover cover);
	Task<Cover?> GetCoverAsync(int id);
	Task<Cover> UpdateCoverAsync(Cover cover);
	Task DeleteCoverAsync(int id);
}