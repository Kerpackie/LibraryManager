using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using LibraryManager.Core.Services.LoanService;

namespace LibraryManager.Core.Tests.ServiceTests;

[TestFixture]
public class LoanServiceTests
{
	private ILoanService _noteService;
	private LibraryContext _context;
	
	[SetUp]
	public void Setup()
	{
		_context = new LibraryContext(new DbConnectionConfig { ProviderName = "SQLiteTest", ConnectionString = "DataSource=test.db"});
		_context.Database.EnsureCreated();
		_noteService = new LoanService(_context);
	}
	
	[TearDown]
	public void TearDown()
	{
		_context.Database.EnsureDeleted();
		_context.Dispose();
	}
	
	[Test]
	public async Task CreateLoanAsync_AddsLoan_WhenLoanDoesntExist()
	{
		// Arrange
		var book = await CreateTestBookAsync(1, "Book Title", false, 1, 1);

		var loan = new Loan
		{
			Id = 1,
			Borrower = "Test Borrower",
			Books = new List<Book>
			{
				book
			},
			IsReturned = false,
			LoanDate = DateTime.Today,
		};

		// Act
		var result = await _noteService.CreateLoanAsync(loan);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success);
			Assert.That(result.Data, Is.EqualTo(loan));
		});
	}
	
	[Test]
	public async Task CreateLoanAsync_ReturnsError_WhenBookIsAlreadyOnLoan()
	{
		// Arrange
		var book = await CreateTestBookAsync(1, "Test Book", true, 1, 1);
		
		var loan = new Loan
		{
			Id = 1,
			Borrower = "Test Borrower",
			Books = new List<Book>
			{
				book
			},
			IsReturned = false,
			LoanDate = DateTime.Today,
		};
		
		// Act
		var result = await _noteService.CreateLoanAsync(loan);
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Book is already on loan"));
		});
	}
	
	[Test]
	public async Task CreateLoanAsync_ReturnsError_WhenBookNotFound()
	{
		// Arrange
		var book = await CreateTestBookAsync(1, "Test Book", true, 1, 1);
		
		var loan = new Loan
		{
			Id = 1,
			Borrower = "Test Borrower",
			Books = new List<Book>
			{
				new () { Id = 2 }
			},
			IsReturned = false,
			LoanDate = DateTime.Today,
		};
		
		// Act
		var result = await _noteService.CreateLoanAsync(loan);
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Book not found"));
		});
	}
	
	[Test]
	public async Task GetLoanAsync_ReturnsLoan_WhenLoanExists()
	{
		// Arrange
		var book = await CreateTestBookAsync(1, "Test Book", true, 1, 1);
		
		var loan = new Loan
		{
			Id = 1,
			Borrower = "Test Borrower",
			Books = new List<Book>
			{
				book
			},
			IsReturned = false,
			LoanDate = DateTime.Today,
		};
		
		_context.Loans.Add(loan);
		await _context.SaveChangesAsync();
		
		// Act
		var result = await _noteService.GetLoanAsync(1);
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success);
			Assert.That(result.Data, Is.EqualTo(loan));
		});
	}
	
	[Test]
	public async Task GetLoanAsync_ReturnsError_WhenLoanNotFound()
	{
		// Arrange
		var book = await CreateTestBookAsync(1, "Test Book", true, 1, 1);
		
		var loan = new Loan
		{
			Id = 1,
			Borrower = "Test Borrower",
			Books = new List<Book>
			{
				book
			},
			IsReturned = false,
			LoanDate = DateTime.Today,
		};
		
		_context.Loans.Add(loan);
		await _context.SaveChangesAsync();
		
		// Act
		var result = await _noteService.GetLoanAsync(2);
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Loan not found"));
		});
	}
	
	[Test]
	public async Task GetLoanByBookIdAsync_ReturnsLoan_WhenLoanExists()
	{
		// Arrange
		var book = await CreateTestBookAsync(1, "Test Book", true, 1, 1);
		
		var loan = new Loan
		{
			Id = 1,
			Borrower = "Test Borrower",
			Books = new List<Book>
			{
				book
			},
			IsReturned = false,
			LoanDate = DateTime.Today,
		};
		_context.Loans.Add(loan);
		await _context.SaveChangesAsync();
		
		// Act
		var result = await _noteService.GetLoanByBookIdAsync(1);
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success);
			Assert.That(result.Data, Is.EqualTo(loan));
		});
	}
	
	[Test]
	public async Task GetLoanByBookIdAsync_ReturnsError_WhenLoanNotFound()
	{
		// Arrange
		var book = await CreateTestBookAsync(1, "Test Book", true, 1, 1);
		
		var loan = new Loan
		{
			Id = 1,
			Borrower = "Test Borrower",
			Books = new List<Book>
			{
				book
			},
			IsReturned = false,
			LoanDate = DateTime.Today,
		};
		_context.Loans.Add(loan);
		await _context.SaveChangesAsync();
		
		// Act
		var result = await _noteService.GetLoanByBookIdAsync(2);
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Loan not found"));
		});
	}
	
	[Test]
	public async Task GetLoanByBookIdAsync_ReturnsError_WhenBookNotFound()
	{
		// Arrange
		var book = await CreateTestBookAsync(1, "Test Book", true, 1, 1);
		
		var loan = new Loan
		{
			Id = 1,
			Borrower = "Test Borrower",
			Books = new List<Book>
			{
				book
			},
			IsReturned = false,
			LoanDate = DateTime.Today,
		};
		
		_context.Loans.Add(loan);
		await _context.SaveChangesAsync();
		
		// Act
		var result = await _noteService.GetLoanByBookIdAsync(3);
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Loan not found"));
		});
	}
	
	[Test]
	public async Task UpdateLoanAsync_UpdatesLoan_WhenLoanExists()
	{
		// Arrange
		var book = await CreateTestBookAsync(1, "Test Book", true, 1, 1);
		
		var loan = new Loan
		{
			Id = 1,
			Borrower = "Test Borrower",
			Books = new List<Book>
			{
				book
			},
			IsReturned = false,
			LoanDate = DateTime.Today,
		};
		
		_context.Loans.Add(loan);
		await _context.SaveChangesAsync();
		
		// Act
		loan.Borrower = "Test";
		var result = await _noteService.UpdateLoanAsync(loan);
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success);
			Assert.That(result.Data, Is.EqualTo(loan));
		});
	}
	
	[Test]
	public async Task UpdateLoanAsync_ReturnsError_WhenLoanNotFound()
	{
		// Arrange
		var book = await CreateTestBookAsync(1, "Test Book", true, 1, 1);
		
		var loan = new Loan
		{
			Id = 1,
			Borrower = "Test Borrower",
			Books = new List<Book>
			{
				book
			},
			IsReturned = false,
			LoanDate = DateTime.Today,
		};
		
		_context.Loans.Add(loan);
		await _context.SaveChangesAsync();
		
		// Act
		loan.Id = 2;
		var result = await _noteService.UpdateLoanAsync(loan);
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Loan not found"));
		});
	}
	
	[Test]
	public async Task DeleteLoanAsync_DeletesLoan_WhenLoanExists()
	{
		// Arrange
		var book = await CreateTestBookAsync(1, "Test Book", true, 1, 1);
		
		var loan = new Loan
		{
			Id = 1,
			Borrower = "Test Borrower",
			Books = new List<Book>
			{
				book
			},
			IsReturned = false,
			LoanDate = DateTime.Today,
		};
		
		_context.Loans.Add(loan);
		await _context.SaveChangesAsync();
		
		// Act
		var result = await _noteService.DeleteLoanAsync(1);
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success);
			Assert.That(result.Data, Is.EqualTo(loan));
		});
	}
	
	[Test]
	public async Task DeleteLoanAsync_ReturnsError_WhenLoanNotFound()
	{
		// Arrange
		var book = await CreateTestBookAsync(1, "Test Book", true, 1, 1);
		
		var loan = new Loan
		{
			Id = 1,
			Borrower = "Test Borrower",
			Books = new List<Book>
			{
				book
			},
			IsReturned = false,
			LoanDate = DateTime.Today,
		};
		
		_context.Loans.Add(loan);
		await _context.SaveChangesAsync();
		
		// Act
		var result = await _noteService.DeleteLoanAsync(2);
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Loan not found"));
		});
	}
	
	[Test]
	public async Task ReturnLoanAsync_ReturnsError_WhenLoanNotFound()
	{
		// Arrange
		var book = await CreateTestBookAsync(1, "Test Book", true, 1, 1);
		
		var loan = new Loan
		{
			Id = 1,
			Borrower = "Test Borrower",
			Books = new List<Book>
			{
				book
			},
			IsReturned = false,
			LoanDate = DateTime.Today,
		};
		
		_context.Loans.Add(loan);
		await _context.SaveChangesAsync();
		
		// Act
		var result = await _noteService.ReturnLoanAsync(2);
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Loan not found"));
		});
	}
	
	[Test]
	public async Task ReturnLoanAsync_ReturnsError_WhenLoanIsAlreadyReturned()
	{
		// Arrange
		var book = await CreateTestBookAsync(1, "Test Book", false, 1, 1);
		
		var loan = new Loan
		{
			Id = 1,
			Borrower = "Test Borrower",
			Books = new List<Book>
			{
				book
			},
			IsReturned = true,
			LoanDate = DateTime.Today,
		};
		
		_context.Loans.Add(loan);
		await _context.SaveChangesAsync();
		
		// Act
		var result = await _noteService.ReturnLoanAsync(1);
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Book is not on loan"));
		});
	}
	
	[Test]
	public async Task ReturnLoanAsync_ReturnsError_WhenBookIsNotOnLoan()
	{
		// Arrange
		var book = await CreateTestBookAsync(1, "Test Book", false, 1, 1);
		
		var loan = new Loan
		{
			Id = 1,
			Borrower = "Test Borrower",
			Books = new List<Book>
			{
				book
			},
			IsReturned = true,
			LoanDate = DateTime.Today,
		};
		
		_context.Loans.Add(loan);
		await _context.SaveChangesAsync();
		
		// Act
		var result = await _noteService.ReturnLoanAsync(1);
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Book is not on loan"));
		});
	}
	
	[Test]
	public async Task ReturnLoanAsync_ReturnsError_WhenBookIsAlreadyReturned()
	{
		// Arrange
		var book = await CreateTestBookAsync(1, "Test Book", false, 1, 1);
		
		var loan = new Loan
		{
			Id = 1,
			Borrower = "Test Borrower",
			Books = new List<Book>
			{
				book
			},
			IsReturned = true,
			LoanDate = DateTime.Today,
		};
		_context.Loans.Add(loan);
		await _context.SaveChangesAsync();
		
		// Act
		var result = await _noteService.ReturnLoanAsync(1);
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Book is not on loan"));
		});
	}
	
	private async Task<Book> CreateTestBookAsync(int id, string title, bool loaned, int coverId, int authorId)
	{
		var cover = new Cover
		{
			Id = coverId,
		};

		_context.Covers.Add(cover);
		await _context.SaveChangesAsync();

		var author = new Author
		{
			Id = authorId,
			Name = "Test Author",
		};

		_context.Authors.Add(author);
		await _context.SaveChangesAsync();

		var book = new Book
		{
			Id = id,
			Title = title,
			Loaned = loaned,
			CoverId = coverId,
			AuthorId = authorId,
		};

		_context.Books.Add(book);
		await _context.SaveChangesAsync();

		return book;
	}
}