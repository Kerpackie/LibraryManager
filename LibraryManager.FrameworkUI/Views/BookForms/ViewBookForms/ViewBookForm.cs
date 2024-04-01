using System.Windows.Forms;
using LibraryManager.FrameworkUI.Controls.BookFormControls;
using LibraryManager.FrameworkUI.Controls.ControlBarControls;
using LibraryManager.FrameworkUI.Services.FormService;
using LibraryManager.FrameworkUI.Views.BookForms.BaseBookForms;

namespace LibraryManager.FrameworkUI.Views.BookForms.ViewBookForms
{
	public partial class ViewBookForm : BaseBookForm
	{
		private readonly Panel _parentPanel;
		private readonly IFormService _formService;
		
		public ViewBookForm(Panel parentPanel, IFormService formService, params object[] args)
		
		{
			_parentPanel = parentPanel;
			_formService = formService;
			
			AddSearchControlControls();
			AddBodyControls();
			
			InitializeComponent();
		}
		
		private void AddSearchControlControls()
		{
			AddIsbnControls();
			AddAuthorControls();
			AddPublisherControls();
			AddTitleControls();
			
			AddIsLoanedControls();
			AddIsOwnedControls();
		}
		
		private void AddIsbnControls()
		{
			var isbnLabel = SearchControls.CreateLabelSearchIsbn();
			panelControl.Controls.Add(isbnLabel);
			
			var isbnTextBox = SearchControls.CreateTextBoxSearchIsbn();
			panelControl.Controls.Add(isbnTextBox);
			
			var isbnButton = SearchControls.CreateSearchIsbnButton();
			panelControl.Controls.Add(isbnButton);
		}
		
		private void AddTitleControls()
		{
			var titleLabel = SearchControls.CreateLabelSearchTitle();
			panelControl.Controls.Add(titleLabel);
			
			var titleTextBox = SearchControls.CreateTextBoxSearchTitle();
			panelControl.Controls.Add(titleTextBox);
			
			var titleButton = SearchControls.CreateSearchTitleButton();
			panelControl.Controls.Add(titleButton);
		}
		
		private void AddAuthorControls()
		{
			var authorLabel = SearchControls.CreateSearchAuthorLabel();
			panelControl.Controls.Add(authorLabel);
			
			var authorTextBox = SearchControls.CreateSearchAuthorTextBox();
			panelControl.Controls.Add(authorTextBox);
			
			var authorButton = SearchControls.CreateSearchAuthorButton();
			panelControl.Controls.Add(authorButton);
		}
		
		private void AddPublisherControls()
		{
			var publisherLabel = SearchControls.CreateSearchPublisherLabel();
			panelControl.Controls.Add(publisherLabel);
			
			var publisherTextBox = SearchControls.CreateSearchPublisherTextBox();
			panelControl.Controls.Add(publisherTextBox);
			
			var publisherButton = SearchControls.CreateSearchPublisherButton();
			panelControl.Controls.Add(publisherButton);
		}
		
		private void AddIsLoanedControls()
		{
			var isLoanedCheckBox = SearchControls.CreateSearchIsLoanedCheckBox();
			panelControl.Controls.Add(isLoanedCheckBox);
		}
		
		private void AddIsOwnedControls()
		{
			var isOwnedCheckBox = SearchControls.CreateSearchIsOwnedCheckBox();
			panelControl.Controls.Add(isOwnedCheckBox);
		}
		
		private void AddBodyControls()
		{
			AddSubjectsListBox();
			AddCollectionsListBox();
		}

		private void AddSubjectsListBox()
		{
			var subjectsListBox = CollectionControls.CreateListBoxBookCollectionsViewMode();
			panelBody.Controls.Add(subjectsListBox);
		}
		
		private void AddCollectionsListBox()
		{
			var collectionsListBox = CollectionControls.CreateListBoxBookCollectionsViewMode();
			panelBody.Controls.Add(collectionsListBox);
		}
	}
}