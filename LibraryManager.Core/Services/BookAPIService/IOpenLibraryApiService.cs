using LibraryManager.Core.Models.OpenLibraryResponseModels;
using Refit;

namespace LibraryManager.Core.Services.BookAPIService;

public interface IOpenLibraryApiService
{
	[Get("/api/books?bibkeys=ISBN:{isbn}&format=json&jscmd=data")]
	Task<Dictionary<string, OpenLibraryResponse>> GetBookByIsbn(string isbn);

    [Get("/search.json?q=subject:{subject}+isbn:[* TO *]&limit=1")]
    Task<OpenLibrarySearchResponse> GetRecommendedAsync(string subject);
}