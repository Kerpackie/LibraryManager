namespace LibraryManager.Core.Validators;

public abstract class BaseValidator<T>
{
	public virtual ValidationResult Validate(T entity)
	{
		var validationResult = new ValidationResult { IsValid = true };

		if (entity == null)
		{
			validationResult.IsValid = false;
			validationResult.Errors.Add("Entity cannot be null");
			return validationResult;
		}

		return ValidateEntity(entity);
	}

	protected abstract ValidationResult ValidateEntity(T entity);
}