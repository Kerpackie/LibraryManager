using LibraryManager.Core.Models;

namespace LibraryManager.Core.Services.GenreService
{
	public interface IGenreService
	{
		Task<Genre?> CreateGenreAsync(Genre genre);
		Task<Genre?> GetGenreAsync(int id);
		Task<Genre?> GetGenreByNameAsync(string name);
		Task<IEnumerable<Genre?>> GetAllGenresAsync();
		Task<Genre?> UpdateGenreAsync(Genre genre);
		Task DeleteGenreAsync(int id);
	}
}