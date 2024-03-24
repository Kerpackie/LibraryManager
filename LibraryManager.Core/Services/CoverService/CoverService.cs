using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Core.Services.CoverService;

public class CoverService : ICoverService
{
	private readonly LibraryContext _context;

	public CoverService(LibraryContext context)
	{
		_context = context;
	}

	public async Task<ServiceResponse<Cover>> InsertOrIgnoreCoverAsync(Cover cover)
	{
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

	public async Task<ServiceResponse<Cover?>> UpdateCoverAsync(Cover cover)
	{
		var existingCover = await _context.Covers.FirstOrDefaultAsync(c => c.Id == cover.Id);

		if (existingCover == null)
		{
			var responseFail = new ServiceResponse<Cover?>
			{
				Data = null,
				Message = "Cover not found",
				Success = false
			};
			
			return responseFail;
		}

		_context.Covers.Update(cover);
		await _context.SaveChangesAsync();

		var responseSuccess = new ServiceResponse<Cover?>
		{
			Data = cover,
			Message = "Cover updated",
			Success = true
		};

		return responseSuccess;
	}

	public async Task<ServiceResponse<Cover>> DeleteCoverAsync(int id)
	{
		var cover = await _context.Covers.FirstOrDefaultAsync(c => c.Id == id);

		if (cover == null)
		{
			var responseFail = new ServiceResponse<Cover>
			{
				Data = null,
				Message = "Cover not found",
				Success = false
			};
			
			return responseFail;
		}

		_context.Covers.Remove(cover);
		await _context.SaveChangesAsync();

		var responseSuccess = new ServiceResponse<Cover>
		{
			Data = cover,
			Message = "Cover deleted",
			Success = true
		};

		return responseSuccess;
	}
}