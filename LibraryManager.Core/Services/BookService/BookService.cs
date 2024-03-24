using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using LibraryManager.Core.Models.OpenLibraryResponseModels;
using LibraryManager.Core.Services.AuthorService;
using LibraryManager.Core.Services.BookAPIService;
using LibraryManager.Core.Services.CoverService;
using LibraryManager.Core.Services.PublisherService;
using LibraryManager.Core.Services.SubjectService;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Core.Services.BookService;

public class BookService : IBookService
{
	private readonly LibraryContext _context;
	private readonly IBookApiService _bookApiService;
	private readonly ICoverService _coverService;
	private readonly IPublisherService _publisherService;
	private readonly ISubjectService _subjectService;
	private readonly IAuthorService _authorService;

	public BookService(ICoverService coverService, IBookApiService bookApiService, 
		LibraryContext context, IPublisherService publisherService, ISubjectService subjectService, 
		IAuthorService authorService)
	{
		_coverService = coverService;
		_bookApiService = bookApiService;
		_context = context;
		_publisherService = publisherService;
		_subjectService = subjectService;
		_authorService = authorService;
	}

	public async Task<ServiceResponse<Book>> LoadBookFromApiWithIsbnAsync(string isbn)
	{
		var data = await _bookApiService.GetBookFromApiAsync<OpenLibraryResponse>(isbn);
		if (!data.Success)
		{
			return new ServiceResponse<Book>
			{
				Data = null,
				Message = data.Message,
				Success = false
			};
		}

		if (data.Data == null)
		{
			return new ServiceResponse<Book>
			{
				Data = null,
				Message = "Book not found",
				Success = false
			};
		}
		
		var openLibraryResponse = data.Data;
		var book = new Book(openLibraryResponse);
		await InsertOrIgnoreBookAsync(book);
		
		return new ServiceResponse<Book>
		{
			Data = book,
			Message = "Book loaded",
			Success = true
		};
		
	}

	public async Task<ServiceResponse<Book>> InsertOrIgnoreBookAsync(Book book)
	{
		book.Trim();
		
		await using var transaction = await _context.Database.BeginTransactionAsync();
		try
		{
			var data = await _context.Books.FirstOrDefaultAsync(b => b.Isbn == book.Isbn);

			if (data != null)
			{
				await transaction.RollbackAsync();
				var responseFail = new ServiceResponse<Book>
				{
					Data = data,
					Message = "Book already exists",
					Success = false
				};
				return responseFail;
			}
			
			// Handle insertion or ignoring of related entities
			var author = await _authorService.InsertOrIgnoreAuthorAsync(book.Author);
			book.Author = author.Data;
			
			var publisher = await _publisherService.InsertOrIgnorePublisherAsync(book.Publisher);
			book.Publisher = publisher.Data;
			
			var covers = await _coverService.InsertOrIgnoreCoverAsync(book.Cover);
			book.Cover = covers.Data;
			
			var existingSubjects = 
				await _subjectService.InsertOrIgnoreSubjectsAsync(book.Subjects.ToList());

			if (existingSubjects.Data != null) book.Subjects = existingSubjects.Data;

			// Add the book to the context and save changes
			_context.Books.Add(book);
			await _context.SaveChangesAsync();

			await transaction.CommitAsync();
				
			var responseSuccess = new ServiceResponse<Book>
			{
				Data = book,
				Message = "Book added",
				Success = true
			};
			return responseSuccess;
		}
		catch (Exception)
		{
			await transaction.RollbackAsync();
			throw; // Rethrow the exception for handling at a higher level
		}
	}

	public async Task<ServiceResponse<Book>> GetBookByIsbnAsync(string isbn)
	{
		var book = await _context.Books
			.Include(b => b.Author)
			.Include(b => b.Publisher)
			.Include(b => b.Cover)
			.Include(b => b.Subjects)
			.FirstOrDefaultAsync(b => b.Isbn == isbn);

		if (book == null)
		{
			var responseFail = new ServiceResponse<Book>
			{
				Data = null,
				Message = "Book not found",
				Success = false
			};
			return responseFail;
		}
		
		var responseSuccess = new ServiceResponse<Book>
		{
			Data = book,
			Message = "Book found",
			Success = true
		};
		return responseSuccess;
	}

	public async Task<ServiceResponse<Book>> GetBookAsync(long id)
	{
		var book = await _context.Books
			.Include(b => b.Author)
			.Include(b => b.Publisher)
			.Include(b => b.Cover)
			.Include(b => b.Subjects)
			.FirstOrDefaultAsync(b => b.Id == id);

		if (book == null)
		{
			var responseFail = new ServiceResponse<Book>
			{
				Data = null,
				Message = "Book not found",
				Success = false
			};
			return responseFail;
		}
		
		var responseSuccess = new ServiceResponse<Book>
		{
			Data = book,
			Message = "Book found",
			Success = true
		};
		return responseSuccess;
	}

	public async Task<ServiceResponse<Book>> GetBookByTitleAsync(string title)
	{
		var book = await _context.Books
			.Include(b => b.Author)
			.Include(b => b.Publisher)
			.Include(b => b.Cover)
			.Include(b => b.Subjects)
			.FirstOrDefaultAsync(b => b.Title == title);

		if (book == null)
		{
			var responseFail = new ServiceResponse<Book>
			{
				Data = null,
				Message = "Book not found",
				Success = false
			};
			return responseFail;
		}
		
		var responseSuccess = new ServiceResponse<Book>
		{
			Data = book,
			Message = "Book found",
			Success = true
		};
		return responseSuccess;
	}

	public async Task<ServiceResponse<IEnumerable<Book>>> GetAllBooksAsync()
	{
		var books = await _context.Books
			.Include(b => b.Author)
			.Include(b => b.Publisher)
			.Include(b => b.Cover)
			.Include(b => b.Subjects)
			.ToListAsync();

		var responseSuccess = new ServiceResponse<IEnumerable<Book>>
		{
			Data = books,
			Message = "Books found",
			Success = true
		};
		return responseSuccess;
	}

	public async Task<ServiceResponse<IEnumerable<Book>>> GetBooksByAuthorAsync(string authorName)
	{
		var author = await _authorService.GetAuthorByNameAsync(authorName);
		if (!author.Success)
		{
			var responseFail = new ServiceResponse<IEnumerable<Book>>
			{
				Data = null,
				Message = "Author not found",
				Success = false
			};
			return responseFail;
		}

		var books = await _context.Books
			.Include(b => b.Author)
			.Include(b => b.Publisher)
			.Include(b => b.Cover)
			.Include(b => b.Subjects)
			.Where(b => b.Author.Id == author.Data.Id)
			.ToListAsync();

		var responseSuccess = new ServiceResponse<IEnumerable<Book>>
		{
			Data = books,
			Message = "Books found",
			Success = true
		};
		return responseSuccess;
	}

	public async Task<ServiceResponse<IEnumerable<Book>>> GetBooksBySubjectAsync(string subject)
	{
		var subjectData = await _subjectService.GetSubjectByNameAsync(subject);
		if (!subjectData.Success)
		{
			var responseFail = new ServiceResponse<IEnumerable<Book>>
			{
				Data = null,
				Message = "Subject not found",
				Success = false
			};
			return responseFail;
		}

		var books = await _context.Books
			.Include(b => b.Author)
			.Include(b => b.Publisher)
			.Include(b => b.Cover)
			.Include(b => b.Subjects)
			.Where(b => b.Subjects.Any(s => s.Id == subjectData.Data.Id))
			.ToListAsync();

		var responseSuccess = new ServiceResponse<IEnumerable<Book>>
		{
			Data = books,
			Message = "Books found",
			Success = true
		};
		return responseSuccess;
	}

	public async Task<ServiceResponse<IEnumerable<Book>>> GetBooksByPublisherAsync(string publisher)
	{
		var publisherData = await _publisherService.GetPublisherByNameAsync(publisher);
		if (!publisherData.Success)
		{
			var responseFail = new ServiceResponse<IEnumerable<Book>>
			{
				Data = null,
				Message = "Publisher not found",
				Success = false
			};
			return responseFail;
		}

		var books = await _context.Books
			.Include(b => b.Author)
			.Include(b => b.Publisher)
			.Include(b => b.Cover)
			.Include(b => b.Subjects)
			.Where(b => b.Publisher.Id == publisherData.Data.Id)
			.ToListAsync();

		var responseSuccess = new ServiceResponse<IEnumerable<Book>>
		{
			Data = books,
			Message = "Books found",
			Success = true
		};
		return responseSuccess;
	}

	public async Task<ServiceResponse<Book>> UpdateBookAsync(Book book)
	{
		var existingBook = await _context.Books.FirstOrDefaultAsync(b => b.Id == book.Id);
		if (existingBook == null)
		{
			var responseFail = new ServiceResponse<Book>
			{
				Data = null,
				Message = "Book not found",
				Success = false
			};
			return responseFail;
		}

		existingBook.Title = book.Title;
		existingBook.Isbn = book.Isbn;
		existingBook.Author = book.Author;
		existingBook.Publisher = book.Publisher;
		existingBook.Cover = book.Cover;
		existingBook.Subjects = book.Subjects;

		await _context.SaveChangesAsync();

		var responseSuccess = new ServiceResponse<Book>
		{
			Data = existingBook,
			Message = "Book updated",
			Success = true
		};
		return responseSuccess;
	}

	public async Task<ServiceResponse<Book>> DeleteBookAsync(long id)
	{
		var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
		if (book == null)
		{
			var responseFail = new ServiceResponse<Book>
			{
				Data = null,
				Message = "Book not found",
				Success = false
			};
			return responseFail;
		}

		_context.Books.Remove(book);
		await _context.SaveChangesAsync();

		var responseSuccess = new ServiceResponse<Book>
		{
			Data = book,
			Message = "Book deleted",
			Success = true
		};
		return responseSuccess;
	}

	public async Task<ServiceResponse<Book>> DeleteBookByIsbnAsync(string isbn)
	{
		var book = await _context.Books.FirstOrDefaultAsync(b => b.Isbn == isbn);
		if (book == null)
		{
			var responseFail = new ServiceResponse<Book>
			{
				Data = null,
				Message = "Book not found",
				Success = false
			};
			return responseFail;
		}

		_context.Books.Remove(book);
		await _context.SaveChangesAsync();

		var responseSuccess = new ServiceResponse<Book>
		{
			Data = book,
			Message = "Book deleted",
			Success = true
		};
		return responseSuccess;
	}
}