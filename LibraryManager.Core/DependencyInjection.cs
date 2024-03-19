using LibraryManager.Core.Data;
using LibraryManager.Core.Services.BookService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManager.Core;

public static class DependencyInjection
{
	public static IServiceCollection AddLibraryManagerCore(this IServiceCollection services)
	{
		services.AddScoped<IBookService, BookService>();
		return services;
	}
	
	public static IServiceCollection AddLibraryManagerDatabase(this IServiceCollection services, DbConnectionConfig dbConnectionConfig)
	{
		if (dbConnectionConfig.ProviderName == "SQLite")
		{
			services.AddDbContext<LibraryContext>(options =>
				options.UseSqlite(
					dbConnectionConfig.ConnectionString,
					b => b.MigrationsAssembly(typeof(LibraryContext).Assembly.FullName)));
		}
		else
		{
			services.AddDbContext<LibraryContext>(options =>
				options.UseSqlServer(
					dbConnectionConfig.ConnectionString,
					b => b.MigrationsAssembly(typeof(LibraryContext).Assembly.FullName)));
		}

		return services;
	}
}