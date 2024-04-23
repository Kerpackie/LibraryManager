using System;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using System.Collections.Generic;

interface IOpenLibraryApi
{
    [Get("/search.json?q=subject:fiction_horror+isbn:[* TO *]&limit=1")]
    Task<OpenLibrarySearchResponse> SearchBooks();
}

public class OpenLibrarySearchResponse
{
    public int NumFound { get; set; }
    public List<OpenLibraryDoc> Docs { get; set; }
}

class Program
{
    static async Task Main(string[] args)
    {
        var httpClient = new HttpClient { BaseAddress = new Uri("https://openlibrary.org") };
        var openLibraryApi = RestService.For<IOpenLibraryApi>(httpClient);

        try
        {
            var response = await openLibraryApi.SearchBooks();
            if (response.Docs.Count > 0)
            {
                var firstDoc = response.Docs[0];
                if (firstDoc.ISBN != null && firstDoc.ISBN.Count > 0)
                {
                    var firstISBN = firstDoc.ISBN[0];
                    Console.WriteLine($"First ISBN: {firstISBN}");
                }
                else
                {
                    Console.WriteLine("No ISBN found for the first book.");
                }
            }
            else
            {
                Console.WriteLine("No books found in the response.");
            }
        }
        catch (ApiException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}




/*using LibraryManager.Core.Services.BookAPIService;
using LibraryManager.Data;
using LibraryManager.Data.Models;
using LibraryManager.Data.Repositories;
using LibraryManager.Data.Repositories.AuthorRepositories;
using LibraryManager.Data.Services;
using LibraryManager.Data.Services.AuthorService;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
	.AddDatabase()
	.BuildServiceProvider();

/*{
	var context = serviceProvider.GetRequiredService<DbContext>();
	await context.Init();
}#1#

var x = serviceProvider.GetRequiredService<IAuthorRepository>();

var z = serviceProvider.GetRequiredService<IOpenLibraryApiService>();

var a = await z.GetBookByIsbn("9780141439587");

foreach (var book in a)
{
    Console.WriteLine(book.Value.Title);
}

/*var authors = await x.GetAll();

foreach (var author in authors)
{
	Console.WriteLine(author.Name);
}

Console.WriteLine("--------------------");

Console.WriteLine("Getting author by Name...");
var authorByName = await x.GetByName("New Author");

Console.WriteLine("delete author by Name...");
await x.Delete(authorByName.Id);

Console.WriteLine("--------------------");


Console.WriteLine("Authors after deleting author by Name:");

authors = await x.GetAll();

foreach (var author in authors)
{
	Console.WriteLine(author.Name);
}

Console.WriteLine("--------------------");

Console.WriteLine("Creating new author...");
var newAuthor = new Author
{
	Name = "New Author"
};

await x.Create(newAuthor);

Console.WriteLine("New author created!");

Console.WriteLine("--------------------");

Console.WriteLine("Authors after creating new author:");
authors = await x.GetAll();

foreach (var author in authors)
{
	Console.WriteLine(author.Name);
}


Console.WriteLine("--------------------");
Console.WriteLine("--------------------");
Console.WriteLine("--------------------");
Console.WriteLine("--------------------");
Console.WriteLine("--------------------");
Console.WriteLine("--------------------");
Console.WriteLine("--------------------");

var y = serviceProvider.GetRequiredService<IAuthorService>();

var authorServiceResponse = await y.CreateAuthorAsync(new Author
{
	Name = "Bob Dole"
});

Console.WriteLine(authorServiceResponse.Message);#1#*/