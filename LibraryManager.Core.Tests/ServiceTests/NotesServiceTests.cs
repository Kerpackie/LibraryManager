using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using LibraryManager.Core.Services.NotesService;

namespace LibraryManager.Core.Tests.ServiceTests;

[TestFixture]
public class NotesServiceTests
{
	private INoteService _noteService;
	private LibraryContext _context;
	
	[SetUp]
	public void Setup()
	{
		_context = new LibraryContext(new DbConnectionConfig { ProviderName = "Test" });
		_noteService = new NoteService(_context);
	}
	
	[Test]
	public async Task InsertNoteAsync_AddsNote_WhenBookExists()
	{
		// Arrange
		var book = new Book {Id = 1, Title = "Test Book" };
		var note = new Note { BookId = book.Id, Title = "Test Note", Content = "Lorem ipsum dolor sit amet."};
		
		_context.Books.Add(book);
		await _context.SaveChangesAsync();
		
		// Act
		var result = await _noteService.InsertNoteAsync(note);
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.True);
			Assert.That(result.Message, Is.EqualTo("Note added successfully"));
		});
	}
	
	[Test]
	public async Task InsertNoteAsync_ReturnsFailure_WhenBookDoesNotExist()
	{
		// Arrange
		var note = new Note { BookId = 1, Title = "Test Note", Content = "Lorem ipsum dolor sit amet."};
		
		// Act
		var result = await _noteService.InsertNoteAsync(note);
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Book not found"));
		});
	}
	
	[Test]
	public async Task GetNotesForBookAsync_ReturnsNotes_WhenBookExists()
	{
		// Arrange
		var book = new Book {Id = 1, Title = "Test Book" };
		var note1 = new Note { BookId = book.Id, Title = "Test Note 1", Content = "Lorem ipsum dolor sit amet."};
		var note2 = new Note { BookId = book.Id, Title = "Test Note 2", Content = "Lorem ipsum dolor sit amet."};

		_context.Books.Add(book);
		_context.Notes.AddRange(note1, note2);
		await _context.SaveChangesAsync();

		// Act
		var result = await _noteService.GetNotesForBookAsync(book.Id);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.True);
			Assert.That(result.Data.Count(), Is.EqualTo(2));
			Assert.That(result.Message, Is.EqualTo("Notes retrieved successfully"));
		});
	}
	
	[Test]
	public async Task GetNotesForBookAsync_ReturnsFailure_WhenBookDoesNotExist()
	{
		// Arrange
		// Act
		var result = await _noteService.GetNotesForBookAsync(1);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Book not found"));
		});
	}
	
	[Test]
	public async Task GetNotesForBookAsync_ReturnsFailure_WhenBookHasNoNotes()
	{
		// Arrange
		var book = new Book {Id = 1, Title = "Test Book" };
		_context.Books.Add(book);
		await _context.SaveChangesAsync();
		
		// Act
		var result = await _noteService.GetNotesForBookAsync(book.Id);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("No notes found for this book"));
		});
	}
	
	[Test]
	public async Task GetNotesForBookAsync_ReturnsFailure_WhenBookIdIsInvalid()
	{
		// Arrange
		// Act
		var result = await _noteService.GetNotesForBookAsync(0);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Book not found"));
		});
	}
	
	[Test]
	public async Task UpdateNoteAsync_ReturnsFailure_WhenNoteDoesNotExist()
	{
		// Arrange
		var note = new Note { Id = 1, BookId = 1, Title = "Test Note", Content = "Lorem ipsum dolor sit amet."};
		
		// Act
		var result = await _noteService.UpdateNoteAsync(note);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Not found"));
		});
	}
	
	[Test]
	public async Task UpdateNoteAsync_ReturnsFailure_WhenBookDoesNotExist()
	{
		// Arrange
		var note = new Note { Id = 1, BookId = 1, Title = "Test Note", Content = "Lorem ipsum dolor sit amet."};
		
		// Act
		var result = await _noteService.UpdateNoteAsync(note);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Not found"));
		});
	}
	
	[Test]
	public async Task UpdateNoteAsync_ReturnsFailure_WhenBookIdIsInvalid()
	{
		// Arrange
		var note = new Note { Id = 1, BookId = 0, Title = "Test Note", Content = "Lorem ipsum dolor sit amet."};
		
		// Act
		var result = await _noteService.UpdateNoteAsync(note);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Not found"));
		});
	}
	
	[Test]
	public async Task DeleteNoteAsync_ReturnsFailure_WhenNoteDoesNotExist()
	{
		// Arrange
		// Act
		var result = await _noteService.DeleteNoteAsync(1);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Not found"));
		});
	}
	
	[Test]
	public async Task DeleteNoteAsync_ReturnsSuccess_WhenNoteExists()
	{
		// Arrange
		var note = new Note { Id = 1, BookId = 1, Title = "Test Note", Content = "Lorem ipsum dolor sit amet."};
		_context.Notes.Add(note);
		await _context.SaveChangesAsync();
		
		// Act
		var result = await _noteService.DeleteNoteAsync(note.Id);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.True);
			Assert.That(result.Message, Is.EqualTo("Note deleted successfully"));
		});
	}
	
	[Test]
	public async Task DeleteNoteAsync_ReturnsFailure_WhenNoteIdIsInvalid()
	{
		// Arrange
		// Act
		var result = await _noteService.DeleteNoteAsync(0);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Not found"));
		});
	}
	
	[Test]
	public async Task DeleteNotesForBookAsync_ReturnsFailure_WhenBookDoesNotExist()
	{
		// Arrange
		// Act
		var result = await _noteService.DeleteNotesForBookAsync(1);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Book not found"));
		});
	}
	
	[Test]
	public async Task DeleteNotesForBookAsync_ReturnsSuccess_WhenBookExists()
	{
		// Arrange
		var book = new Book {Id = 1, Title = "Test Book" };
		var note1 = new Note { BookId = book.Id, Title = "Test Note 1", Content = "Lorem ipsum dolor sit amet."};
		var note2 = new Note { BookId = book.Id, Title = "Test Note 2", Content = "Lorem ipsum dolor sit amet."};

		_context.Books.Add(book);
		_context.Notes.AddRange(note1, note2);
		await _context.SaveChangesAsync();
		
		// Act
		var result = await _noteService.DeleteNotesForBookAsync(book.Id);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.True);
			Assert.That(result.Message, Is.EqualTo("Notes deleted successfully"));
		});
	}
	
	[Test]
	public async Task DeleteNotesForBookAsync_ReturnsFailure_WhenBookIdIsInvalid()
	{
		// Arrange
		// Act
		var result = await _noteService.DeleteNotesForBookAsync(0);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Book not found"));
		});
	}
	
	[Test]
	public async Task DeleteNotesForBookAsync_ReturnsSuccess_WhenBookHasNoNotes()
	{
		// Arrange
		var book = new Book {Id = 1, Title = "Test Book" };
		_context.Books.Add(book);
		await _context.SaveChangesAsync();
		
		// Act
		var result = await _noteService.DeleteNotesForBookAsync(book.Id);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.True);
			Assert.That(result.Message, Is.EqualTo("Notes deleted successfully"));
		});
	}
	
	[Test]
	public async Task DeleteNotesForBookAsync_ReturnsFailure_WhenBookHasNoNotesAndBookIdIsInvalid()
	{
		// Arrange
		// Act
		var result = await _noteService.DeleteNotesForBookAsync(0);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Book not found"));
		});
	}
	
	[Test]
	public async Task GetNoteAsync_ReturnsNote_WhenNoteExists()
	{
		// Arrange
		var note = new Note { Id = 1, BookId = 1, Title = "Test Note", Content = "Lorem ipsum dolor sit amet."};
		_context.Notes.Add(note);
		await _context.SaveChangesAsync();
		
		// Act
		var result = await _noteService.GetNoteAsync(note.Id);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.True);
			Assert.That(result.Data, Is.EqualTo(note));
			Assert.That(result.Message, Is.EqualTo("Note retrieved successfully"));
		});
	}
	
	[Test]
	public async Task GetNoteAsync_ReturnsFailure_WhenNoteDoesNotExist()
	{
		// Arrange
		// Act
		var result = await _noteService.GetNoteAsync(1);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Note not found"));
		});
	}
	
	[Test]
	public async Task GetNoteAsync_ReturnsFailure_WhenNoteIdIsInvalid()
	{
		// Arrange
		// Act
		var result = await _noteService.GetNoteAsync(0);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Note not found"));
		});
	}
	
	[Test]
	public async Task UpdateNoteAsync_UpdatesNote_WhenNoteExists()
	{
		// Arrange
		var note = new Note { Id = 1, BookId = 1, Title = "Test Note", Content = "Lorem ipsum dolor sit amet."};
		_context.Notes.Add(note);
		await _context.SaveChangesAsync();
		
		note.Title = "Updated Note";
		note.Content = "Updated content";
		
		// Act
		var result = await _noteService.UpdateNoteAsync(note);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.True);
			Assert.That(result.Message, Is.EqualTo("Note updated successfully"));
		});
	}
	
	[Test]
	public async Task UpdateNoteAsync_ReturnsFailure_WhenNoteIdIsInvalid()
	{
		// Arrange
		var note = new Note { Id = 0, BookId = 1, Title = "Test Note", Content = "Lorem ipsum dolor sit amet."};
		
		// Act
		var result = await _noteService.UpdateNoteAsync(note);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Not found"));
		});
	}
}