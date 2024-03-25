using LibraryManager.Core.Models;
using LibraryManager.Core.Validators.SubjectValidator;
using NUnit.Framework;

namespace LibraryManager.Core.Tests.ValidatorTests;

public class SubjectValidatorTests
{
	private ISubjectValidator _validator;

	[SetUp]
	public void SetUp()
	{
		_validator = new SubjectValidator();
	}
	
	[Test]
	public void Validate_RetusnIsValidFalse_WhenSubjectIsNull()
	{
		var result = _validator.Validate(null);

		Assert.That(result.IsValid, Is.False);
	}

	[Test]
	public void Validate_ReturnsIsValidTrue_WhenNameIsValid()
	{
		var subject = new Subject { Name = "Valid Name" };

		var result = _validator.Validate(subject);

		Assert.That(result.IsValid, Is.True);
	}

	[Test]
	public void Validate_ReturnsIsValidFalse_WhenNameIsNull()
	{
		var subject = new Subject { Name = null };

		var result = _validator.Validate(subject);

		Assert.That(result.IsValid, Is.False);
	}

	[Test]
	public void Validate_ReturnsIsValidFalse_WhenNameIsEmpty()
	{
		var subject = new Subject { Name = string.Empty };

		var result = _validator.Validate(subject);

		Assert.That(result.IsValid, Is.False);
	}

	[Test]
	public void Validate_ReturnsIsValidFalse_WhenNameIsWhitespace()
	{
		var subject = new Subject { Name = " " };

		var result = _validator.Validate(subject);

		Assert.That(result.IsValid, Is.False);
	}

	[Test]
	public void Validate_ReturnsIsValidFalse_WhenNameIsTooLong()
	{
		var subject = new Subject { Name = new string('a', 101) };

		var result = _validator.Validate(subject);

		Assert.That(result.IsValid, Is.False);
	}
}