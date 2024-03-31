using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManager.FrameworkUI.Services;
using LibraryManager.FrameworkUI.Views;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManager.FrameworkUI
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			var services = new ServiceCollection();

			services.AddLibraryManager();
			
			var serviceProvider = services.BuildServiceProvider();

			
			Application.Run(serviceProvider.GetRequiredService<MainForm>());
		}
	}
}