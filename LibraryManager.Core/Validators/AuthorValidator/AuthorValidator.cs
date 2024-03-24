using LibraryManager.Core.Models;

namespace LibraryManager.Core.Validators.AuthorValidator;

public class AuthorValidator : IAuthorValidator
{
	public virtual ValidationResult Validate(Author author)
	{
		var result = new ValidationResult { IsValid = true };

		if (author == null)
		{
			result.IsValid = false;
			result.Errors.Add("Author is null");
			return result;
		}

		if (string.IsNullOrWhiteSpace(author.Name))
		{
			result.IsValid = false;
			result.Errors.Add("Author name is null or empty");
		}

		return result;
	}
}
