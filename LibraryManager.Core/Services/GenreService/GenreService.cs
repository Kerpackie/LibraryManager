using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Core.Services.GenreService;

public class GenreService : IGenreService
{
	private readonly LibraryContext _context;

	public GenreService(LibraryContext context)
	{
		_context = context;
	}

	public async Task<Genre?> CreateGenreAsync(Genre genre)
	{
		throw new NotImplementedException();
	}

	public async Task<Genre?> GetGenreAsync(int id)
	{
		var genre = await _context.Genres.FindAsync(id);
		return genre;
	}

	public async Task<Genre?> GetGenreByNameAsync(string name)
	{
		var genre = await _context.Genres.FirstOrDefaultAsync(g => g.Name == name);
		return genre;
	}

	public async Task<IEnumerable<Genre?>> GetAllGenresAsync()
	{
		return await _context.Genres.ToListAsync();
	}

	public async Task<Genre?> UpdateGenreAsync(Genre genre)
	{
		var existingGenre = await _context.Genres.FindAsync(genre.Id);

		if (existingGenre is null)
			return null;

		existingGenre.Name = genre.Name;

		await _context.SaveChangesAsync();

		return existingGenre;
	}

	public async Task DeleteGenreAsync(int id)
	{
		var existingGenre = await _context.Genres.FindAsync(id);

		if (existingGenre is null)
			return;
		
		_context.Genres.Remove(existingGenre);
		
		await _context.SaveChangesAsync();
	}
}