using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using LibraryManager.Core.Services.AuthorService;
using LibraryManager.Core.Validators;
using LibraryManager.Core.Validators.AuthorValidator;

namespace LibraryManager.Core.Tests.ServiceTests;

[TestFixture]
public class AuthorServiceTests
{
	private IAuthorService _authorService;
	private LibraryContext _context;
	private Mock<AuthorValidator> _mockAuthorValidator;

	[SetUp]
	public void Setup()
	{
		_context = new LibraryContext(new DbConnectionConfig { ProviderName = "Test" });
		_mockAuthorValidator = new Mock<AuthorValidator>();
		_authorService = new AuthorService(_context, _mockAuthorValidator.Object);
	}

	[Test]
	public async Task InsertOrIgnoreAuthorAsync_AddsAuthor_WhenAuthorDoesNotExist()
	{
		// Arrange
		var author = new Author { Name = "Test Author" };
		_mockAuthorValidator.Setup(x => x.Validate(author))
			.Returns(new ValidationResult { IsValid = true });

		// Act
		await _authorService.InsertOrIgnoreAuthorAsync(author);

		// Assert
		_mockAuthorValidator.Verify(x => x.Validate(author), Times.Once);
	}

	[Test]
	public async Task InsertOrIgnoreAuthorAsync_DoesNotAddAuthor_WhenAuthorExists()
	{
		// Arrange
		var author = new Author { Name = "Test Author" };
		_mockAuthorValidator.Setup(x => x.Validate(author))
			.Returns(new ValidationResult { IsValid = true });
		await _authorService.InsertOrIgnoreAuthorAsync(author);

		// Act
		var result = await _authorService.InsertOrIgnoreAuthorAsync(author);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Author already exists"));
		});
	}
		
	[Test]
	public async Task InsertOrIgnoreAuthorAsync_ReturnsFailure_WhenValidationFails()
	{
		// Arrange
		var author = new Author { Name = "Invalid Author" };
		_mockAuthorValidator.Setup(x => x.Validate(author))
			.Returns(new ValidationResult { IsValid = false });

		// Act
		var result = await _authorService.InsertOrIgnoreAuthorAsync(author);

		// Assert
		Assert.That(result.Success, Is.False);
	}

	[Test]
	public async Task UpdateAuthorAsync_ReturnsFailure_WhenAuthorDoesNotExist()
	{
		
		// Arrange
		var author = new Author { Id = 1, Name = "Nonexistent Author" };
		_mockAuthorValidator.Setup(x => x.Validate(author))
			.Returns(new ValidationResult { IsValid = true });

		// Act
		var result = await _authorService.UpdateAuthorAsync(author);

		// Assert
		Assert.That(result.Success, Is.False);
	}

	[Test]
	public async Task UpdateAuthorAsync_ReturnsFailure_WhenValidationFails()
	{
		// Arrange
		var author = new Author { Id = 1, Name = "Invalid Author" };
		_mockAuthorValidator.Setup(x => x.Validate(author))
			.Returns(new ValidationResult { IsValid = false });

		// Act
		var result = await _authorService.UpdateAuthorAsync(author);

		// Assert
		Assert.That(result.Success, Is.False);
	}
		
	[Test]
	public async Task InsertOrIgnoreAuthorAsync_ReturnsSuccess_WhenAuthorIsValidAndDoesNotExist()
	{
		// Arrange
		var author = new Author { Name = "Valid Author" };
		_mockAuthorValidator.Setup(x => x.Validate(author))
			.Returns(new ValidationResult { IsValid = true });

		// Act
		var result = await _authorService.InsertOrIgnoreAuthorAsync(author);

		// Assert
		Assert.That(result.Success, Is.True);
	}

	[Test]
	public async Task UpdateAuthorAsync_ReturnsSuccess_WhenAuthorIsValidAndExists()
	{
		// Arrange
		var authorToInsert = new Author { Name = "Existing Author" };
		_mockAuthorValidator.Setup(x => x.Validate(authorToInsert))
			.Returns(new ValidationResult { IsValid = true });
		await _authorService.InsertOrIgnoreAuthorAsync(authorToInsert);

		var authorToUpdate = new Author { Id = authorToInsert.Id, Name = "Updated Author" };
		_mockAuthorValidator.Setup(x => x.Validate(authorToUpdate))
			.Returns(new ValidationResult { IsValid = true });

		// Act
		var result = await _authorService.UpdateAuthorAsync(authorToUpdate);

		// Assert
		Assert.That(result.Success, Is.True);
	}

	[Test]
	public async Task InsertOrIgnoreAuthorAsync_ReturnsFailure_WhenAuthorExists()
	{
		// Arrange
		var author = new Author { Name = "Existing Author" };
		_mockAuthorValidator.Setup(x => x.Validate(author))
			.Returns(new ValidationResult { IsValid = true });
		await _authorService.InsertOrIgnoreAuthorAsync(author);

		// Act
		var result = await _authorService.InsertOrIgnoreAuthorAsync(author);

		// Assert
		Assert.That(result.Success, Is.False);
	}

	[Test]
	public async Task InsertOrIgnoreAuthorAsync_ReturnsFailure_WhenAuthorIsNull()
	{
		// Arrange
		Author author = null;
		_mockAuthorValidator.Setup(x => x.Validate(author))
			.Returns(new ValidationResult { IsValid = false });

		// Act
		var result = await _authorService.InsertOrIgnoreAuthorAsync(author);

		// Assert
		Assert.That(result.Success, Is.False);
	}

	[Test]
	public async Task UpdateAuthorAsync_ReturnsFailure_WhenAuthorIsNull()
	{
		
		// Arrange
		Author author = null;
		_mockAuthorValidator.Setup(x => x.Validate(author))
			.Returns(new ValidationResult { IsValid = false });

		// Act
		var result = await _authorService.UpdateAuthorAsync(author);

		// Assert
		Assert.That(result.Success, Is.False);
	}

	[Test]
	public async Task InsertOrIgnoreAuthorAsync_ReturnsFailure_WhenAuthorNameIsEmpty()
	{
		// Arrange
		var author = new Author { Name = string.Empty };
		_mockAuthorValidator.Setup(x => x.Validate(author))
			.Returns(new ValidationResult { IsValid = false });

		// Act
		var result = await _authorService.InsertOrIgnoreAuthorAsync(author);

		// Assert
		Assert.That(result.Success, Is.False);
	}

	[Test]
	public async Task UpdateAuthorAsync_ReturnsFailure_WhenAuthorNameIsEmpty()
	{
		
		// Arrange
		var author = new Author { Id = 1, Name = string.Empty };
		_mockAuthorValidator.Setup(x => x.Validate(author))
			.Returns(new ValidationResult { IsValid = false });

		// Act
		var result = await _authorService.UpdateAuthorAsync(author);

		// Assert
		Assert.That(result.Success, Is.False);
	}
		
	[Test]
	public async Task UpdateAuthorAsync_ReturnsFailure_WhenAuthorNameIsWhitespace()
	{
		// Arrange
		var author = new Author { Id = 1, Name = " " };
		_mockAuthorValidator.Setup(x => x.Validate(author))
			.Returns(new ValidationResult { IsValid = false });

		// Act
		var result = await _authorService.UpdateAuthorAsync(author);

		// Assert
		Assert.That(result.Success, Is.False);
	}

	[Test]
	public async Task InsertOrIgnoreAuthorAsync_ReturnsFailure_WhenAuthorNameIsWhitespace()
	{
		// Arrange
		var author = new Author { Name = " " };
		_mockAuthorValidator.Setup(x => x.Validate(author))
			.Returns(new ValidationResult { IsValid = false });

		// Act
		var result = await _authorService.InsertOrIgnoreAuthorAsync(author);

		// Assert
		Assert.That(result.Success, Is.False);
	}

	[Test]
	public async Task UpdateAuthorAsync_ReturnsFailure_WhenAuthorIdIsZero()
	{
		// Arrange
		var author = new Author { Id = 0, Name = "Valid Name" };
		_mockAuthorValidator.Setup(x => x.Validate(author))
			.Returns(new ValidationResult { IsValid = false });

		// Act
		var result = await _authorService.UpdateAuthorAsync(author);

		// Assert
		Assert.That(result.Success, Is.False);
	}
}