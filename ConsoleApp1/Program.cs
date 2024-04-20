﻿using LibraryManager.Data;
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
}*/

var x = serviceProvider.GetRequiredService<IAuthorRepository>();

var authors = await x.GetAll();

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

Console.WriteLine(authorServiceResponse.Message);