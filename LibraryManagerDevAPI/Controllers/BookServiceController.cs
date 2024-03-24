using LibraryManager.Core.Models;
using LibraryManager.Core.Services.BookService;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagerDevAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class BookServiceController : ControllerBase
{
	private readonly IBookService2 _bookService;

	public BookServiceController(IBookService2 bookService)
	{
		_bookService = bookService;
	}
	
	[HttpGet("api-demo/{isbn}")]
	public async Task<IActionResult> GetAPIDemo(string isbn)
	{
		var book = await _bookService.GetBookFromApiAsync(isbn);

		return Ok(book);
	}
	
	[HttpPost("api-demo")]
	public async Task<IActionResult> CreateAPIDemo([FromBody] Book book)
	{
		await _bookService.AddBookAsync(book);

		return CreatedAtAction(nameof(GetAPIDemo), new {isbn = book.ISBN}, book);
	}

	/*[HttpGet("{isbn}")]
	[ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Get([FromRoute] string isbn)
	{
		var book = await _bookService.GetBookByIsbnAsync(isbn);
        
		return book == null
			? NotFound()
			: Ok(book);
	}
	
	[HttpGet("{id:int}")]
	[ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Get([FromRoute] int id)
	{
		var book = await _bookService.GetBookAsync(id);
        
		return book == null
			? NotFound()
			: Ok(book);
	}
	
	[HttpGet()]
	[ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
	public async Task<IActionResult> GetAll()
	{
		var books = await _bookService.GetAllBooksAsync();

		return Ok(books);
	}
	
	[HttpGet("by-year/{year}")]
	[ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
	public async Task<IActionResult> GetAllByYear([FromRoute] string year)
	{
		return Ok(await _bookService.GetBooksByPublicationYearAsync(year));
	}
	
	[HttpGet("by-author/{author}")]
	[ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
	public async Task<IActionResult> GetAllByAuthor([FromRoute] string author)
	{
		return Ok(await _bookService.GetBooksByAuthorAsync(author));
	}
	
	[HttpGet("by-title/{title}")]
	[ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
	public async Task<IActionResult> GetAllByTitle([FromRoute] string title)
	{
		return Ok(await _bookService.GetBooksByTitleAsync(title));
	}
	
	// Get By Publisher
	[HttpGet("by-publisher/{publisher}")]
	[ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
	public async Task<IActionResult> GetAllByPublisher([FromRoute] string publisher)
	{
		return Ok(await _bookService.GetBooksByPublisherAsync(publisher));
	}
	
	[HttpGet("by-genre/{genre}")]
	[ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
	public async Task<IActionResult> GetAllByGenre([FromRoute] string genre)
	{
		return Ok(await _bookService.GetBooksByGenreAsync(genre));
	}
	
	[HttpGet("by-page-count/{pageCount:int}")]
	[ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
	public async Task<IActionResult> GetAllByPageCount([FromRoute] int pageCount)
	{
		return Ok(await _bookService.GetBooksByNumberOfPagesAsync(pageCount));
	}
	
	[HttpGet("by-greater-page-count/{pageCount:int}")]
	[ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
	public async Task<IActionResult> GetAllByMoreThanPageCount([FromRoute] int pageCount)
	{
		return Ok(await _bookService.GetBooksWithMorePagesThanAsync(pageCount));
	}
	
	[HttpGet("by-less-page-count/{pageCount:int}")]
	[ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
	public async Task<IActionResult> GetAllByLessThanPageCount([FromRoute] int pageCount)
	{
		return Ok(await _bookService.GetBooksWithLessPagesThanAsync(pageCount));
	}
	
	// Create a book
	[HttpPost]
	[ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
	public async Task<IActionResult> Create([FromBody] Book book)
	{
		await _bookService.CreateBookAsync(book);

		return CreatedAtAction(nameof(Get), new {id = book.Id}, book);
	}*/
	
}