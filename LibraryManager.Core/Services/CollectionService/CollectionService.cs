using LibraryManager.Core.Models;
using LibraryManager.Core.Data;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Core.Services.CollectionService;

public class CollectionService : ICollectionService
{
	private readonly LibraryContext _context;

	public CollectionService(LibraryContext context)
	{
		_context = context;
	}

	public async Task<ServiceResponse<Collection>> CreateCollection(Collection newCollection)
	{
		var serviceResponse = new ServiceResponse<Collection>();

		try
		{
			var collection = await _context.Collections.FindAsync(newCollection.Name);
				
			if (collection != null)
			{
				serviceResponse.Success = false;
				serviceResponse.Message = "Collection already exists";
				return serviceResponse;
			}

			_context.Collections.Add(newCollection);
			await _context.SaveChangesAsync();

			serviceResponse.Data = collection;
			serviceResponse.Message = "Collection added successfully";
		}
		catch (Exception ex)
		{
			serviceResponse.Success = false;
			serviceResponse.Message = $"An error occurred: {ex.Message}";
		}

		return serviceResponse;
	}

	public async Task<ServiceResponse<Collection>> GetCollection(int id)
	{
		var serviceResponse = new ServiceResponse<Collection>();

		try
		{
			var collection = await _context.Collections.FindAsync(id);

			if (collection == null)
			{
				serviceResponse.Success = false;
				serviceResponse.Message = "Collection not found";
				return serviceResponse;
			}
				
			serviceResponse.Data = collection;
			serviceResponse.Message = "Collection retrieved successfully";
		}
		
		catch (Exception ex)
		{
			serviceResponse.Success = false;
			serviceResponse.Message = $"An error occurred: {ex.Message}";
		}

		return serviceResponse;
	}

	public async Task<ServiceResponse<Collection>> GetCollection(string name)
	{
		var serviceResponse = new ServiceResponse<Collection>();

		try
		{
			var collection = _context.Collections.FirstOrDefault(c => c.Name == name);

			if (collection == null)
			{
				serviceResponse.Success = false;
				serviceResponse.Message = "Collection not found";
				return serviceResponse;
			}
				
			serviceResponse.Data = collection;
			serviceResponse.Message = "Collection retrieved successfully";
		}
		
		catch (Exception ex)
		{
			serviceResponse.Success = false;
			serviceResponse.Message = $"An error occurred: {ex.Message}";
		}

		return serviceResponse;
	}

	public async Task<ServiceResponse<IEnumerable<Collection>>> GetAllCollections()
	{
		var serviceResponse = new ServiceResponse<IEnumerable<Collection>>();

		try
		{
			var collections = await _context.Collections.ToListAsync();

			serviceResponse.Data = collections;
			serviceResponse.Message = "Collections retrieved successfully";
		}
		catch (Exception ex)
		{
			serviceResponse.Success = false;
			serviceResponse.Message = $"An error occurred: {ex.Message}";
		}

		return serviceResponse;
	}

	public async Task<ServiceResponse<Collection>> UpdateCollection(Collection updatedCollection)
	{
		var serviceResponse = new ServiceResponse<Collection>();

		try
		{
			var collection = await _context.Collections.FindAsync(updatedCollection.Id);

			if (collection == null)
			{
				serviceResponse.Success = false;
				serviceResponse.Message = "Collection not found";
				return serviceResponse;
			}

			collection.Name = updatedCollection.Name;
			await _context.SaveChangesAsync();

			serviceResponse.Data = collection;
			serviceResponse.Message = "Collection updated successfully";
		}
		catch (Exception ex)
		{
			serviceResponse.Success = false;
			serviceResponse.Message = $"An error occurred: {ex.Message}";
		}

		return serviceResponse;
	}

	public async Task<ServiceResponse<bool>> DeleteCollection(int id)
	{
		var serviceResponse = new ServiceResponse<bool>();

		try
		{
			var collection = await _context.Collections.FindAsync(id);

			if (collection == null)
			{
				serviceResponse.Success = false;
				serviceResponse.Message = "Collection not found";
				return serviceResponse;
			}
			
			if (collection.Name == "Wishlist")
			{
				serviceResponse.Success = false;
				serviceResponse.Message = "Cannot delete the Wishlist collection";
				return serviceResponse;
			}

			_context.Collections.Remove(collection);
			await _context.SaveChangesAsync();

			serviceResponse.Message = "Collection deleted successfully";
		}
		catch (Exception ex)
		{
			serviceResponse.Success = false;
			serviceResponse.Message = $"An error occurred: {ex.Message}";
		}

		return serviceResponse;
	}

	public async Task<ServiceResponse<bool>> DeleteCollection(string name)
	{
		var serviceResponse = new ServiceResponse<bool>();

		try
		{
			var collection = _context.Collections.FirstOrDefault(c => c.Name == name);

			if (collection == null)
			{
				serviceResponse.Success = false;
				serviceResponse.Message = "Collection not found";
				return serviceResponse;
			}

			if (collection.Name == "Wishlist")
			{
				serviceResponse.Success = false;
				serviceResponse.Message = "Cannot delete the Wishlist collection";
				return serviceResponse;
			}

			_context.Collections.Remove(collection);
			await _context.SaveChangesAsync();

			serviceResponse.Message = "Collection deleted successfully";
		}
		catch (Exception ex)
		{
			serviceResponse.Success = false;
			serviceResponse.Message = $"An error occurred: {ex.Message}";
		}

		return serviceResponse;
	}
	
	public async Task<ServiceResponse<Collection>> AddBookToCollection(int collectionId, int bookId)
	{
		var serviceResponse = new ServiceResponse<Collection>();

		try
		{
			var collection = await _context.Collections.FindAsync(collectionId);
			var book = await _context.Books.FindAsync(bookId);

			if (collection == null)
			{
				serviceResponse.Success = false;
				serviceResponse.Message = "Collection not found";
				return serviceResponse;
			}

			if (book == null)
			{
				serviceResponse.Success = false;
				serviceResponse.Message = "Book not found";
				return serviceResponse;
			}

			if (collection.Books.Any(b => b.Id == bookId))
			{
				serviceResponse.Success = false;
				serviceResponse.Message = "Book already exists in the collection";
				return serviceResponse;
			}

			collection.Books.Add(book);
			await _context.SaveChangesAsync();

			serviceResponse.Data = collection;
			serviceResponse.Message = "Book added to collection successfully";
		}
		catch (Exception ex)
		{
			serviceResponse.Success = false;
			serviceResponse.Message = $"An error occurred: {ex.Message}";
		}

		return serviceResponse;
	}
}
