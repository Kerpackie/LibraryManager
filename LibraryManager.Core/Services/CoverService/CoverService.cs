using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using LibraryManager.Core.Validators.CoverValidator;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Core.Services.CoverService;

public class CoverService : ICoverService
{
	private readonly LibraryContext _context;
	private readonly IHttpClientFactory _clientFactory;
	private readonly ICoverValidator _coverValidator;

	public CoverService(LibraryContext context, IHttpClientFactory clientFactory, ICoverValidator coverValidator)
	{
		_context = context;
		_clientFactory = clientFactory;
		_coverValidator = coverValidator;
	}

	public async Task<ServiceResponse<Cover>> InsertOrIgnoreCoverAsync(Cover cover)
	{
		var validationResult = _coverValidator.Validate(cover);

		if (!validationResult.IsValid)
		{
			return new ServiceResponse<Cover>
			{
				Data = null,
				Message = string.Join(", ", validationResult.Errors),
				Success = false
			};
		}
		
		cover.Trim();
		
		var existingCover = await _context.Covers.FirstOrDefaultAsync(c => c.Id == cover.Id);

		if (existingCover == null)
		{
			_context.Covers.Add(cover);
			await _context.SaveChangesAsync();

			var responseSuccess = new ServiceResponse<Cover>
			{
				Data = cover,
				Message = "Cover added",
				Success = true
			};

			return responseSuccess;
		}
		
		var responseFail = new ServiceResponse<Cover>
		{
			Data = existingCover,
			Message = "Cover already exists",
			Success = false
		};

		return responseFail;
	}

	public async Task<ServiceResponse<Cover?>> GetCoverAsync(int id)
	{
		var cover = await _context.Covers.FirstOrDefaultAsync(c => c.Id == id);

		if (cover == null)
		{
			var responseFail = new ServiceResponse<Cover?>
			{
				Data = null,
				Message = "Cover not found",
				Success = false
			};
			
			return responseFail;
		}
		
		var responseSuccess = new ServiceResponse<Cover?>
		{
			Data = cover,
			Message = "Cover found",
			Success = true
		};

		return responseSuccess;
	}

	public async Task<ServiceResponse<Cover>> UpdateCoverAsync(Cover cover)
	{
		var validationResult = _coverValidator.Validate(cover);

		if (!validationResult.IsValid)
		{
			return new ServiceResponse<Cover>
			{
				Data = null,
				Message = string.Join(", ", validationResult.Errors),
				Success = false
			};
		}
		
		var existingCover = await _context.Covers.FirstOrDefaultAsync(c => c.Id == cover.Id);

		if (existingCover == null)
		{
			var responseFail = new ServiceResponse<Cover>
			{
				Data = null,
				Message = "Cover not found",
				Success = false
			};
			
			return responseFail;
		}

		_context.Covers.Update(cover);
		await _context.SaveChangesAsync();

		var responseSuccess = new ServiceResponse<Cover>
		{
			Data = cover,
			Message = "Cover updated",
			Success = true
		};

		return responseSuccess;
	}

	public async Task<ServiceResponse<bool>> DeleteCoverAsync(int id)
	{
		var cover = await _context.Covers.FirstOrDefaultAsync(c => c.Id == id);

		if (cover == null)
		{
			var responseFail = new ServiceResponse<bool>
			{
				Data = false,
				Message = "Cover not found",
				Success = false
			};
			
			return responseFail;
		}

		_context.Covers.Remove(cover);
		await _context.SaveChangesAsync();

		var responseSuccess = new ServiceResponse<bool>
		{
			Data = true,
			Message = "Cover deleted",
			Success = true
		};

		return responseSuccess;
	}
	
	public async Task<ServiceResponse<bool>> DownloadCoverImageAsync(string isbn, Cover cover)
	{
		
		var response = new ServiceResponse<bool>();
		try
		{
			var client = _clientFactory.CreateClient();

			// Ensure the directory exists
			Directory.CreateDirectory($"./Images/{isbn}");

			// Download and save each cover in parallel
			var tasks = new[]
			{
				DownloadAndSaveCoverAsync(client, cover.Small, $"{isbn}/{isbn}_small.jpg"),
				DownloadAndSaveCoverAsync(client, cover.Medium, $"{isbn}/{isbn}_medium.jpg"),
				DownloadAndSaveCoverAsync(client, cover.Large, $"{isbn}/{isbn}_large.jpg")
			};

			await Task.WhenAll(tasks);

			response.Data = true;
			response.Message = "Images downloaded successfully";
			response.Success = true;
		}
		catch (HttpRequestException ex)
		{
			// Handle exception related to the HTTP request
			response.Data = false;
			response.Message = $"An error occurred while downloading the image: {ex.Message}";
			response.Success = false;
		}
		catch (IOException ex)
		{
			// Handle exception related to writing the file
			response.Data = false;
			response.Message = $"An error occurred while saving the image: {ex.Message}";
			response.Success = false;
		}
		catch (Exception ex)
		{
			// Handle any other exceptions
			response.Data = false;
			response.Message = $"An error occurred: {ex.Message}";
			response.Success = false;
		}

		return response;
	}

	private static async Task DownloadAndSaveCoverAsync(HttpClient client, string url, string fileName)
	{
		var response = await client.GetAsync(url);

		if (response.IsSuccessStatusCode)
		{
			var imageBytes = await response.Content.ReadAsByteArrayAsync();
			await File.WriteAllBytesAsync($"./Images/{fileName}", imageBytes);
		}
	}
}