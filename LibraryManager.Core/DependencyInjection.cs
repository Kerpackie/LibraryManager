using LibraryManager.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManager.Core;

public static class DependencyInjection
{
	public static IServiceCollection AddLibraryManagerCore(this IServiceCollection services, DbConnection dbConnection)
	{
		if (dbConnection.ProviderName == "SQLite")
		{
			services.AddDbContext<LibraryContext>(options =>
				options.UseSqlite(
					dbConnection.ConnectionString,
					b => b.MigrationsAssembly(typeof(LibraryContext).Assembly.FullName)));
		}
		else
		{
			services.AddDbContext<LibraryContext>(options =>
				options.UseSqlServer(
					dbConnection.ConnectionString,
					b => b.MigrationsAssembly(typeof(LibraryContext).Assembly.FullName)));
		}

		return services;
	}
}