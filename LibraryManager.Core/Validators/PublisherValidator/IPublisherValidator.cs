using LibraryManager.Core.Models;

namespace LibraryManager.Core.Validators.PublisherValidator;

public interface IPublisherValidator
{
	ValidationResult Validate(Publisher publisher);
}