using LibraryManager.Core.Models;
using LibraryManager.Core.Models.OpenLibraryResponseModels;
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
	
	[HttpGet("api-demo/{isbn}")]
	public async Task<IActionResult> GetAPIDemo(string isbn)
	{
		var book = await _bookService.LoadBookFromApiWithIsbnAsync(isbn);

		return Ok(book);
	}
	
	[HttpPost("api-demo")]
	public async Task<IActionResult> CreateAPIDemo([FromBody] Book book)
	{
		await _bookService.InsertOrIgnoreBookAsync(book);

		return CreatedAtAction(nameof(GetAPIDemo), new {isbn = book.Isbn}, book);
	}
	
	[HttpGet("api-demo/books/{isbn}")]
	public async Task<IActionResult> GetBookByIsbn(string isbn)
	{
		var book = await _bookService.GetBookByIsbnAsync(isbn);

		return book.Success
			? Ok(book)
			: NotFound(book);
	}
	
	[HttpGet("api-demo/books/")]
	public async Task<IActionResult> GetAllBooks()
	{
		var books = await _bookService.GetAllBooksAsync();

		return Ok(books);
	}
	
}