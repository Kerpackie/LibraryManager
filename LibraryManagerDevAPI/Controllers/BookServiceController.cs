using LibraryManager.Core.Models;
using LibraryManager.Core.Services.BookService;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagerDevAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class BookServiceController : ControllerBase
{
	private readonly IBookService _bookService;

	public BookServiceController(IBookService bookService)
	{
		_bookService = bookService;
	}

	[HttpGet("{isbn}")]
	[ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Get([FromRoute] string isbn)
	{
		var book = await _bookService.GetBookByIsbnAsync(isbn);
        
		return book == null
			? NotFound()
			: Ok(book);
	}
}