using System.Data;
using LibraryManager.Data.Repositories;
using LibraryManager.Data.Repositories.AuthorRepositories;
using LibraryManager.Data.Repositories.BookRepositories;
using LibraryManager.Data.Services;
using LibraryManager.Data.Services.AuthorService;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManager.Data;

public static class DependencyInjection
{
	public static IServiceCollection AddDatabase(this IServiceCollection services)
	{
		services.AddSingleton<DbContext>();
		services.AddTransient<IDbConnection>(sp => new SqliteConnection("Data Source=LocalDatabase.db"));
		services.AddTransient<Func<IDbConnection>>(sp => sp.GetRequiredService<IDbConnection>);
		services.AddRepositories();
		services.AddScoped<IAuthorService, AuthorService>();
		return services;
	}
	
	public static IServiceCollection AddRepositories(this IServiceCollection services)
	{
		services.AddScoped<IAuthorRepository, AuthorRepository>();
		services.AddScoped<IBookRepository, BookRepository>();/*
		services.AddScoped<ICategoryRepository, CategoryRepository>();
		services.AddScoped<IPublisherRepository, PublisherRepository>();*/
		return services;
	}
	
}