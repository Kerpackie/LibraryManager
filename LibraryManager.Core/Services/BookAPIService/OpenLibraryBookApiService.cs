using LibraryManager.Core.Models;
using LibraryManager.Core.Models.OpenLibraryResponseModels;

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
		if (response.ContainsKey($"ISBN:{isbn}"))
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

	public async Task<ServiceResponse<T>> GetSuggestedBookAsync<T>(string subject) where T : class
	{
		var response = await _openLibraryApiService.GetRecommendedAsync(subject);

		if (response != null && response.Docs != null && response.Docs.Any())
		{
			var firstBook = response.Docs.FirstOrDefault();
			if (firstBook != null)
			{
				var isbn = firstBook.ISBN?.FirstOrDefault();
				if (!string.IsNullOrEmpty(isbn))
				{
					var bookResponse = await GetBookFromApiAsync<OpenLibraryResponse>(isbn);
					var openLibraryResponse = bookResponse.Data;
					var book = new Book(openLibraryResponse);

					return new ServiceResponse<T>()
					{
						Data = book as T,
						Message = bookResponse.Message,
						Success = true
					};
				}
			}
		}

		var responseFail = new ServiceResponse<T>
		{
			Data = default,
			Message = "Book not found",
			Success = false
		};

		return responseFail;
	}
}