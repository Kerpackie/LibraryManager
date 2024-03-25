using LibraryManager.Core.Models;

namespace LibraryManager.Core.Validators.CoverValidator;

public class CoverValidator : BaseValidator<Cover>, ICoverValidator
{
	protected override ValidationResult ValidateEntity(Cover cover)
	{
		var validationResult = new ValidationResult { IsValid = true };
		
		if(!validationResult.IsValid)
			return validationResult;
		
		if (string.IsNullOrWhiteSpace(cover.Large))
		{
			validationResult.IsValid = false;
			validationResult.Errors.Add("Cover large cannot be null or empty");
		}

		if (string.IsNullOrWhiteSpace(cover.Small))
		{
			validationResult.IsValid = false;
			validationResult.Errors.Add("Cover small cannot be null or empty");
		}

		if (string.IsNullOrWhiteSpace(cover.Medium))
		{
			validationResult.IsValid = false;
			validationResult.Errors.Add("Cover medium cannot be null or empty");
		}

		if (string.IsNullOrEmpty(cover.Large))
		{
			validationResult.IsValid = false;
			validationResult.Errors.Add("Cover large cannot be null or empty");
		}

		if (string.IsNullOrEmpty(cover.Small))
		{
			validationResult.IsValid = false;
			validationResult.Errors.Add("Cover small cannot be null or empty");
		}

		if (string.IsNullOrEmpty(cover.Medium))
		{
			validationResult.IsValid = false;
			validationResult.Errors.Add("Cover medium cannot be null or empty");
		}
		
		// Check if the cover is a valid URL
		if (string.IsNullOrEmpty(cover.Large) || !Uri.IsWellFormedUriString(cover.Large, UriKind.Absolute))
		{
			validationResult.IsValid = false;
			validationResult.Errors.Add("Cover large is not a valid URL");
		}

		if (string.IsNullOrEmpty(cover.Small) || !Uri.IsWellFormedUriString(cover.Small, UriKind.Absolute))
		{
			validationResult.IsValid = false;
			validationResult.Errors.Add("Cover small is not a valid URL");
		}

		if (string.IsNullOrEmpty(cover.Medium) || !Uri.IsWellFormedUriString(cover.Medium, UriKind.Absolute))
		{
			validationResult.IsValid = false;
			validationResult.Errors.Add("Cover medium is not a valid URL");
		}

		return validationResult;
	}
}