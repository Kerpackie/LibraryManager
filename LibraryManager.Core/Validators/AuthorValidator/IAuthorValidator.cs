using LibraryManager.Core.Models;

namespace LibraryManager.Core.Validators.AuthorValidator;

public interface IAuthorValidator
{
	ValidationResult Validate(Author author);
}