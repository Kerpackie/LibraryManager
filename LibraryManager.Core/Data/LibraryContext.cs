using System.Data.SQLite;
using LibraryManager.Core.Data.EntityMapping;
using LibraryManager.Core.Data.EntitySeeds;
using LibraryManager.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Core.Data;

public class LibraryContext : DbContext
{
	private readonly DbConnectionConfig _dbConnectionConfig;

	public LibraryContext(DbConnectionConfig dbConnectionConfig)
	{
		_dbConnectionConfig = dbConnectionConfig;
	}
	
	public virtual DbSet<Author> Authors { get; set; } = null!;
	public virtual DbSet<Book> Books { get; set; } = null!;
	public virtual DbSet<Note> Notes { get; set; } = null!;
	public virtual DbSet<Cover> Covers { get; set; } = null!;
	public virtual DbSet<Publisher> Publishers { get; set; } = null!;
	public virtual DbSet<Subject> Subjects { get; set; } = null!;
	public virtual DbSet<Collection> Collections { get; set; } = null!;
	public virtual DbSet<Loan> Loans { get; set; } = null!;
	
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (_dbConnectionConfig.ProviderName == "SQLite")
		{
			var connectionStringBuilder = new SQLiteConnectionStringBuilder(_dbConnectionConfig.ConnectionString);

			// Set databaseFilePath to currentWorkingDirectory/database.db
			var databaseFilePath = $"{Directory.GetCurrentDirectory()}/{connectionStringBuilder.DataSource}";
				
			// Check if the directory of the database file exists, if not, create it
			var databaseDirectory = Path.GetDirectoryName(databaseFilePath);
			if (!string.IsNullOrEmpty(databaseDirectory) && !Directory.Exists(databaseDirectory))
			{
				Directory.CreateDirectory(databaseDirectory);
			}

			optionsBuilder.UseSqlite(_dbConnectionConfig.ConnectionString);
		}
		else if (_dbConnectionConfig.ProviderName == "SqlServer")
		{
			optionsBuilder.UseSqlServer(_dbConnectionConfig.ConnectionString);
		}
		else if (_dbConnectionConfig.ProviderName == "Test")
		{
			optionsBuilder.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());
		}
		else
		{
			throw new Exception("Unsupported database provider");
		}

		base.OnConfiguring(optionsBuilder);
	}
	
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new BookMapping());
		modelBuilder.ApplyConfiguration(new AuthorMapping());
		modelBuilder.ApplyConfiguration(new PublisherMapping());
		modelBuilder.ApplyConfiguration(new SubjectMapping());
		modelBuilder.ApplyConfiguration(new NoteMapping());
		modelBuilder.ApplyConfiguration(new CollectionMapping());

		modelBuilder.ApplyConfiguration(new CollectionSeed());
	}
	
}