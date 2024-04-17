using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using LibraryManager.Core.Validators.PublisherValidator;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Core.Services.PublisherService;

public class PublisherService : IPublisherService
{
	private readonly LibraryContext _context;
	private readonly IPublisherValidator _publisherValidator;

	public PublisherService(LibraryContext context, IPublisherValidator publisherValidator)
	{
		_context = context;
		_publisherValidator = publisherValidator;
	}

	public async Task<ServiceResponse<Publisher>> InsertOrIgnorePublisherAsync(Publisher publisher)
	{
		var validateResult = _publisherValidator.Validate(publisher);

		if (!validateResult.IsValid)
		{
			return new ServiceResponse<Publisher>
			{
				Data = null,
				Message = string.Join(", ", validateResult.Errors),
				Success = false
			};
		}
		
		publisher.Trim();
		
		var existingPublisher = await _context.Publishers.FirstOrDefaultAsync(p => p.Name == publisher.Name);

		if (existingPublisher == null)
		{
			_context.Publishers.Add(publisher);
			await _context.SaveChangesAsync();

			var responseSuccess = new ServiceResponse<Publisher>
			{
				Data = publisher,
				Message = "Publisher added",
				Success = true
			};
			
			return responseSuccess;
		}

		var responseFail = new ServiceResponse<Publisher>
		{
			Data = existingPublisher,
			Message = "Publisher already exists",
			Success = false
		};
		
		return responseFail;
	}

    public async Task<ServiceResponse<List<Publisher>>> GetAllPublishersAsync()
    {
		var publishers = await _context.Publishers.ToListAsync();

        if (publishers.Count == 0)
        {
			var responseFail = new ServiceResponse<List<Publisher>>
            {
                Data = null,
                Message = "No publishers found",
                Success = false
            };
            return responseFail;
        }

        var responseSuccess = new ServiceResponse<List<Publisher>>
        {
            Data = publishers,
            Message = "Publishers found",
            Success = true
        };
        return responseSuccess;

    }

    public async Task<ServiceResponse<Publisher?>> GetPublisherAsync(int id)
	{
		var publisher = await _context.Publishers.FirstOrDefaultAsync(p => p.Id == id);

		if (publisher == null)
		{
			var responseFail = new ServiceResponse<Publisher?>
			{
				Data = null,
				Message = "Publisher not found",
				Success = false
			};
			
			return responseFail;
		}

		var responseSuccess = new ServiceResponse<Publisher?>
		{
			Data = publisher,
			Message = "Publisher found",
			Success = true
		};
		
		return responseSuccess;
	}

	public async Task<ServiceResponse<Publisher?>> GetPublisherByNameAsync(string name)
	{
		var publisher = await _context.Publishers.FirstOrDefaultAsync(p => p.Name == name);

		if (publisher == null)
		{
			var responseFail = new ServiceResponse<Publisher?>
			{
				Data = null,
				Message = "Publisher not found",
				Success = false
			};
			
			return responseFail;
		}

		var responseSuccess = new ServiceResponse<Publisher?>
		{
			Data = publisher,
			Message = "Publisher found",
			Success = true
		};
		
		return responseSuccess;
	}

	public async Task<ServiceResponse<Publisher>> UpdatePublisherAsync(Publisher publisher)
	{
		var validateResult = _publisherValidator.Validate(publisher);

		if (!validateResult.IsValid)
		{
			return new ServiceResponse<Publisher>
			{
				Data = null,
				Message = string.Join(", ", validateResult.Errors),
				Success = false
			};
		}
		
		var existingPublisher = await _context.Publishers.FirstOrDefaultAsync(p => p.Id == publisher.Id);

		if (existingPublisher == null)
		{
			var responseFail = new ServiceResponse<Publisher>
			{
				Data = null,
				Message = "Publisher not found",
				Success = false
			};
			
			return responseFail;
		}

		existingPublisher.Name = publisher.Name;
		await _context.SaveChangesAsync();

		var responseSuccess = new ServiceResponse<Publisher>
		{
			Data = existingPublisher,
			Message = "Publisher updated",
			Success = true
		};
		
		return responseSuccess;
	}

	public async Task<ServiceResponse<bool>> DeletePublisherAsync(int id)
	{
		var publisher = await _context.Publishers.FirstOrDefaultAsync(p => p.Id == id);
		if (publisher == null)
		{
			var responseFail = new ServiceResponse<bool>
			{
				Data = false,
				Message = "Publisher not found",
				Success = false
			};
			return responseFail;
		}
		
		_context.Publishers.Remove(publisher);
		await _context.SaveChangesAsync();
		
		var responseSuccess = new ServiceResponse<bool>
		{
			Data = true,
			Message = "Publisher deleted",
			Success = true
		};
		return responseSuccess;
	}

	public async Task<ServiceResponse<bool>> DeletePublisherAsync(string name)
	{
		var publisher = await _context.Publishers.FirstOrDefaultAsync(p => p.Name == name);
		if (publisher == null)
		{
			var responseFail = new ServiceResponse<bool>
			{
				Data = false,
				Message = "Publisher not found",
				Success = false
			};
			return responseFail;
		}
		
		_context.Publishers.Remove(publisher);
		await _context.SaveChangesAsync();
		
		var responseSuccess = new ServiceResponse<bool>
		{
			Data = true,
			Message = "Publisher deleted",
			Success = true
		};
		return responseSuccess;
	}
}