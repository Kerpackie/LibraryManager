using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using LibraryManager.Core.Services.SubjectService;
using LibraryManager.Core.Validators;
using LibraryManager.Core.Validators.SubjectValidator;

namespace LibraryManager.Core.Tests.ServiceTests;

[TestFixture]
public class SubjectServiceTests
{
	private ISubjectService _subjectService;
	private LibraryContext _context;
	private Mock<ISubjectValidator> _mockSubjectValidator;

	[SetUp]
	public void Setup()
	{
		_context = new LibraryContext(new DbConnectionConfig { ProviderName = "Test" });
		_mockSubjectValidator = new Mock<ISubjectValidator>();
		_subjectService = new SubjectService(_context, _mockSubjectValidator.Object);
	}
	
	[Test]
	public async Task InsertOrIgnoreSubjectAsync_ReturnsSuccess_WhenSubjectIsValidAndDoesNotExist()
	{
		var subject = new Subject { Name = "Valid Subject" };
		_mockSubjectValidator.Setup(x => x.Validate(subject))
			.Returns(new ValidationResult { IsValid = true });

		var result = await _subjectService.InsertOrIgnoreSubjectAsync(subject);

		Assert.That(result.Success, Is.True);
	}

	[Test]
	public async Task InsertOrIgnoreSubjectAsync_ReturnsFailure_WhenSubjectIsInvalid()
	{
		var subject = new Subject { Name = "Invalid Subject" };
		_mockSubjectValidator.Setup(x => x.Validate(subject))
			.Returns(new ValidationResult { IsValid = false });

		var result = await _subjectService.InsertOrIgnoreSubjectAsync(subject);

		Assert.That(result.Success, Is.False);
	}

	[Test]
	public async Task InsertOrIgnoreSubjectAsync_ReturnsFailure_WhenSubjectIsValidAndExists()
	{
		var subject = new Subject { Name = "Existing Subject" };
		_mockSubjectValidator.Setup(x => x.Validate(subject))
			.Returns(new ValidationResult { IsValid = true });

		_context.Subjects.Add(subject);
		await _context.SaveChangesAsync();

		var result = await _subjectService.InsertOrIgnoreSubjectAsync(subject);

		Assert.That(result.Success, Is.False);
	}

	[Test]
	public async Task InsertOrIgnoreSubjectAsync_ReturnsFailure_WhenSubjectIsNull()
	{
		Subject subject = null;
		_mockSubjectValidator.Setup(x => x.Validate(subject))
			.Returns(new ValidationResult { IsValid = false });

		var result = await _subjectService.InsertOrIgnoreSubjectAsync(subject);

		Assert.That(result.Success, Is.False);
	}
	
	[Test]
	public async Task InsertOrIgnoreSubjectAsync_AddsSubject_WhenSubjectIsValidAndDoesNotExist()
	{
	    var subject = new Subject { Name = "New Subject" };
	    _mockSubjectValidator.Setup(x => x.Validate(subject))
	        .Returns(new ValidationResult { IsValid = true });

	    var result = await _subjectService.InsertOrIgnoreSubjectAsync(subject);

	    Assert.That(result.Success, Is.True);
	    Assert.That(result.Data, Is.Not.Null);
	    Assert.That(result.Data, Is.EqualTo(subject));
	}

	[Test]
	public async Task InsertOrIgnoreSubjectAsync_DoesNotAddSubject_WhenSubjectIsInvalid()
	{
	    var subject = new Subject { Name = "Invalid Subject" };
	    _mockSubjectValidator.Setup(x => x.Validate(subject))
	        .Returns(new ValidationResult { IsValid = false });

	    var result = await _subjectService.InsertOrIgnoreSubjectAsync(subject);

	    Assert.That(result.Success, Is.False);
	    Assert.That(result.Data, Is.Null);
	}

	[Test]
	public async Task InsertOrIgnoreSubjectAsync_DoesNotAddSubject_WhenSubjectIsValidAndExists()
	{
	    var subject = new Subject { Name = "Existing Subject" };
	    _mockSubjectValidator.Setup(x => x.Validate(It.IsAny<Subject>()))
		    .Returns(new ValidationResult { IsValid = true });

	    _context.Subjects.Add(subject);
	    await _context.SaveChangesAsync();

	    var result = await _subjectService.InsertOrIgnoreSubjectAsync(new Subject { Name = "Existing Subject" });

	    Assert.That(result.Success, Is.False);
	    Assert.That(result.Data, Is.EqualTo(subject));
	}

	[Test]
	public async Task InsertOrIgnoreSubjectAsync_DoesNotAddSubject_WhenSubjectIsNull()
	{
	    Subject subject = null;
	    _mockSubjectValidator.Setup(x => x.Validate(subject))
	        .Returns(new ValidationResult { IsValid = false });

	    var result = await _subjectService.InsertOrIgnoreSubjectAsync(subject);

	    Assert.That(result.Success, Is.False);
	    Assert.That(result.Data, Is.Null);
	}
	
	[Test]
	public async Task InsertOrIgnoreSubjectAsync_AddsMultipleSubjects_WhenAllSubjectsAreValidAndDoNotExist()
	{
	    var subjects = new List<Subject>
	    {
	        new Subject { Name = "New Subject 1" },
	        new Subject { Name = "New Subject 2" },
	        new Subject { Name = "New Subject 3" }
	    };

	    foreach (var subject in subjects)
	    {
	        _mockSubjectValidator.Setup(x => x.Validate(subject))
	            .Returns(new ValidationResult { IsValid = true });
	    }

	    var result = await _subjectService.InsertOrIgnoreSubjectsAsync(subjects);

	    Assert.That(result.Success, Is.True);
	    Assert.That(result.Data, Is.EquivalentTo(subjects));
	}

	[Test]
	public async Task InsertOrIgnoreSubjectAsync_AddsValidSubjectsAndReturnsErrors_WhenSomeSubjectsAreInvalid()
	{
	    var validSubject = new Subject { Name = "Valid Subject" };
	    var invalidSubject = new Subject { Name = "Invalid Subject" };
	    var subjects = new List<Subject> { validSubject, invalidSubject };

	    _mockSubjectValidator.Setup(x => x.Validate(validSubject))
	        .Returns(new ValidationResult { IsValid = true });
	    _mockSubjectValidator.Setup(x => x.Validate(invalidSubject))
	        .Returns(new ValidationResult { IsValid = false, Errors = {"Invalid Subject"}});

	    var result = await _subjectService.InsertOrIgnoreSubjectsAsync(subjects);

	    Assert.That(result.Success, Is.False);
	    Assert.That(result.Data, Is.EquivalentTo(new List<Subject> { validSubject }));
	}

	[Test]
	public async Task InsertOrIgnoreSubjectAsync_ReturnsFailure_WhenAllSubjectsAreInvalid()
	{
	    var subjects = new List<Subject>
	    {
	        new Subject { Name = "Invalid Subject 1" },
	        new Subject { Name = "Invalid Subject 2" },
	        new Subject { Name = "Invalid Subject 3" }
	    };

	    foreach (var subject in subjects)
	    {
	        _mockSubjectValidator.Setup(x => x.Validate(subject))
	            .Returns(new ValidationResult { IsValid = false, Errors = {"Error: Invalid"}});
	    }

	    var result = await _subjectService.InsertOrIgnoreSubjectsAsync(subjects);

	    Assert.That(result.Success, Is.False);
	    Assert.That(result.Data, Is.Empty);
	}
}