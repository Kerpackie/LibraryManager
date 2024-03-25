using LibraryManager.Core.Models;

namespace LibraryManager.Core.Validators.CoverValidator;

public interface ICoverValidator
{
	ValidationResult Validate(Cover cover);
}