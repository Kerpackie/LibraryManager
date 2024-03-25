using LibraryManager.Core.Models;

namespace LibraryManager.Core.Services.NotesService;

public interface INoteService
{
	Task<ServiceResponse<Note>> InsertNoteAsync(Note note);
	Task<ServiceResponse<IEnumerable<Note>>> GetNotesForBookAsync(int bookId);
	Task<ServiceResponse<Note>> UpdateNoteAsync(Note note);
	Task<ServiceResponse<bool>> DeleteNoteAsync(int id);
	Task<ServiceResponse<bool>> DeleteNotesForBookAsync(int bookId);
	Task<ServiceResponse<Note>> GetNoteAsync(int id);
}