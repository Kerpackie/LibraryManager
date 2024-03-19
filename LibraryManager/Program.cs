using LibraryManager.Core;
using LibraryManager.Core.Data;
using LibraryManager.Services;
using LibraryManager.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManager
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            
            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Get DbConnection from configuration
            var dbConnection = new DbConnection
            {
                ConnectionString = configuration.GetSection("DbConnection:ConnectionString").Value ?? "Data Source=library.db",
                ProviderName = configuration.GetSection("DbConnection:ProviderName").Value ?? "SQLite"
            };
            
            var services = new ServiceCollection();
            services.AddLibraryManager();
            services.AddLibraryManagerCore(dbConnection);
            
            var serviceProvider = services.BuildServiceProvider();

            Application.Run(serviceProvider.GetRequiredService<MainForm>());
        }
        
    }
}