using LibraryManager.Core.Models;

namespace LibraryManager.Core.Validators.SubjectValidator;

public class SubjectValidator : ISubjectValidator
{
	public ValidationResult Validate(Subject subject)
	{
		var result = new ValidationResult { IsValid = true };

		if (subject == null)
		{
			result.IsValid = false;
			result.Errors.Add("Subject is null");
			return result;
		}

		if (string.IsNullOrWhiteSpace(subject.Name))
		{
			result.IsValid = false;
			result.Errors.Add("Subject name is null or empty");
		}

		if (subject.Name is {Length: > 100})
		{
			result.IsValid = false;
			result.Errors.Add("Subject name is too long");
		}

		return result;
	}
}