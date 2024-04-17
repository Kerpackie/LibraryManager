using Dapper;
using LibraryManager.Core.Models;
using Microsoft.Data.Sqlite;

namespace LibraryManager.Core.Services.BookService;

public interface IDapperBookService
{
	Task<int> InsertBookWithSubjectsAndCollectionsAsync(Book book, List<Subject> subjects,
		List<Collection> categories);

}