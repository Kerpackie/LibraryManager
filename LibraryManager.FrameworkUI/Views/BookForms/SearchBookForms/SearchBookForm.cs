using System.Windows.Forms;
using LibraryManager.FrameworkUI.Services.FormService;

namespace LibraryManager.FrameworkUI.Views.BookForms.SearchBookForms
{
	public partial class SearchBookForm : Form
	{
		private readonly Panel _parentPanel;
		private readonly IFormService _formService;
		
		public SearchBookForm(Panel parentPanel, IFormService formService, params object[] args)
		{
			_parentPanel = parentPanel;
			_formService = formService;
			
			InitializeComponent();
		}
	}
}