using LibraryManager.FrameworkUI.Services.FormService;
using LibraryManager.FrameworkUI.Views;
using LibraryManager.FrameworkUI.Views.BookForms;
using LibraryManager.FrameworkUI.Views.BookForms.AddBookForms;
using LibraryManager.FrameworkUI.Views.BookForms.BaseBookForms;
using LibraryManager.FrameworkUI.Views.BookForms.ViewBookForms;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManager.FrameworkUI.Services
{
	/// <summary>
	/// Provides methods for configuring dependency injection services for the LibraryManager application.
	/// </summary>
	public static class DependencyInjection
	{
		/// <summary>
		/// Adds and configures services for the LibraryManager application.
		/// </summary>
		/// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
		/// <returns>The same service collection so that multiple calls can be chained.</returns>
		public static IServiceCollection AddLibraryManager(this IServiceCollection services)
		{
			services.AddSingleton<IFormService, FormService.FormService>();
			services.AddTransient<MainForm>();
			services.AddTransient<AddBookForm>();
			services.AddTransient<ViewBookForm>();
			services.AddTransient<BaseBookForm>();

			return services;
		}
	}
}