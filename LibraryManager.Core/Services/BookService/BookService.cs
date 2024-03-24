using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using LibraryManager.Core.Services.AuthorService;
using LibraryManager.Core.Services.CoverService;
using LibraryManager.Core.Services.OpenLibraryAPIService;
using LibraryManager.Core.Services.PublisherService;
using LibraryManager.Core.Services.SubjectService;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Core.Services.BookService;

public class BookService : IBookService, IBookService2
{
	private readonly LibraryContext _context;
	private readonly IOpenLibraryApiService _openLibraryApiService;
	private readonly ICoverService _coverService;
	private readonly IPublisherService _publisherService;
	private readonly ISubjectService _subjectService;
	private readonly IAuthorService _authorService;

	public BookService(
		LibraryContext context, IOpenLibraryApiService openLibraryApiService, 
		IAuthorService authorService, ISubjectService subjectService, 
		IPublisherService publisherService, ICoverService coverService)
	{
		_context = context;
		_openLibraryApiService = openLibraryApiService;
		_authorService = authorService;
		_subjectService = subjectService;
		_publisherService = publisherService;
		_coverService = coverService;
	}

	public async Task<Book> GetBookFromApiAsync(string isbn)
	{
		// Get the response from the API
		var response = await _openLibraryApiService.GetBookByIsbn(isbn);

		if (response != null && response.ContainsKey($"ISBN:{isbn}"))
		{
			
			var book = new Book(response[$"ISBN:{isbn}"]);
			await AddBookAsync(book);
			
			return book;
		}
		else
		{
			Console.WriteLine("Book not found in the API.");
			return null;
		}
	}
	
	public async Task<Book> AddBookAsync2(Book book)
	{
		// Check if a book with the same ISBN already exists
		var existingBook = await _context.Books.FindAsync(book.ISBN);

		if (existingBook != null)
		{
			// A book with the same ISBN already exists, handle accordingly
			// For example, you might want to throw an exception or return a specific result
			throw new Exception("A book with the same ISBN already exists.");
		}

		// No book with the same ISBN exists, proceed with adding the new book
		_context.Books.Add(book);
		await _context.SaveChangesAsync();
		return book;


	}
	
	public async Task<ServiceResponse<Book>> AddBookAsync(Book book)
	{
		try
		{
			_context.Books.Add(book);
			
			await HandleAuthorAsync(book);
			await HandlePublisherAsync(book);
			await HandleSubjectsAsync(book);
			await HandleCoverAsync(book);

			
			await _context.SaveChangesAsync();

			return new ServiceResponse<Book>
			{
				Data = book,
				Success = true,
				Message = "Book added successfully."
			};
		}
		catch (DbUpdateException ex) when ((ex.InnerException as SqliteException)?.SqliteErrorCode == SQLitePCL.raw.SQLITE_CONSTRAINT)
		{

			Console.WriteLine(ex.InnerException?.Message);
			return new ServiceResponse<Book>
			{
				Data = null,
				Success = false,
				Message = "A book with the same ISBN already exists."
			};
		}
		catch (DbUpdateConcurrencyException ex)
		{
			Console.WriteLine(ex.Message);
			
			return new ServiceResponse<Book>
			{
				Data = null,
				Success = false,
				Message = "A concurrency error occurred while trying to add the book."
			};
		}
		catch (InvalidOperationException ex)
		{
			Console.WriteLine(ex.Message);
			
			return new ServiceResponse<Book>
			{
				Data = null,
				Success = false,
				Message = "An invalid operation was attempted while trying to add the book."
			};
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
			return new ServiceResponse<Book>
			{
				Data = null,
				Success = false,
				Message = $"An unexpected error occurred: {e.Message}"
			};
		}
	}
	
	public async Task<ServiceResponse<Book>> UpdateBookAsync(Book book)
	{
	    var existingBook = await _context.Books
		    .Include(b => b.Author)
		    .Include(b => b.Publisher)
		    .Include(b => b.Cover)
		    .Include(b => b.BookSubjects)!
	            .ThenInclude(bs => bs.Subject)
	        .FirstOrDefaultAsync(b => b.ISBN == book.ISBN);

	    if (existingBook == null)
	    {
	        return new ServiceResponse<Book>
	        {
	            Data = null,
	            Success = false,
	            Message = "Book not found."
	        };
	    }

	    await UpdateAuthorAsync(book, existingBook);
	    await UpdatePublisherAsync(book, existingBook);
	    await UpdateSubjectsAsync(book, existingBook);
	    await UpdateCoverAsync(book, existingBook);

	    await _context.SaveChangesAsync();

	    return new ServiceResponse<Book>
	    {
	        Data = existingBook,
	        Success = true,
	        Message = "Book updated successfully."
	    };
	}

	private async Task UpdateAuthorAsync(Book book, Book existingBook)
	{
	    if (book.Author != null)
	    {
	        var existingAuthor = await _authorService.GetAuthorByNameAsync(book.Author.Name);
	        if (existingAuthor != null)
	        {
	            existingBook.Author = existingAuthor;
	        }
	        else
	        {
	            var newAuthor = await _authorService.CreateAuthorAsync(book.Author);
	            existingBook.Author = newAuthor;
	        }
	    }
	}

	private async Task UpdatePublisherAsync(Book book, Book existingBook)
	{
	    if (book.Publisher != null)
	    {
	        var existingPublisher = await _publisherService.GetPublisherByNameAsync(book.Publisher.Name);
	        if (existingPublisher != null)
	        {
	            existingBook.Publisher = existingPublisher;
	        }
	        else
	        {
	            var newPublisher = await _publisherService.CreatePublisherAsync(book.Publisher);
	            existingBook.Publisher = newPublisher;
	        }
	    }
	}

	private async Task UpdateSubjectsAsync(Book book, Book existingBook)
	{
		if (book.Subjects != null)
		{
			existingBook.BookSubjects.Clear();

			foreach (var subject in book.Subjects)
			{
				var existingSubject = await _subjectService.GetSubjectByNameAsync(subject.Name);
				if (existingSubject != null)
				{
					var bookSubject = new BookSubject
					{
						Book = existingBook,
						Subject = existingSubject
					};
					existingBook.BookSubjects.Add(bookSubject);
					_context.BookSubjects.Add(bookSubject); // Add this line
				}
				else
				{
					var newSubject = await _subjectService.CreateSubjectAsync(subject);
					var bookSubject = new BookSubject
					{
						Book = existingBook,
						Subject = newSubject
					};
					existingBook.BookSubjects.Add(bookSubject);
					_context.BookSubjects.Add(bookSubject); // Add this line
				}
			}
		}
	}

	private async Task UpdateCoverAsync(Book book, Book existingBook)
	{
	    if (book.Cover != null)
	    {
	        var existingCover = await _coverService.GetCoverAsync(book.CoverId);
	        if (existingCover != null)
	        {
	            existingBook.Cover = existingCover;
	        }
	        else
	        {
	            var newCover = await _coverService.CreateCoverAsync(book.Cover);
	            existingBook.Cover = newCover;
	        }
	    }
	}

	private async Task HandleAuthorAsync(Book book)
	{
		// Check if the book has an author
	    if (book.Author != null)
	    {
		    
		    // Check if the author already exists in the database
	        var existingAuthor = await _authorService.GetAuthorByNameAsync(book.Author.Name);
	        if (existingAuthor != null)
	        {
		        
		        // Set the state of the existing author to Unchanged
	            _context.Entry(existingAuthor).State = EntityState.Unchanged;
	            book.Author = existingAuthor;
	            
	            // Add the book to the author's list of books
	            existingAuthor.Books ??= new List<Book>();
	            existingAuthor.Books.Add(book);
	        }
	        else
	        {
		        // Create the author
	            await _authorService.CreateAuthorAsync(book.Author);
	        }
	    }
	}

	private async Task HandlePublisherAsync(Book book)
	{
	    if (book.Publisher != null)
	    {
	        var existingPublisher = await _publisherService.GetPublisherByNameAsync(book.Publisher.Name);
	        if (existingPublisher != null)
	        {
	            _context.Entry(existingPublisher).State = EntityState.Unchanged;
	            book.Publisher = existingPublisher;
	            existingPublisher.Books ??= new List<Book>();
	            existingPublisher.Books.Add(book);
	        }
	        else
	        {
	            await _publisherService.CreatePublisherAsync(book.Publisher);
	        }
	    }
	}

	private async Task HandleSubjectsAsync(Book book)
	{
		if (book.Subjects != null)
		{
			foreach (var subject in book.Subjects)
			{
				var existingSubject = await _subjectService.GetSubjectByNameAsync(subject.Name);
				if (existingSubject != null)
				{
					// Update the properties of the existingSubject here
					// ...

					var bookSubject = new BookSubject
					{
						Book = book,
						Subject = existingSubject
					};
					book.BookSubjects.Add(bookSubject);
					existingSubject.BookSubjects.Add(bookSubject);
				}
				else
				{
					await _subjectService.CreateSubjectAsync(subject);
				}
			}
		}
	}

	private async Task HandleCoverAsync(Book book)
	{
	    if (book.Cover != null)
	    {
	        var existingCover = await _coverService.GetCoverAsync(book.CoverId);
	        if (existingCover != null)
	        {
	            _context.Entry(existingCover).State = EntityState.Unchanged;
	            book.Cover = existingCover;
	        }
	        else
	        {
	            await _coverService.CreateCoverAsync(book.Cover);
	        }
	    }
	}
	
	public async Task<Book?> GetBookAsync(int id)
	{
		return await _context.Books.FindAsync(id);
	}
	
	public async Task<Book?> GetBookByIsbnAsync(string isbn)
	{
		return await _context.Books.FirstOrDefaultAsync(b => b.ISBN == isbn);
	}
	
	

	/*public async Task<Book?> CreateBookAsync(Book? book)
	{
		_context.Books.Add(book);
		await _context.SaveChangesAsync();
		return book;
	}

	public async Task<Book?> GetBookAsync(int id)
	{
		return await _context.Books.FindAsync(id);
	}

	public async Task<Book?> GetBookByIsbnAsync(string isbn)
	{
		return await _context.Books.FirstOrDefaultAsync(b => b.ISBN == isbn);
	}

	public async Task<IEnumerable<Book?>> GetAllBooksAsync()
	{
		return await _context.Books.ToListAsync();
	}

	public async Task<IEnumerable<Book?>> GetBooksByAuthorAsync(string author)
	{
		return await _context.Books.Where(b => b.Author == author).ToListAsync();
		
	}

	public async Task<IEnumerable<Book?>> GetBooksByTitleAsync(string title)
	{
		return await _context.Books.Where(b => b.Title == title).ToListAsync();
	}

	public async Task<IEnumerable<Book?>> GetBooksByPublisherAsync(string publisher)
	{
		throw new NotImplementedException();
	}

	public async Task<IEnumerable<Book?>> GetBooksByGenreAsync(string genre)
	{
		throw new NotImplementedException();
	}

	public async Task<IEnumerable<Book?>> GetBooksByPublicationYearAsync(string publicationYear)
	{
		throw new NotImplementedException();
	}

	public async Task<IEnumerable<Book?>> GetBooksByNumberOfPagesAsync(int numberOfPages)
	{
		return await _context.Books.Where(b => b.PageCount == numberOfPages).ToListAsync();
	}

	public async Task<IEnumerable<Book?>> GetBooksWithMorePagesThanAsync(int numberOfPages)
	{
		return await _context.Books.Where(b => b.PageCount > numberOfPages).ToListAsync();
	}

	public async Task<IEnumerable<Book?>> GetBooksWithLessPagesThanAsync(int numberOfPages)
	{
		return await _context.Books.Where(b => b.PageCount < numberOfPages).ToListAsync();
	}

	public async Task<Book?> UpdateBookAsync(Book book)
	{
		var dbBook = await _context.Books.FindAsync(book.Id);

		if (dbBook != null)
		{
			dbBook.Id = book.Id;
			dbBook.ISBN = book.ISBN;
			dbBook.Title = book.Title;
			dbBook.Author = book.Author;
			dbBook.Publisher = book.Publisher;
			dbBook.PageCount = book.PageCount;
		}

		await _context.SaveChangesAsync();
		return dbBook;
	}

	public async Task DeleteBookAsync(int id)
	{
		var book = await _context.Books.FindAsync(id);
		if (book != null)
		{
			_context.Books.Remove(book);
			await _context.SaveChangesAsync();
		}
	}

	public async Task DeleteBookByIsbnAsync(string isbn)
	{
		var book = await _context.Books.FirstOrDefaultAsync(b => b.ISBN == isbn);
		if (book != null)
		{
			_context.Books.Remove(book);
			await _context.SaveChangesAsync();
		}
	}*/
}
