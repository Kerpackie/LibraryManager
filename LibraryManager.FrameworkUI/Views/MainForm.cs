using System;
using System.Windows.Forms;
using LibraryManager.FrameworkUI.Services.FormService;
using LibraryManager.FrameworkUI.Views.BookForms.AddBookForms;
using LibraryManager.FrameworkUI.Views.BookForms.ViewBookForms;

namespace LibraryManager.FrameworkUI.Views
{
	public partial class MainForm : Form
	{
		private readonly IFormService _formService;
		
		public MainForm(IFormService formService)
		{
			_formService = formService;
			InitializeComponent();
		}

		private void btnImportBook_Click(object sender, EventArgs e)
		{
			foreach (Control control in panelContent.Controls)
			{
				if (control is Form form)
				{
					form.Dispose();
				}
			}
			
			_formService.OpenChildFormWithArgument<AddBookForm, string>(panelContent, "Import");
		}

		private void button1_Click(object sender, EventArgs e)
		{
			foreach (Control control in panelContent.Controls)
			{
				if (control is Form form)
				{
					form.Dispose();
				}
			}
			
			_formService.OpenChildForm<ViewBookForm>(panelContent);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			foreach (Control control in panelContent.Controls)
			{
				if (control is Form form)
				{
					form.Dispose();
				}
			}
			
			_formService.OpenChildFormWithArgument<AddBookForm, string>(panelContent, "Manual");
		}
	}
}