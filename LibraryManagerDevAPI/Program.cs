using LibraryManager.Core;
using LibraryManager.Core.Data;

var builder = WebApplication.CreateBuilder(args);

// Build configuration
var configuration = new ConfigurationBuilder()
	.SetBasePath(Directory.GetCurrentDirectory())
	.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
	.Build();

// Get DbConnection from configuration
var dbConnection = new DbConnection
{
	ConnectionString = configuration.GetSection("DbConnection:ConnectionString").Value,
	ProviderName = configuration.GetSection("DbConnection:ProviderName").Value
};

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddLibraryManagerCore(dbConnection);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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