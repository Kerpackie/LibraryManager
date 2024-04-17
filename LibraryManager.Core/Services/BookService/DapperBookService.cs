using Dapper;
using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using Microsoft.Data.Sqlite;

namespace LibraryManager.Core.Services.BookService;

public class DapperBookService : IDapperBookService
{
	private readonly DbConnectionConfig _dbConnectionConfig;

	public DapperBookService(DbConnectionConfig dbConnectionConfig)
	{
		_dbConnectionConfig = dbConnectionConfig;
	}


	public async Task<int> InsertBookWithSubjectsAndCollectionsAsync(Book book, List<Subject> subjects, List<Collection> collections)
	{
		await using var connection = new SqliteConnection(_dbConnectionConfig.ConnectionString);

	    // Insert the book
	    var sql = @"INSERT INTO Books (ISBN, Title, AuthorId, PageCount, PagesRead, Owned, Loaned, PublisherId, CoverId, CoversDownloaded)
	                VALUES (@ISBN, @Title, @AuthorId, @PageCount, @PagesRead, @Owned, @Loaned, @PublisherId, @CoverId, @CoversDownloaded);";
	    var parameters = new
	    {
	        ISBN = book.Isbn,
	        Title = book.Title,
	        AuthorId = book.AuthorId,
	        PageCount = book.PageCount,
	        PagesRead = book.PagesRead,
	        Owned = book.Owned,
	        Loaned = book.Loaned,
	        PublisherId = book.PublisherId,
	        CoverId = book.CoverId,
	        CoversDownloaded = book.CoversDownloaded
	    };
	    var affectedRows = await connection.ExecuteAsync(sql, parameters);

	    // Insert the subjects and collections
	    foreach (var subject in subjects)
	    {
	        var subjectSql = "INSERT INTO Subjects (Name) VALUES (@Name) ON CONFLICT (Name) DO NOTHING";
	        await connection.ExecuteAsync(subjectSql, new { Name = subject.Name });

	        var bookSubjectSql = "INSERT INTO BookSubjects (BookId, SubjectId) VALUES (@BookId, (SELECT Id FROM Subjects WHERE Name = @Name))";
	        await connection.ExecuteAsync(bookSubjectSql, new { BookId = book.Id, Name = subject.Name });
	    }

	    foreach (var collection in collections)
	    {
	        var collectionSql = "INSERT INTO Collections (Name) VALUES (@Name) ON CONFLICT (Name) DO NOTHING";
	        await connection.ExecuteAsync(collectionSql, new { Name = collection.Name });

	        var bookCollectionSql = "INSERT INTO BookCollections (BookId, CollectionId) VALUES (@BookId, (SELECT Id FROM Collections WHERE Name = @Name))";
	        await connection.ExecuteAsync(bookCollectionSql, new { BookId = book.Id, Name = collection.Name });
	    }

	    return affectedRows;
	}
}