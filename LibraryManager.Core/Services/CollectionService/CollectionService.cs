﻿using LibraryManager.Core.Models;
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

	public async Task<ServiceResponse<Collection>> CreateCollectionAsync(Collection newCollection)
	{
		var serviceResponse = new ServiceResponse<Collection>();

		try
		{
			var collection = await _context.Collections.FirstOrDefaultAsync(c => c.Name == newCollection.Name);
				
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

	public async Task<ServiceResponse<Collection>> GetCollectionAsync(int id)
	{
		var serviceResponse = new ServiceResponse<Collection>();

		try
		{
			var collection = await _context.Collections
                .Include(c => c.Books)
                .FirstOrDefaultAsync(c => c.Id == id);

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

	public async Task<ServiceResponse<Collection>> GetCollectionByNameAsync(string name)
	{
		var serviceResponse = new ServiceResponse<Collection>();

		try
		{
			var collection = _context.Collections
                .Include(c => c.Books)
                .FirstOrDefault(c => c.Name == name);

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

	public async Task<ServiceResponse<List<Collection>>> GetAllCollectionsAsync()
	{
		var serviceResponse = new ServiceResponse<List<Collection>>();

		try
		{
            var collections = await _context.Collections
                .Include(c => c.Books)
                .ThenInclude(b => b.Author)
                .Include(c => c.Books)
                .ThenInclude(b => b.Publisher)
                .Include(c => c.Books)
                .ThenInclude(b => b.Cover)
                .Include(c => c.Books)
                .ThenInclude(b => b.Subjects)
                .ToListAsync();

            if (collections.Count == 0)
			{
				serviceResponse.Success = false;
				serviceResponse.Message = "No collections found";
				return serviceResponse;
			}

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

	public async Task<ServiceResponse<Collection>> UpdateCollectionAsync(Collection updatedCollection)
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
			
			var collectionWithSameName = await _context.Collections.FirstOrDefaultAsync(c => c.Name == updatedCollection.Name);

			if (collectionWithSameName != null && collectionWithSameName.Id != updatedCollection.Id)
			{
				serviceResponse.Success = false;
				serviceResponse.Message = "Collection with the same name already exists";
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

	public async Task<ServiceResponse<bool>> DeleteCollectionAsync(int id)
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

	public async Task<ServiceResponse<bool>> DeleteCollectionAsync(string name)
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
	
	public async Task<ServiceResponse<Collection>> AddBookToCollectionAsync(int collectionId, int bookId)
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

	public async Task<ServiceResponse<Collection>> RemoveBookFromCollectionAsync(int collectionId, int bookId)
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

			if (collection.Books.All(b => b.Id != bookId))
			{
				serviceResponse.Success = false;
				serviceResponse.Message = "Book does not exist in the collection";
				return serviceResponse;
			}

			collection.Books.Remove(book);
			await _context.SaveChangesAsync();

			serviceResponse.Data = collection;
			serviceResponse.Message = "Book removed from collection successfully";
		}
		catch (Exception ex)
		{
			serviceResponse.Success = false;
			serviceResponse.Message = $"An error occurred: {ex.Message}";
		}

		return serviceResponse;
	}
}
