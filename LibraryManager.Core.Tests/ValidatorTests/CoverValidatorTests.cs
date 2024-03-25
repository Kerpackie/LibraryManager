using LibraryManager.Core.Models;
using LibraryManager.Core.Validators.CoverValidator;

namespace LibraryManager.Core.Tests.ValidatorTests;

[TestFixture]
public class CoverValidatorTests
{
	private ICoverValidator _validator;

	[SetUp]
	public void SetUp()
	{
		_validator = new CoverValidator();
	}
	
	[Test]
	public void Validate_ReturnsIsValidTrue_WhenCoverIsValid()
	{
		// Arrange
		var cover = new Cover { 
			Id = 1, 
			Small = "http://validurl.com/small.jpg", 
			Medium = "http://validurl.com/medium.jpg", 
			Large = "http://validurl.com/large.jpg"};

		// Act
		var result = _validator.Validate(cover);

		// Assert
		Assert.That(result.IsValid, Is.True);
	}

	[Test]
	public void Validate_ReturnsIsValidFalse_WhenCoverIsNull()
	{
		// Arrange
		Cover cover = null;

		// Act
		var result = _validator.Validate(cover);

		// Assert
		Assert.That(result.IsValid, Is.False);
	}

	[Test]
	public void Validate_ReturnsIsValidFalse_WhenCoverSmallIsNull()
	{
		// Arrange
		var cover = new Cover { 
			Id = 1, 
			Small = null, 
			Medium = "http://validurl.com/medium.jpg", 
			Large = "http://validurl.com/large.jpg"};

		// Act
		var result = _validator.Validate(cover);

		// Assert
		Assert.That(result.IsValid, Is.False);
	}
	
	[Test]
	public void Validate_ReturnsIsValidFalse_WhenCoverSmallIsEmpty()
	{
		// Arrange
		var cover = new Cover { 
			Id = 1, 
			Small = string.Empty, 
			Medium = "http://validurl.com/medium.jpg", 
			Large = "http://validurl.com/large.jpg"};

		// Act
		var result = _validator.Validate(cover);

		// Assert
		Assert.That(result.IsValid, Is.False);
	}
	
	[Test]
	public void Validate_ReturnsIsValidFalse_WhenCoverSmallIsWhitespace()
	{
		// Arrange
		var cover = new Cover { 
			Id = 1, 
			Small = " ", 
			Medium = "http://validurl.com/medium.jpg", 
			Large = "http://validurl.com/large.jpg"};

		// Act
		var result = _validator.Validate(cover);

		// Assert
		Assert.That(result.IsValid, Is.False);
	}
	
	[Test]
	public void Validate_ReturnsIsValidFalse_WhenCoverSmallIsInvalidUrl()
	{
		// Arrange
		var cover = new Cover { 
			Id = 1, 
			Small = "invalidurl", 
			Medium = "http://validurl.com/medium.jpg", 
			Large = "http://validurl.com/large.jpg"};

		// Act
		var result = _validator.Validate(cover);

		// Assert
		Assert.That(result.IsValid, Is.False);
	}
	
	[Test]
	public void Validate_ReturnsIsValidFalse_WhenCoverMediumIsNull()
	{
		// Arrange
		var cover = new Cover { 
			Id = 1, 
			Small = "http://validurl.com/small.jpg", 
			Medium = null, 
			Large = "http://validurl.com/large.jpg"};

		// Act
		var result = _validator.Validate(cover);

		// Assert
		Assert.That(result.IsValid, Is.False);
	}
	
	[Test]
	public void Validate_ReturnsIsValidFalse_WhenCoverMediumIsEmpty()
	{
		// Arrange
		var cover = new Cover { 
			Id = 1, 
			Small = "http://validurl.com/small.jpg", 
			Medium = string.Empty, 
			Large = "http://validurl.com/large.jpg"};

		// Act
		var result = _validator.Validate(cover);

		// Assert
		Assert.That(result.IsValid, Is.False);
	}
	
	[Test]
	public void Validate_ReturnsIsValidFalse_WhenCoverMediumIsWhitespace()
	{
		// Arrange
		var cover = new Cover { 
			Id = 1, 
			Small = "http://validurl.com/small.jpg", 
			Medium = " ", 
			Large = "http://validurl.com/large.jpg"};

		// Act
		var result = _validator.Validate(cover);

		// Assert
		Assert.That(result.IsValid, Is.False);
	}
	
	[Test]
	public void Validate_ReturnsIsValidFalse_WhenCoverMediumIsInvalidUrl()
	{
		// Arrange
		var cover = new Cover { 
			Id = 1, 
			Small = "http://validurl.com/small.jpg", 
			Medium = "invalidurl", 
			Large = "http://validurl.com/large.jpg"};

		// Act
		var result = _validator.Validate(cover);

		// Assert
		Assert.That(result.IsValid, Is.False);
	}
	
	[Test]
	public void Validate_ReturnsIsValidFalse_WhenCoverLargeIsNull()
	{
		// Arrange
		var cover = new Cover { 
			Id = 1, 
			Small = "http://validurl.com/small.jpg", 
			Medium = "http://validurl.com/medium.jpg", 
			Large = null};

		// Act
		var result = _validator.Validate(cover);

		// Assert
		Assert.That(result.IsValid, Is.False);
	}
	
	[Test]
	public void Validate_ReturnsIsValidFalse_WhenCoverLargeIsEmpty()
	{
		// Arrange
		var cover = new Cover { 
			Id = 1, 
			Small = "http://validurl.com/small.jpg", 
			Medium = "http://validurl.com/medium.jpg", 
			Large = string.Empty};

		// Act
		var result = _validator.Validate(cover);

		// Assert
		Assert.That(result.IsValid, Is.False);
	}
	
	[Test]
	public void Validate_ReturnsIsValidFalse_WhenCoverLargeIsWhitespace()
	{
		// Arrange
		var cover = new Cover { 
			Id = 1, 
			Small = "http://validurl.com/small.jpg", 
			Medium = "http://validurl.com/medium.jpg", 
			Large = " "};

		// Act
		var result = _validator.Validate(cover);

		// Assert
		Assert.That(result.IsValid, Is.False);
	}
	
	[Test]
	public void Validate_ReturnsIsValidFalse_WhenCoverLargeIsInvalidUrl()
	{
		// Arrange
		var cover = new Cover { 
			Id = 1, 
			Small = "http://validurl.com/small.jpg", 
			Medium = "http://validurl.com/medium.jpg", 
			Large = "invalidurl"};

		// Act
		var result = _validator.Validate(cover);

		// Assert
		Assert.That(result.IsValid, Is.False);
	}
	
}