using System.Data;
using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using LibraryManager.Core.Services.AuthorService;
using LibraryManager.Core.Services.BookAPIService;
using LibraryManager.Core.Services.BookService;
using LibraryManager.Core.Services.CollectionService;
using LibraryManager.Core.Services.CoverService;
using LibraryManager.Core.Services.LoanService;
using LibraryManager.Core.Services.NotesService;
using LibraryManager.Core.Services.PublisherService;
using LibraryManager.Core.Services.SubjectService;
using LibraryManager.Core.Validators.AuthorValidator;
using LibraryManager.Core.Validators.CoverValidator;
using LibraryManager.Core.Validators.PublisherValidator;
using LibraryManager.Core.Validators.SubjectValidator;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace LibraryManager.Core;

public static class DependencyInjection
{
	public static IServiceCollection AddLibraryManagerCore(this IServiceCollection services)
	{
		
		services.AddScoped<IAuthorService, AuthorService>();
		services.AddScoped<IBookService, BookService>();
		services.AddScoped<IDapperBookService, DapperBookService>();
		services.AddScoped<ICollectionService, CollectionService>();
		services.AddScoped<ICoverService, CoverService>();
		services.AddScoped<ILoanService, LoanService>();
		services.AddScoped<INoteService, NoteService>();
		services.AddScoped<IPublisherService, PublisherService>();
		services.AddScoped<ISubjectService, SubjectService>();
		
		services.AddScoped<IAuthorValidator, AuthorValidator>();
		services.AddScoped<IPublisherValidator, PublisherValidator>();
		services.AddScoped<ISubjectValidator, SubjectValidator>();
		services.AddScoped<ICoverValidator, CoverValidator>();
		return services;
	}
	
	public static IServiceCollection AddLibraryManagerDatabase(this IServiceCollection services, DbConnectionConfig dbConnectionConfig)
	{
		services.AddSingleton(dbConnectionConfig);
		
		if (dbConnectionConfig.ProviderName == "SQLite")
		{
			// Getting sick of EFCore bullshit and poor errors being returned.
			services.AddTransient<IDbConnection>(db => new SqliteConnection(dbConnectionConfig.ConnectionString));
			
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
	
	public static IServiceCollection UseOpenLibraryApi(this IServiceCollection services)
	{
		services.AddRefitClient<IOpenLibraryApiService>()
			.ConfigureHttpClient(c => c.BaseAddress = new Uri("https://openlibrary.org"));

		// Declare IBookApiService down here to allow the user to change the implementation of the service
		// To use a different API service if they like, simulating a plugin system.
		services.AddScoped<IBookApiService, OpenLibraryBookApiService>();
		
		return services;
	}
}