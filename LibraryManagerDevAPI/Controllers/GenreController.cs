using LibraryManager.Core.Models;
using LibraryManager.Core.Services.GenreService;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagerDevAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class GenreController : ControllerBase
{
	private readonly IGenreService _genreService;

	public GenreController(IGenreService genreService)
	{
		_genreService = genreService;
	}
	
	[HttpGet]
	[ProducesResponseType(typeof(List<Genre>), StatusCodes.Status200OK)]
	public async Task<IActionResult> GetAll()
	{
		return Ok(await _genreService.GetAllGenresAsync());
	}

	[HttpGet("{id:int}")]
	[ProducesResponseType(typeof(Genre), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Get([FromRoute] int id)
	{
		var genre = await _genreService.GetGenreAsync(id);
        
		return genre == null
			? NotFound()
			: Ok(genre);
	}
    
	[HttpPost]
	[ProducesResponseType(typeof(Genre), StatusCodes.Status201Created)]
	public async Task<IActionResult> Create([FromBody] Genre genre)
	{
		await _genreService.CreateGenreAsync(genre);

		return CreatedAtAction(nameof(Get), new { id = genre.Id }, genre);
	}
	
	[HttpPut]
	[ProducesResponseType(typeof(Genre), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Update([FromBody] Genre genre)
	{
		var existingGenre = await _genreService.UpdateGenreAsync(genre);

		return Ok(existingGenre);
	}
    
	[HttpDelete("{id:int}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Remove([FromRoute] int id)
	{
		await _genreService.DeleteGenreAsync(id);

		return Ok();
	}
}