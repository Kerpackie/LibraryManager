using LibraryManager.Core.Models;

namespace LibraryManager.Core.Validators.AuthorValidator;

public class AuthorValidator : BaseValidator<Author>, IAuthorValidator
{

	protected override ValidationResult ValidateEntity(Author author)
	{
		var validationResult = new ValidationResult { IsValid = true };

		if (string.IsNullOrWhiteSpace(author.Name))
		{
			validationResult.IsValid = false;
			validationResult.Errors.Add("Author name cannot be null or empty");
		}

		if (string.IsNullOrEmpty(author.Name))
		{
			validationResult.IsValid = false;
			validationResult.Errors.Add("Author name cannot be null or empty");
		}

		if (author.Name is {Length: > 100})
		{
			validationResult.IsValid = false;
			validationResult.Errors.Add("Author name is too long");
		}

		return validationResult;
	}
}