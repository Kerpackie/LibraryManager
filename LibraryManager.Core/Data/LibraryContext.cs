using LibraryManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SQLite;
using LibraryManager.Core.Data.EntityMapping;

namespace LibraryManager.Core.Data
{
	public class LibraryContext : DbContext
	{
		private readonly DbConnectionConfig _dbConnectionConfig;

		public LibraryContext(DbConnectionConfig dbConnectionConfig)
		{
			_dbConnectionConfig = dbConnectionConfig;
		}

		public DbSet<Book> Books => Set<Book>();
		public DbSet<Author> Authors => Set<Author>();
		public DbSet<Publisher> Publishers => Set<Publisher>();
		public DbSet<Subject> Subjects => Set<Subject>();
		public DbSet<BookSubject> BookSubjects => Set<BookSubject>();
		public DbSet<Cover> Covers => Set<Cover>();

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (_dbConnectionConfig.ProviderName == "SQLite")
			{
				var connectionStringBuilder = new SQLiteConnectionStringBuilder(_dbConnectionConfig.ConnectionString);
				//var databaseFilePath = connectionStringBuilder.DataSource;

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
			else
			{
				optionsBuilder.UseSqlServer(_dbConnectionConfig.ConnectionString);
			}

			base.OnConfiguring(optionsBuilder);
		}
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new BookMapping());
			modelBuilder.ApplyConfiguration(new BookSubjectMapping());
			modelBuilder.ApplyConfiguration(new AuthorMapping());
			modelBuilder.ApplyConfiguration(new CoverMapping());
			modelBuilder.ApplyConfiguration(new PublisherMapping());
			modelBuilder.ApplyConfiguration(new SubjectMapping());
		}
	}
}