using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;

namespace LibraryManager.Data;

public class DbContext
{
	public IDbConnection CreateConnection()
	{
		return new SqliteConnection("Data Source=LocalDatabase.db");
	}

    public async Task Init()
    {
        // create database tables if they don't exist
        using var connection = CreateConnection();
        
        await InitAuthors(connection);
        await InitCollections(connection);
        await InitCovers(connection);
        await InitLoans(connection);
        await InitPublishers(connection);
        await InitBooks(connection);
        await InitBookCollections(connection);
        await InitBookLoans(connection);
        await InitNotes(connection);
        await InitSubjects(connection);
        await InitBookSubjects(connection);
        
        // Seed Data
        await SeedCollections(connection);
        await SeedAuthors(connection);
        await SeedSubjects(connection);
        await SeedPublishers(connection);
        await SeedCover(connection);
        await SeedBook(connection);

        await SeedBookCollections(connection);
        await SeedBookSubjects(connection);
    }

	private static async Task InitAuthors(IDbConnection connection)
	{
		var sql = """
		              CREATE TABLE IF NOT EXISTS
		              Authors
		          (
		              Id   INTEGER not null
		                  constraint PK_Authors
		                      primary key autoincrement,
		              Name TEXT    not null
		          );
		          CREATE UNIQUE INDEX IX_Authors_Name ON Authors (Name);
		          """;
		await connection.ExecuteAsync(sql);
	}
	
	private static async Task InitCollections(IDbConnection connection)
    {
        var sql = @"
                    CREATE TABLE IF NOT EXISTS
                    Collections
                (
                    Id   INTEGER not null
                        constraint PK_Collections
                            primary key autoincrement,
                    Name TEXT    not null
                );
                CREATE UNIQUE INDEX IF NOT EXISTS IX_Collections_Name ON Collections (Name);
                ";
        await connection.ExecuteAsync(sql);
    }

    private static async Task InitCovers(IDbConnection connection)
    {
        var sql = @"
                    CREATE TABLE IF NOT EXISTS
                    Covers
                (
                    Id     INTEGER not null
                        constraint PK_Covers
                            primary key autoincrement,
                    Small  TEXT,
                    Medium TEXT,
                    Large  TEXT
                );
                ";
        await connection.ExecuteAsync(sql);
    }

    private static async Task InitLoans(IDbConnection connection)
    {
        var sql = @"
                    CREATE TABLE IF NOT EXISTS
                    Loans
                (
                    Id         INTEGER not null
                        constraint PK_Loans
                            primary key autoincrement,
                    Borrower   TEXT    not null,
                    LoanDate   TEXT    not null,
                    ReturnDate TEXT,
                    IsReturned INTEGER not null,
                    Deleted    INTEGER not null
                );
                ";
        await connection.ExecuteAsync(sql);
    }

    private static async Task InitPublishers(IDbConnection connection)
    {
        var sql = @"
                    CREATE TABLE IF NOT EXISTS
                    Publishers
                (
                    Id   INTEGER not null
                        constraint PK_Publishers
                            primary key autoincrement,
                    Name TEXT    not null
                );
                CREATE UNIQUE INDEX IF NOT EXISTS IX_Publishers_Name ON Publishers (Name);
                ";
        await connection.ExecuteAsync(sql);
    }

    private static async Task InitBooks(IDbConnection connection)
    {
        var sql = @"
                    CREATE TABLE IF NOT EXISTS
                    Books
                (
                    Id               INTEGER not null
                        constraint PK_Books
                            primary key autoincrement,
                    ISBN             TEXT,
                    Title            TEXT    not null,
                    AuthorId         INTEGER
                        constraint FK_Books_Authors_AuthorId
                            references Authors,
                    PageCount        INTEGER not null,
                    PagesRead        INTEGER not null,
                    Owned            INTEGER not null,
                    Loaned           INTEGER not null,
                    PublisherId      INTEGER
                        constraint FK_Books_Publishers_PublisherId
                            references Publishers,
                    CoverId          INTEGER not null
                        constraint FK_Books_Covers_CoverId
                            references Covers,
                    CoversDownloaded INTEGER not null
                );
                CREATE INDEX IF NOT EXISTS IX_Books_AuthorId ON Books (AuthorId);
                CREATE INDEX IF NOT EXISTS IX_Books_CoverId ON Books (CoverId);
                CREATE UNIQUE INDEX IF NOT EXISTS IX_Books_ISBN ON Books (ISBN);
                CREATE INDEX IF NOT EXISTS IX_Books_PublisherId ON Books (PublisherId);
                ";
        await connection.ExecuteAsync(sql);
    }

    private static async Task InitBookCollections(IDbConnection connection)
    {
        var sql = @"
                    CREATE TABLE IF NOT EXISTS
                    BookCollections
                (
                    BookId       INTEGER not null
                        constraint FK_BookCollections_Books_BookId
                            references Books,
                    CollectionId INTEGER not null
                        constraint FK_BookCollections_Collections_CollectionId
                            references Collections,
                    constraint PK_BookCollections
                        primary key (BookId, CollectionId)
                );
                CREATE INDEX IF NOT EXISTS IX_BookCollections_CollectionId ON BookCollections (CollectionId);
                ";
        await connection.ExecuteAsync(sql);
    }

    private static async Task InitBookLoans(IDbConnection connection)
    {
        var sql = @"
                    CREATE TABLE IF NOT EXISTS
                    BookLoans
                (
                    BookId INTEGER not null
                        constraint FK_BookLoans_Books_BookId
                            references Books,
                    LoanId INTEGER not null
                        constraint FK_BookLoans_Loans_LoanId
                            references Loans,
                    constraint PK_BookLoans
                        primary key (BookId, LoanId)
                );
                CREATE INDEX IF NOT EXISTS IX_BookLoans_LoanId ON BookLoans (LoanId);
                ";
        await connection.ExecuteAsync(sql);
    }

    private static async Task InitNotes(IDbConnection connection)
    {
        var sql = @"
                    CREATE TABLE IF NOT EXISTS
                    Notes
                (
                    Id      INTEGER not null
                        constraint PK_Notes
                            primary key autoincrement,
                    Title   TEXT    not null,
                    Content TEXT    not null,
                    BookId  INTEGER not null
                        constraint FK_Notes_Books_BookId
                            references Books
                            on delete cascade
                );
                CREATE INDEX IF NOT EXISTS IX_Notes_BookId ON Notes (BookId);
                ";
        await connection.ExecuteAsync(sql);
    }

    private static async Task InitSubjects(IDbConnection connection)
    {
        var sql = @"
                    CREATE TABLE IF NOT EXISTS
                    Subjects
                (
                    Id   INTEGER not null
                        constraint PK_Subjects
                            primary key autoincrement,
                    Name TEXT    not null
                );
                CREATE UNIQUE INDEX IF NOT EXISTS IX_Subjects_Name ON Subjects (Name);
                ";
        await connection.ExecuteAsync(sql);
    }

    private static async Task InitBookSubjects(IDbConnection connection)
    {
        var sql = @"
                    CREATE TABLE IF NOT EXISTS
                    BookSubjects
                (
                    BookId    INTEGER not null
                        constraint FK_BookSubjects_Books_BookId
                            references Books,
                    SubjectId INTEGER not null
                        constraint FK_BookSubjects_Subjects_SubjectId
                            references Subjects,
                    constraint PK_BookSubjects
                        primary key (BookId, SubjectId)
                );
                CREATE INDEX IF NOT EXISTS IX_BookSubjects_SubjectId ON BookSubjects (SubjectId);
                ";
        await connection.ExecuteAsync(sql);
    }
    
    // Seed Data
    private static async Task SeedCollections(IDbConnection connection)
    {
        var sql = @"
                    INSERT INTO Collections (Name)
                    VALUES ('Wishlist'),
                           ('Read'),
                           ('To Read')
                ";
        
        await connection.ExecuteAsync(sql);
    }
    
    private static async Task SeedAuthors(IDbConnection connection)
    {
        var sql = @"
                    INSERT INTO Authors (Name)
                    VALUES ('Select Author'),
                           ('Agatha Christie'),
                           ('Arthur Conan Doyle'),
                           ('J.K. Rowling'),
                           ('George R.R. Martin'),
                           ('Stephen King'),
                           ('J.R.R. Tolkien'),
                           ('Dan Brown'),
                           ('Jules Verne'),
                           ('H.G. Wells'),
                           ('Isaac Asimov')
                ";
        
        await connection.ExecuteAsync(sql);
    }

    private static async Task SeedSubjects(IDbConnection connection)
    {
        var sql = @"
                    INSERT INTO Subjects (Name)
                    VALUES ('Select Subject'),
                           ('Adventure'),
                           ('Biography'),
                           ('Children''s'),
                           ('Classic'),
                           ('Crime'),
                           ('Fantasy'),
                           ('Fiction'),
                           ('Historical'),
                           ('Horror'),
                           ('Mystery'),
                           ('Non-Fiction'),
                           ('Romance'),
                           ('Science Fiction'),
                           ('Thriller'),
                           ('Young Adult')
                ";
        
        await connection.ExecuteAsync(sql);
    }

    private static async Task SeedPublishers(IDbConnection connection)
    {
        var sql = @"
                INSERT INTO Publishers (Name)
                VALUES ('Select Publisher'),
                       ('Penguin Random House'),
                       ('HarperCollins'),
                       ('Simon & Schuster'),
                       ('Hachette Livre'),
                       ('Macmillan Publishers'),
                       ('Scholastic'),
                       ('Pearson'),
                       ('Houghton Mifflin Harcourt'),
                       ('Bloomsbury'),
                       ('Oxford University Press')
               ";
        await connection.ExecuteAsync(sql);
    }

    private static async Task SeedCover(IDbConnection connection)
    {
        var sql = @"INSERT INTO Covers (Small, Medium, Large)
                    VALUES ('https://covers.openlibrary.org/b/id/1-Small.jpg', 'https://covers.openlibrary.org/b/id/1-Medium.jpg', 'https://covers.openlibrary.org/b/id/1-Large.jpg'),
                           ('https://covers.openlibrary.org/b/id/2-Small.jpg', 'https://covers.openlibrary.org/b/id/2-Medium.jpg', 'https://covers.openlibrary.org/b/id/2-Large.jpg'),
                           ('https://covers.openlibrary.org/b/id/3-Small.jpg', 'https://covers.openlibrary.org/b/id/3-Medium.jpg', 'https://covers.openlibrary.org/b/id/3-Large.jpg'),
                           ('https://covers.openlibrary.org/b/id/4-Small.jpg', 'https://covers.openlibrary.org/b/id/4-Medium.jpg', 'https://covers.openlibrary.org/b/id/4-Large.jpg'),
                           ('https://covers.openlibrary.org/b/id/5-Small.jpg', 'https://covers.openlibrary.org/b/id/5-Medium.jpg', 'https://covers.openlibrary.org/b/id/5-Large.jpg'),
                           ('https://covers.openlibrary.org/b/id/6-Small.jpg', 'https://covers.openlibrary.org/b/id/6-Medium.jpg', 'https://covers.openlibrary.org/b/id/6-Large.jpg'),
                           ('https://covers.openlibrary.org/b/id/7-Small.jpg', 'https://covers.openlibrary.org/b/id/7-Medium.jpg', 'https://covers.openlibrary.org/b/id/7-Large.jpg'),
                           ('https://covers.openlibrary.org/b/id/8-Small.jpg', 'https://covers.openlibrary.org/b/id/8-Medium.jpg', 'https://covers.openlibrary.org/b/id/8-Large.jpg'),
                           ('https://covers.openlibrary.org/b/id/9-Small.jpg', 'https://covers.openlibrary.org/b/id/9-Medium.jpg', 'https://covers.openlibrary.org/b/id/9-Large.jpg'),
                           ('https://covers.openlibrary.org/b/id/10-Small.jpg', 'https://covers.openlibrary.org/b/id/10-Medium.jpg', 'https://covers.openlibrary.org/b/id/10-Large.jpg')
                           ";
        
        await connection.ExecuteAsync(sql);
    }

    private static async Task SeedBook(IDbConnection connection)
    {
        var sql =
            @"INSERT INTO Books (ISBN, Title, AuthorId, PageCount, PagesRead, Owned, Loaned, PublisherId, CoverId, CoversDownloaded)
                VALUES ('9780007117116', 'The Hobbit', 7, 310, 0, 1, 0, 1, 1, 1),
                       ('9780007117117', 'The Fellowship of the Ring', 7, 398, 0, 1, 0, 2, 2, 1),
                       ('9780007117118', 'The Two Towers', 7, 327, 0, 1, 0, 1, 3, 1),
                       ('9780007117119', 'The Return of the King', 7, 347, 0, 1, 0, 1, 4, 1),
                       ('9780007117120', 'The Silmarillion', 7, 365, 0, 1, 0, 1, 5, 1),
                       ('9780007117121', 'The Adventures of Tom Bombadil', 7, 399, 0, 1, 0, 1, 6, 1),
                       ('9780007117122', 'The Children of Hurin', 7, 400, 0, 1, 0, 1, 7, 1),
                       ('9780007117123', 'Unfinished Tales', 7, 401, 0, 1, 0, 1, 8, 1),
                       ('9780007117124', 'The History of Middle-earth', 7, 402, 0, 1, 0, 5, 9, 1),
                       ('9780007117125', 'The Lord of the Rings', 7, 403, 0, 1, 0, 3, 10, 1)
                       ";

        await connection.ExecuteAsync(sql);
        
    }
    
    // Add Books to Collections
    private static async Task SeedBookCollections(IDbConnection connection)
    {
        var sql = @"
                    INSERT INTO BookCollections (BookId, CollectionId)
                    VALUES (1, 2),
                           (2, 2),
                           (3, 2),
                           (4, 2),
                           (5, 2),
                           (6, 2),
                           (7, 2),
                           (8, 2),
                           (9, 2),
                           (10, 2)
                ";
        
        await connection.ExecuteAsync(sql);
    }
    
    private static Task SeedBookSubjects(IDbConnection connection)
    {
        var sql = @"
                    INSERT INTO BookSubjects (BookId, SubjectId)
                    VALUES (1, 7),
                           (2, 7),
                           (3, 7),
                           (4, 7),
                           (5, 7),
                           (6, 7),
                           (7, 7),
                           (8, 7),
                           (9, 7),
                           (10, 7)
                ";
        
        return connection.ExecuteAsync(sql);
    }

}