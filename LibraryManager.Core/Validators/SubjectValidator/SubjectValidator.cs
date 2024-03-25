using LibraryManager.Core.Models;

namespace LibraryManager.Core.Validators.SubjectValidator;

public class SubjectValidator : BaseValidator<Subject>, ISubjectValidator
{
	protected override ValidationResult ValidateEntity(Subject subject)
	{
		var validationResult = new ValidationResult { IsValid = true };
		
		if(!validationResult.IsValid)
			return validationResult;
		
		if (string.IsNullOrWhiteSpace(subject.Name))
		{
			validationResult.IsValid = false;
			validationResult.Errors.Add("Subject name cannot be null or empty");
		}

		if (string.IsNullOrEmpty(subject.Name))
		{
			validationResult.IsValid = false;
			validationResult.Errors.Add("Subject name cannot be null or empty");
		}
		
		if (subject.Name is {Length: > 100})
		{
			validationResult.IsValid = false;
			validationResult.Errors.Add("Publisher name is too long");
		}

		return validationResult;
	}
}