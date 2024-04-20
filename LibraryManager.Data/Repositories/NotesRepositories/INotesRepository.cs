using System.Collections;
using LibraryManager.Data.Models;

namespace LibraryManager.Data.Repositories.NotesRepositories;

public interface INotesRepository
{
	Task<IEnumerable<Note>> GetAll();
	Task<IEnumerable<Note>> GetAllNotesForBook(int bookId);
	Task<Note> GetById(int id);
	Task<int> Create(Note note);
	Task<int> Update(Note note);
	Task<int> Delete(int id);
	Task<int> DeleteAllNotesForBook(int bookId);
}