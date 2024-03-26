using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LibraryManager.Core.Data;

public class LibraryContextFactory : IDesignTimeDbContextFactory<LibraryContext>
{
	public LibraryContext CreateDbContext(string[] args)
	{
		var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
		optionsBuilder.UseSqlite("DataSource=:memory:");

		return new LibraryContext(new DbConnectionConfig { ProviderName = "SQLite", ConnectionString = "DataSource=:memory:" });
	}
}