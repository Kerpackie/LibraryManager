using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using LibraryManager.Core.Services.AuthorService;
using LibraryManager.Core.Services.PublisherService;
using LibraryManager.Core.Validators;
using LibraryManager.Core.Validators.AuthorValidator;
using LibraryManager.Core.Validators.PublisherValidator;

namespace LibraryManager.Core.Tests.ServiceTests;

[TestFixture]
public class PublisherServiceTests
{
	private IPublisherService _publisherService;
	private LibraryContext _context;
	private Mock<PublisherValidator> _mockPublisherValidator;

	[SetUp]
	public void Setup()
	{
		_context = new LibraryContext(new DbConnectionConfig {ProviderName = "Test"});
		_mockPublisherValidator = new Mock<PublisherValidator>();
		_publisherService = new PublisherService(_context, _mockPublisherValidator.Object);
	}

	[Test]
	public async Task AddPublisher_ReturnsSuccess_WhenPublisherIsValid()
	{
		// Arrange
		var validPublisher = new Publisher {Name = "Valid Publisher"};
		_mockPublisherValidator.Setup(x => x.Validate(validPublisher))
			.Returns(new ValidationResult {IsValid = true});
		_context.Publishers.Add(validPublisher);
		await _context.SaveChangesAsync();

		// Act
		var result = await _publisherService.InsertOrIgnorePublisherAsync(validPublisher);

		// Assert
		Assert.That(result, Is.Not.Null);
		Assert.That(result.Data.Name, Is.EqualTo(validPublisher.Name));
	}

	[Test]
	public async Task GetPublisher_ReturnsPublisher_WhenPublisherExists()
	{
	    // Arrange
	    var existingPublisher = new Publisher { Name = "Existing Publisher" };
	    _context.Publishers.Add(existingPublisher);
	    await _context.SaveChangesAsync();

	    // Act
	    var result = await _publisherService.GetPublisherByNameAsync(existingPublisher.Name);

	    // Assert
	    Assert.That(result, Is.Not.Null);
	    Assert.That(result.Data.Name, Is.EqualTo(existingPublisher.Name));
	}

	[Test]
	public async Task GetPublisher_ReturnsNull_WhenPublisherDoesNotExist()
	{
	    // Arrange
	    var nonExistingPublisherName = "Non Existing Publisher";

	    // Act
	    var result = await _publisherService.GetPublisherByNameAsync(nonExistingPublisherName);

	    // Assert
	    Assert.That(result.Data, Is.Null);
	}
	
	[Test]
	public async Task UpdatePublisher_ReturnsUpdatedPublisher_WhenUpdateIsSuccessful()
	{
		// Arrange
		var existingPublisher = new Publisher { Name = "Existing Publisher" };
		_context.Publishers.Add(existingPublisher);
		await _context.SaveChangesAsync();

		var updatedPublisher = new Publisher { Id = 1, Name = "Updated Publisher" };
		_mockPublisherValidator.Setup(x => x.Validate(updatedPublisher))
			.Returns(new ValidationResult { IsValid = true });

		// Act
		var result = await _publisherService.UpdatePublisherAsync(updatedPublisher);

		// Assert
		Assert.That(result, Is.Not.Null);
		Assert.That(result.Data, Is.Not.Null);
		Assert.That(result.Data.Name, Is.EqualTo(updatedPublisher.Name));
	}

	[Test]
	public async Task DeletePublisher_ReturnsTrue_WhenDeletionIsSuccessful()
	{
	    // Arrange
	    var existingPublisher = new Publisher { Name = "Existing Publisher" };
	    _context.Publishers.Add(existingPublisher);
	    await _context.SaveChangesAsync();

	    // Act
	    var result = await _publisherService.DeletePublisherAsync(existingPublisher.Name);

	    // Assert
	    Assert.That(result.Data, Is.True);
	}

	[Test]
	public async Task DeletePublisher_ReturnsFalse_WhenPublisherDoesNotExist()
	{
	    // Arrange
	    var nonExistingPublisherName = "Non Existing Publisher";

	    // Act
	    var result = await _publisherService.DeletePublisherAsync(nonExistingPublisherName);

	    // Assert
	    Assert.That(result.Data, Is.False);
	}
	
	[Test]
	public async Task InsertOrIgnorePublisherAsync_ReturnsFailure_WhenPublisherExists()
	{
		// Arrange
	    var publisher = new Publisher { Name = "Existing Publisher" };
	    _mockPublisherValidator.Setup(x => x.Validate(publisher))
	        .Returns(new ValidationResult { IsValid = true });
	    await _publisherService.InsertOrIgnorePublisherAsync(publisher);

	    // Act
	    var result = await _publisherService.InsertOrIgnorePublisherAsync(publisher);
	    
	    // Assert
	    Assert.That(result.Success, Is.False);
	}

	[Test]
	public async Task InsertOrIgnorePublisherAsync_ReturnsFailure_WhenPublisherIsNull()
	{
		// Arrange
	    Publisher publisher = null;
	    _mockPublisherValidator.Setup(x => x.Validate(publisher))
	        .Returns(new ValidationResult { IsValid = false });

	    // Act
	    var result = await _publisherService.InsertOrIgnorePublisherAsync(publisher);

	    // Assert
	    Assert.That(result.Success, Is.False);
	}

	[Test]
	public async Task UpdatePublisherAsync_ReturnsFailure_WhenPublisherIsNull()
	{
		// Arrange
	    Publisher publisher = null;
	    _mockPublisherValidator.Setup(x => x.Validate(publisher))
	        .Returns(new ValidationResult { IsValid = false });

	    // Act
	    var result = await _publisherService.UpdatePublisherAsync(publisher);

	    // Assert
	    Assert.That(result.Success, Is.False);
	}

	[Test]
	public async Task InsertOrIgnorePublisherAsync_ReturnsFailure_WhenPublisherNameIsEmpty()
	{
		// Arrange
	    var publisher = new Publisher { Name = string.Empty };
	    _mockPublisherValidator.Setup(x => x.Validate(publisher))
	        .Returns(new ValidationResult { IsValid = false });

	    // Act
	    var result = await _publisherService.InsertOrIgnorePublisherAsync(publisher);

	    // Assert
	    Assert.That(result.Success, Is.False);
	}

	[Test]
	public async Task UpdatePublisherAsync_ReturnsFailure_WhenPublisherNameIsEmpty()
	{
		
		// Arrange
	    var publisher = new Publisher { Id = 1, Name = string.Empty };
	    _mockPublisherValidator.Setup(x => x.Validate(publisher))
	        .Returns(new ValidationResult { IsValid = false });

	    // Act
	    var result = await _publisherService.UpdatePublisherAsync(publisher);

	    // Assert
	    Assert.That(result.Success, Is.False);
	}

	[Test]
	public async Task UpdatePublisherAsync_ReturnsFailure_WhenPublisherNameIsWhitespace()
	{
		// Arrange
	    var publisher = new Publisher { Id = 1, Name = " " };
	    _mockPublisherValidator.Setup(x => x.Validate(publisher))
	        .Returns(new ValidationResult { IsValid = false });

	    // Act
	    var result = await _publisherService.UpdatePublisherAsync(publisher);

	    // Assert
	    Assert.That(result.Success, Is.False);
	}

	[Test]
	public async Task InsertOrIgnorePublisherAsync_ReturnsFailure_WhenPublisherNameIsWhitespace()
	{
		// Arrange
	    var publisher = new Publisher { Name = " " };
	    _mockPublisherValidator.Setup(x => x.Validate(publisher))
	        .Returns(new ValidationResult { IsValid = false });

	    // Act
	    var result = await _publisherService.InsertOrIgnorePublisherAsync(publisher);

	    // Assert
	    Assert.That(result.Success, Is.False);
	}

	[Test]
	public async Task UpdatePublisherAsync_ReturnsFailure_WhenPublisherIdIsZero()
	{
		// Arrange
	    var publisher = new Publisher { Id = 0, Name = "Valid Name" };
	    _mockPublisherValidator.Setup(x => x.Validate(publisher))
	        .Returns(new ValidationResult { IsValid = false });

	    // Act
	    var result = await _publisherService.UpdatePublisherAsync(publisher);

	    // Assert
	    Assert.That(result.Success, Is.False);
	}
}