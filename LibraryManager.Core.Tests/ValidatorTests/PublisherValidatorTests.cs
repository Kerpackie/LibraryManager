using LibraryManager.Core.Models;
using LibraryManager.Core.Validators.PublisherValidator;

namespace LibraryManager.Core.Tests.ValidatorTests;

public class PublisherValidatorTests
{
	private IPublisherValidator _validator;

	[SetUp]
	public void SetUp()
	{
		_validator = new PublisherValidator();
	}

	[Test]
	public void Validate_ReturnsIsValidTrue_WhenNameIsValid()
	{
		var publisher = new Publisher { Name = "Valid Name" };

		var result = _validator.Validate(publisher);

		Assert.That(result.IsValid, Is.True);
	}

	[Test]
	public void Validate_ReturnsIsValidFalse_WhenNameIsNull()
	{
		var publisher = new Publisher { Name = null };

		var result = _validator.Validate(publisher);

		Assert.That(result.IsValid, Is.False);
	}

	[Test]
	public void Validate_ReturnsIsValidFalse_WhenNameIsEmpty()
	{
		var publisher = new Publisher { Name = string.Empty };

		var result = _validator.Validate(publisher);

		Assert.That(result.IsValid, Is.False);
	}

	[Test]
	public void Validate_ReturnsIsValidFalse_WhenNameIsWhitespace()
	{
		var publisher = new Publisher { Name = " " };

		var result = _validator.Validate(publisher);

		Assert.That(result.IsValid, Is.False);
	}
	
	[Test]
	public void Validate_ReturnsIsValidFalse_WhenNameIsTooLong()
	{
		var publisher = new Publisher { Name = new string('a', 101) };

		var result = _validator.Validate(publisher);

		Assert.That(result.IsValid, Is.False);
	}
	
	[Test]
	public void Validate_ReturnsIsValidFalse_WhenPublisherIsNull()
	{
		Publisher publisher = null;

		var result = _validator.Validate(publisher);

		Assert.That(result.IsValid, Is.False);
	}
}