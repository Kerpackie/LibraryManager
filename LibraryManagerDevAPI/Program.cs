using LibraryManager.Core;
using LibraryManager.Core.Data;

var builder = WebApplication.CreateBuilder(args);

// Build configuration
var configuration = new ConfigurationBuilder()
	.SetBasePath(Directory.GetCurrentDirectory())
	.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
	.Build();

// Get DbConnection from configuration
var dbConnection = new DbConnectionConfig
{
	ConnectionString = "Data Source=library.db",
	ProviderName = "SQLite"
};

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddLibraryManagerDatabase(dbConnection);
builder.Services.AddLibraryManagerCore();
builder.Services.UseOpenLibraryApi();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// DIRTY HACK DO NOT DO THIS IN PRODUCTION

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<LibraryContext>();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();