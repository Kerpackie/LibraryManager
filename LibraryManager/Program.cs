using LibraryManager.Core;
using LibraryManager.Services;
using LibraryManager.Views;
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
            
            var services = new ServiceCollection();
            services.AddLibraryManager();
            services.AddLibraryManagerCore();
            
            var serviceProvider = services.BuildServiceProvider();

            Application.Run(serviceProvider.GetRequiredService<MainForm>());
        }
        
    }
}