using LibraryManager.Core.Models;
using LibraryManager.Core.Validators.SubjectValidator;

namespace LibraryManager.Core.Validators.PublisherValidator;

public class PublisherValidator : BaseValidator<Publisher>, IPublisherValidator
{
	protected override ValidationResult ValidateEntity(Publisher publisher)
	{
		var validationResult = new ValidationResult { IsValid = true };
		
		if(!validationResult.IsValid)
			return validationResult;
		
		if (string.IsNullOrWhiteSpace(publisher.Name))
		{
			validationResult.IsValid = false;
			validationResult.Errors.Add("Subject name cannot be null or empty");
		}

		if (string.IsNullOrEmpty(publisher.Name))
		{
			validationResult.IsValid = false;
			validationResult.Errors.Add("Subject name cannot be null or empty");
		}
		
		if (publisher.Name is {Length: > 100})
		{
			validationResult.IsValid = false;
			validationResult.Errors.Add("Publisher name is too long");
		}

		return validationResult;
	}
}