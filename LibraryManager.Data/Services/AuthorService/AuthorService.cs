using LibraryManager.Data.Models;
using LibraryManager.Data.Repositories.AuthorRepositories;
using LibraryManager.Data.Repositories.BookRepositories;

namespace LibraryManager.Data.Services.AuthorService;

public class AuthorService : IAuthorService
{
	private readonly IAuthorRepository _authorRepository;
	private readonly IBookRepository _bookRepository;

	public AuthorService(IAuthorRepository authorRepository, IBookRepository bookRepository)
	{
		_authorRepository = authorRepository;
		_bookRepository = bookRepository;
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
	
        var response = new ServiceResponse<List<Author>>();

        if (await _authorRepository.GetAll() is { } authors)
        {
            response.Data = authors.ToList();
            response.Message = "Authors found";
            response.Success = true;
        }
        else
        {
            response.Success = false;
            response.Message = "Authors not found";
        }

        return response;
	}

	public async Task<ServiceResponse<Author>> GetAuthorByNameAsync(string name)
	{
		var response = new ServiceResponse<Author>();

		if (await _authorRepository.GetByName(name) is { } author)
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

	public async Task<ServiceResponse<Author>> UpdateAuthorAsync(Author author)
	{
		var response = new ServiceResponse<Author>();

		if (await _authorRepository.Update(author) > 0)
		{
			response.Data = author;
			response.Message = "Author updated successfully";
			response.Success = true;
		}
		else
		{
			response.Success = false;
			response.Message = "Failed to update author";
		}

		return response;
	}

	public async Task<ServiceResponse<bool>> DeleteAuthorAsync(int id)
	{
		var response = new ServiceResponse<bool>();

		if (await _authorRepository.Delete(id) > 0)
		{
			response.Data = true;
			response.Message = "Author deleted successfully";
			response.Success = true;
		}
		else
		{
			response.Success = false;
			response.Message = "Failed to delete author";
		}

		return response;
	}

	public async Task<ServiceResponse<bool>> DeleteAuthorAsync(string name)
	{
		var  response = new ServiceResponse<bool>();

		if (await _authorRepository.Delete(name) > 0)
		{
			response.Data = true;
			response.Message = "Author deleted successfully";
			response.Success = true;
		}
		else
		{
			response.Success = false;
			response.Message = "Failed to delete author";
		}

		return response;
	}

	public async Task<ServiceResponse<bool>> AddAuthorToBookAsync(Book book, Author author)
	{
		var response = new ServiceResponse<bool>();

		var dbBook = await _bookRepository.GetByIsbn(book.Isbn);
		var dbAuthor = await _authorRepository.GetByName(author.Name);
		
		if (dbBook is null || dbAuthor is null)
		{
			response.Success = false;
			response.Message = "Book or Author not found";
			return response;
		}
		
		if (await _authorRepository.AddAuthorToBook(dbBook.Id, dbAuthor.Id) > 0)
		{
			response.Data = true;
			response.Message = "Author added to book successfully";
			response.Success = true;
		}
		else
		{
			response.Success = false;
			response.Message = "Failed to add author to book";
		}

		return response;
	}
}