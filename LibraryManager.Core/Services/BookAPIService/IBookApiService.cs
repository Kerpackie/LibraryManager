using LibraryManager.Core.Models;
using LibraryManager.Core.Models.OpenLibraryResponseModels;

namespace LibraryManager.Core.Services.BookAPIService;

public interface IBookApiService
{
	Task<ServiceResponse<T>> GetBookFromApiAsync<T>(string isbn) where T : class;
    Task<ServiceResponse<T>> GetSuggestedBookAsync<T>(string subject) where T : class;
}