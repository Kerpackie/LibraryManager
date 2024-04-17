using System.Collections;
using LibraryManager.Data.Models;

namespace LibraryManager.Data.Repositories.NotesRepositories;

public interface INotesRepository
{
	Task<IEnumerable<Note>> GetAll();
	Task<IEnumerable<Note>> GetAllNotesForBook(int bookId);
	Task<Note> GetById(int id);
	Task Create(Note note);
	Task Update(Note note);
	Task Delete(int id);
	Task DeleteAllNotesForBook(int bookId);
}