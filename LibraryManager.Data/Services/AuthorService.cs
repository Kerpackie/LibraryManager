using LibraryManager.Data.Models;
using LibraryManager.Data.Repositories.AuthorRepositories;

namespace LibraryManager.Data.Services;

public class AuthorService : IAuthorService
{
	private readonly IAuthorRepository _authorRepository;

	public AuthorService(IAuthorRepository authorRepository)
	{
		_authorRepository = authorRepository;
	}

	public async Task<ServiceResponse<Author>> CreateAuthorAsync(Author author)
	{
		var response = new ServiceResponse<Author>();

		if (await _authorRepository.Create(author) > 0)
		{
			response.Data = author;
			response.Message = "Author created successfully";
			response.Success = true;
		}
		else
		{
			response.Success = false;
			response.Message = "Failed to create author";
		}
		
		return response;
	}

	public async Task<ServiceResponse<Author>> GetAuthorAsync(int id)
	{
		var response = new ServiceResponse<Author>();

		if (await _authorRepository.GetById(id) is { } author)
		{
			response.Data = author;
			response.Message = "Author found";
			response.Success = true;
		}
		else
		{
			response.Success = false;
			response.Message = "Author not found";
		}

		return response;

	}

	public async Task<ServiceResponse<List<Author>>> GetAllAuthorsAsync()
	{
		throw new NotImplementedException();
	}

	public async Task<ServiceResponse<Author>> GetAuthorByNameAsync(string name)
	{
		throw new NotImplementedException();
	}

	public async Task<ServiceResponse<Author>> UpdateAuthorAsync(Author author)
	{
		throw new NotImplementedException();
	}

	public async Task<ServiceResponse<bool>> DeleteAuthorAsync(int id)
	{
		throw new NotImplementedException();
	}

	public async Task<ServiceResponse<bool>> DeleteAuthorAsync(string name)
	{
		throw new NotImplementedException();
	}

	public async Task<ServiceResponse<bool>> AddAuthorToBookAsync(Book book, Author author)
	{
		throw new NotImplementedException();
	}
}