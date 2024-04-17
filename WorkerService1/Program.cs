using System.Data;
using LibraryManager.Core;
using LibraryManager.Core.Data;
using LibraryManager.Core.Services.BookService;
using WorkerService1;

var dbConnectionConfig = new DbConnectionConfig
{
	ConnectionString = "Data Source=Library.db",
	ProviderName = "SQLite"
};

var services = new ServiceCollection();

services.AddLibraryManagerDatabase(dbConnectionConfig);

services.AddScoped<IBookService, DapperBookService>();

