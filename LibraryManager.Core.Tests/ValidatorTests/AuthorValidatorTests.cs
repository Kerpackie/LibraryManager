using LibraryManager.Core.Models;
using NUnit.Framework;
using LibraryManager.Core.Validators;
using LibraryManager.Core.Validators.AuthorValidator;

namespace LibraryManager.Core.Tests.ValidatorTests
{
	public class AuthorValidatorTests
	{
		private IAuthorValidator _validator;

		[SetUp]
		public void SetUp()
		{
			_validator = new AuthorValidator();
		}

		[Test]
		public void Validate_ReturnsIsValidTrue_WhenNameIsValid()
		{
			var author = new Author { Name = "Valid Name" };

			var result = _validator.Validate(author);

			Assert.That(result.IsValid, Is.True);
		}

		[Test]
		public void Validate_ReturnsIsValidFalse_WhenNameIsNull()
		{
			var author = new Author { Name = null };

			var result = _validator.Validate(author);

			Assert.That(result.IsValid, Is.False);
		}

		[Test]
		public void Validate_ReturnsIsValidFalse_WhenNameIsEmpty()
		{
			var author = new Author { Name = string.Empty };

			var result = _validator.Validate(author);

			Assert.That(result.IsValid, Is.False);
		}

		[Test]
		public void Validate_ReturnsIsValidFalse_WhenNameIsWhitespace()
		{
			var author = new Author { Name = " " };

			var result = _validator.Validate(author);

			Assert.That(result.IsValid, Is.False);
		}
		
		[Test]
		public void Validate_ReturnsIsValidFalse_WhenNameIsTooLong()
		{
			var author = new Author { Name = new string('a', 101) };

			var result = _validator.Validate(author);

			Assert.That(result.IsValid, Is.False);
		}
		
	}
}