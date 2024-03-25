using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManager.Core.Services.NotesService;

public class NoteService : INoteService
{
    private readonly LibraryContext _dbContext;

    public NoteService(LibraryContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ServiceResponse<Note>> InsertNoteAsync(Note note)
    {
        var serviceResponse = new ServiceResponse<Note>();

        try
        {
            var book = await _dbContext.Books.FindAsync(note.BookId);
            if (book == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Book not found";
                return serviceResponse;
            }

            book.Notes.Add(note);
            await _dbContext.SaveChangesAsync();

            serviceResponse.Data = note;
            serviceResponse.Message = "Note added successfully";
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = $"An error occurred: {ex.Message}";
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<IEnumerable<Note>>> GetNotesForBookAsync(int bookId)
    {
        var serviceResponse = new ServiceResponse<IEnumerable<Note>>();

        try
        {
            var book = await _dbContext.Books.Include(b => b.Notes)
                .FirstOrDefaultAsync(b => b.Id == bookId);
            if (book == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Book not found";
                return serviceResponse;
            }

            serviceResponse.Data = book.Notes;
            serviceResponse.Message = "Notes retrieved successfully";
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = $"An error occurred: {ex.Message}";
        }

        return serviceResponse;
    }
    
    public async Task<ServiceResponse<Note>> UpdateNoteAsync(Note note)
    {
        var serviceResponse = new ServiceResponse<Note>();

        try
        {
            var existingNote = await _dbContext.Notes.FindAsync(note.Id);
            if (existingNote == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Note not found";
                return serviceResponse;
            }

            existingNote.Content = note.Content;
            await _dbContext.SaveChangesAsync();

            serviceResponse.Data = existingNote;
            serviceResponse.Message = "Note updated successfully";
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = $"An error occurred: {ex.Message}";
        }

        return serviceResponse;
    }
    
    public async Task<ServiceResponse<bool>> DeleteNoteAsync(int id)
    {
        var serviceResponse = new ServiceResponse<bool>();

        try
        {
            var note = await _dbContext.Notes.FindAsync(id);
            if (note == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Note not found";
                return serviceResponse;
            }

            _dbContext.Notes.Remove(note);
            await _dbContext.SaveChangesAsync();

            serviceResponse.Data = true;
            serviceResponse.Message = "Note deleted successfully";
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = $"An error occurred: {ex.Message}";
        }

        return serviceResponse;
    }
    
    public async Task<ServiceResponse<bool>> DeleteNotesForBookAsync(int bookId)
    {
        var serviceResponse = new ServiceResponse<bool>();

        try
        {
            var book = await _dbContext.Books.Include(b => b.Notes)
                .FirstOrDefaultAsync(b => b.Id == bookId);
            if (book == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Book not found";
                return serviceResponse;
            }

            _dbContext.Notes.RemoveRange(book.Notes);
            await _dbContext.SaveChangesAsync();

            serviceResponse.Data = true;
            serviceResponse.Message = "Notes deleted successfully";
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = $"An error occurred: {ex.Message}";
        }

        return serviceResponse;
    }
    
    public async Task<ServiceResponse<Note>> GetNoteAsync(int id)
    {
        var serviceResponse = new ServiceResponse<Note>();

        try
        {
            var note = await _dbContext.Notes.FindAsync(id);
            if (note == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Note not found";
                return serviceResponse;
            }

            serviceResponse.Data = note;
            serviceResponse.Message = "Note retrieved successfully";
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = $"An error occurred: {ex.Message}";
        }

        return serviceResponse;
    }
}