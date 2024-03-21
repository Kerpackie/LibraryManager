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
		public DbSet<Genre> Genres => Set<Genre>();

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (_dbConnectionConfig.ProviderName == "SQLite")
			{
				var connectionStringBuilder = new SQLiteConnectionStringBuilder(_dbConnectionConfig.ConnectionString);
				var databaseFilePath = connectionStringBuilder.DataSource;

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
			modelBuilder.ApplyConfiguration(new GenreMapping());
			modelBuilder.ApplyConfiguration(new BookMapping());
		}
	}
}