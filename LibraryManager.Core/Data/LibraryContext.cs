using LibraryManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SQLite;

namespace LibraryManager.Core.Data
{
	public class LibraryContext : DbContext
	{
		private readonly DbConnectionConfig _dbConnectionConfig;

		public LibraryContext(DbConnectionConfig dbConnectionConfig)
		{
			_dbConnectionConfig = dbConnectionConfig;
		}

		public DbSet<Book?> Books => Set<Book>();

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
	}
}