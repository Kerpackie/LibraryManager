using LibraryManager.Core.Models;

namespace LibraryManager.Core.Services.CoverService;

public interface ICoverService
{
	Task<ServiceResponse<Cover>> InsertOrIgnoreCoverAsync(Cover cover);
	Task<ServiceResponse<Cover?>> GetCoverAsync(int id);
	Task<ServiceResponse<Cover>> UpdateCoverAsync(Cover cover);
	Task<ServiceResponse<bool>> DeleteCoverAsync(int id);
	Task<ServiceResponse<bool>> DownloadCoverImageAsync(string isbn, Cover cover);

}