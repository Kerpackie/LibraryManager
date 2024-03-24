using LibraryManager.Core.Models;

namespace LibraryManager.Core.Services.BookAPIService;

public class OpenLibraryBookApiService : IBookApiService
{
	private readonly IOpenLibraryApiService _openLibraryApiService;

	public OpenLibraryBookApiService(IOpenLibraryApiService openLibraryApiService)
	{
		_openLibraryApiService = openLibraryApiService;
	}

	public async Task<ServiceResponse<T>> GetBookFromApiAsync<T>(string isbn) where T : class
	{
		var response = await _openLibraryApiService.GetBookByIsbn(isbn);
		if (response != null && response.ContainsKey($"ISBN:{isbn}"))
		{
			var book = response[$"ISBN:{isbn}"];
			var responseSuccess = new ServiceResponse<T>
			{
				Data = book as T,
				Message = "Book found",
				Success = true
			};
			return responseSuccess;
		}
		
		var responseFail = new ServiceResponse<T>
		{
			Data = null,
			Message = "Book not found",
			Success = false
		};
		
		return responseFail;
	}
}