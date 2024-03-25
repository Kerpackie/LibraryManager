using LibraryManager.Core.Models;

namespace LibraryManager.Core.Validators.SubjectValidator;

public interface ISubjectValidator
{
	ValidationResult Validate(Subject subject);
}