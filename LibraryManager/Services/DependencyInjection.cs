using LibraryManager.Services.FormService;
using LibraryManager.Views;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManager.Services;

public static class DependencyInjection
{
	public static IServiceCollection AddLibraryManager(this IServiceCollection services)
	{
		services.AddSingleton<IFormService, FormService.FormService>();
		services.AddTransient<MainForm>();
		
		return services;
	}
}