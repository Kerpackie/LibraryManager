using LibraryManager.Core.Models;

namespace LibraryManager.Core.Validators.PublisherValidator;

public class PublisherValidator : IPublisherValidator
{
	public virtual ValidationResult Validate(Publisher publisher)
	{
		var result = new ValidationResult { IsValid = true };

		if (publisher == null)
		{
			result.IsValid = false;
			result.Errors.Add("Publisher is null");
			return result;
		}

		if (string.IsNullOrWhiteSpace(publisher.Name))
		{
			result.IsValid = false;
			result.Errors.Add("Author name is null or empty");
		}
		
		if (publisher.Name.Length > 100)
		{
			result.IsValid = false;
			result.Errors.Add("Publisher name is too long");
		}

		return result;
	}
}