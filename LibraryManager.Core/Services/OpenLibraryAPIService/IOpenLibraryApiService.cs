using LibraryManager.Core.Models;
using Refit;

namespace LibraryManager.Core.Services.OpenLibraryAPIService;

public interface IOpenLibraryApiService
{
	[Get("/api/books?bibkeys=ISBN:{isbn}&format=json&jscmd=data")]
	Task<Dictionary<string, OpenLibraryResponse>> GetBookByIsbn(string isbn);
}